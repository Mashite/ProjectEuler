using System.Text;
using System.Text.RegularExpressions;

const string SolutionFileName = "ProjectEuler.sln";
const string SolutionFolderProjectTypeGuid = "{2150E333-8FDC-42A3-9474-1A3956D46DE8}";
const string CsharpSdkProjectTypeGuid = "{9A19103F-16F7-4668-BE54-9A1E7A4F7556}";
const string TargetFramework = "net10.0";

var problemNumber = GetValue(args, 0, "Problem number");
var problemName = GetValue(args, 1, "Problem name");

ValidateProblemNumber(problemNumber);
ValidateProblemName(problemName);

var rootDirectory = FindSolutionDirectory();
var solutionPath = Path.Combine(rootDirectory, SolutionFileName);
var projectDirectory = Path.Combine(rootDirectory, problemName);
var projectPath = Path.Combine(projectDirectory, $"{problemName}.csproj");
var solutionFolderName = $"Problem-{problemNumber}";

if (Directory.Exists(projectDirectory))
{
    throw new InvalidOperationException($"Project folder already exists: {projectDirectory}");
}

Directory.CreateDirectory(projectDirectory);
File.WriteAllText(projectPath, CreateProjectFile(), Encoding.UTF8);
File.WriteAllText(Path.Combine(projectDirectory, "Program.cs"), CreateProgramFile(problemName), Encoding.UTF8);
File.WriteAllText(Path.Combine(projectDirectory, "Solution.cs"), CreateSolutionFile(problemName), Encoding.UTF8);

UpdateSolution(solutionPath, solutionFolderName, problemName);

Console.WriteLine($"Created {solutionFolderName}/{problemName}");

static string GetValue(string[] args, int index, string label)
{
    if (args.Length > index && !string.IsNullOrWhiteSpace(args[index]))
    {
        return args[index].Trim();
    }

    Console.Write($"{label}: ");
    return (Console.ReadLine() ?? string.Empty).Trim();
}

static void ValidateProblemNumber(string problemNumber)
{
    if (!Regex.IsMatch(problemNumber, "^[0-9]+$"))
    {
        throw new ArgumentException("Problem number must contain only digits.");
    }
}

static void ValidateProblemName(string problemName)
{
    if (!Regex.IsMatch(problemName, "^[A-Za-z_][A-Za-z0-9_]*$"))
    {
        throw new ArgumentException("Problem name must be a valid C# identifier, like PrimePowerTriples.");
    }
}

static string FindSolutionDirectory()
{
    var directory = new DirectoryInfo(AppContext.BaseDirectory);

    while (directory is not null)
    {
        var solutionPath = Path.Combine(directory.FullName, SolutionFileName);
        if (File.Exists(solutionPath))
        {
            return directory.FullName;
        }

        directory = directory.Parent;
    }

    throw new FileNotFoundException($"Could not find {SolutionFileName}.");
}

static string CreateProjectFile()
{
    return $"""
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>{TargetFramework}</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
""";
}

static string CreateProgramFile(string problemName)
{
    return $"""
using {problemName};

var solution = new Solution();
var result = solution.Solve();
Console.WriteLine(result);
""";
}

static string CreateSolutionFile(string problemName)
{
    return $$"""
namespace {{problemName}}
{
    internal class Solution
    {
        public int Solve()
        {
            throw new NotImplementedException();
        }
    }
}
""";
}

static void UpdateSolution(string solutionPath, string solutionFolderName, string projectName)
{
    var solution = File.ReadAllText(solutionPath);
    var projectPath = $@"{projectName}\{projectName}.csproj";

    if (solution.Contains($"= \"{projectName}\", \"{projectPath}\""))
    {
        throw new InvalidOperationException($"Solution already contains project: {projectName}");
    }

    var folderGuid = FindSolutionFolderGuid(solution, solutionFolderName) ?? NewSolutionGuid();
    var projectGuid = NewSolutionGuid();

    if (!solution.Contains($"= \"{solutionFolderName}\", \"{solutionFolderName}\", \"{folderGuid}\""))
    {
        var folderBlock = $"""
Project("{SolutionFolderProjectTypeGuid}") = "{solutionFolderName}", "{solutionFolderName}", "{folderGuid}"
EndProject
""";
        solution = InsertBefore(solution, "Global", folderBlock);
    }

    var projectBlock = $"""
Project("{CsharpSdkProjectTypeGuid}") = "{projectName}", "{projectPath}", "{projectGuid}"
EndProject
""";
    solution = InsertBefore(solution, "Global", projectBlock);

    solution = InsertProjectConfigurations(solution, projectGuid);
    solution = InsertNestedProject(solution, projectGuid, folderGuid);

    File.WriteAllText(solutionPath, solution, Encoding.UTF8);
}

static string? FindSolutionFolderGuid(string solution, string folderName)
{
    var pattern = $@"Project\(""{Regex.Escape(SolutionFolderProjectTypeGuid)}""\) = ""{Regex.Escape(folderName)}"", ""{Regex.Escape(folderName)}"", ""(?<guid>\{{[A-Fa-f0-9-]+\}})""";
    var match = Regex.Match(solution, pattern);
    return match.Success ? match.Groups["guid"].Value : null;
}

static string NewSolutionGuid()
{
    return $"{{{Guid.NewGuid().ToString().ToUpperInvariant()}}}";
}

static string InsertBefore(string text, string marker, string value)
{
    var index = text.IndexOf(marker, StringComparison.Ordinal);
    if (index < 0)
    {
        throw new InvalidOperationException($"Could not find marker: {marker}");
    }

    return text.Insert(index, value + Environment.NewLine);
}

static string InsertProjectConfigurations(string solution, string projectGuid)
{
    const string sectionName = "GlobalSection(ProjectConfigurationPlatforms) = postSolution";
    var sectionStart = solution.IndexOf(sectionName, StringComparison.Ordinal);
    if (sectionStart < 0)
    {
        throw new InvalidOperationException("Could not find ProjectConfigurationPlatforms section.");
    }

    var sectionEnd = solution.IndexOf("\tEndGlobalSection", sectionStart, StringComparison.Ordinal);
    if (sectionEnd < 0)
    {
        throw new InvalidOperationException("Could not find end of ProjectConfigurationPlatforms section.");
    }

    var configurationLines = $"""
		{projectGuid}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{projectGuid}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{projectGuid}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{projectGuid}.Release|Any CPU.Build.0 = Release|Any CPU
""";

    return solution.Insert(sectionEnd, configurationLines);
}

static string InsertNestedProject(string solution, string projectGuid, string folderGuid)
{
    const string sectionName = "GlobalSection(NestedProjects) = preSolution";
    var sectionStart = solution.IndexOf(sectionName, StringComparison.Ordinal);

    if (sectionStart >= 0)
    {
        var sectionEnd = solution.IndexOf("\tEndGlobalSection", sectionStart, StringComparison.Ordinal);
        if (sectionEnd < 0)
        {
            throw new InvalidOperationException("Could not find end of NestedProjects section.");
        }

        return solution.Insert(sectionEnd, $"\t\t{projectGuid} = {folderGuid}{Environment.NewLine}");
    }

    var solutionPropertiesStart = solution.IndexOf("\tGlobalSection(SolutionProperties)", StringComparison.Ordinal);
    if (solutionPropertiesStart < 0)
    {
        throw new InvalidOperationException("Could not find a place to add NestedProjects section.");
    }

    var nestedSection = $"""
	GlobalSection(NestedProjects) = preSolution
		{projectGuid} = {folderGuid}
	EndGlobalSection
""";

    return solution.Insert(solutionPropertiesStart, nestedSection + Environment.NewLine);
}
