using System;
using System.Collections.Generic;
using System.Text;

namespace MonopolyOdds
{
    internal class Solution
    {
        public static List<BoardSquare> CreateBoard()
        {
            return new List<BoardSquare>
            {
                new() { Index = 0,  Name = "GO",  Type = SquareType.Go },
                new() { Index = 1,  Name = "A1",  Type = SquareType.Property },
                new() { Index = 2,  Name = "CC1", Type = SquareType.CommunityChest },
                new() { Index = 3,  Name = "A2",  Type = SquareType.Property },
                new() { Index = 4,  Name = "T1",  Type = SquareType.Tax },
                new() { Index = 5,  Name = "R1",  Type = SquareType.Railroad },
                new() { Index = 6,  Name = "B1",  Type = SquareType.Property },
                new() { Index = 7,  Name = "CH1", Type = SquareType.Chance },
                new() { Index = 8,  Name = "B2",  Type = SquareType.Property },
                new() { Index = 9,  Name = "B3",  Type = SquareType.Property },

                new() { Index = 10, Name = "JAIL", Type = SquareType.Jail },
                new() { Index = 11, Name = "C1",   Type = SquareType.Property },
                new() { Index = 12, Name = "U1",   Type = SquareType.Utility },
                new() { Index = 13, Name = "C2",   Type = SquareType.Property },
                new() { Index = 14, Name = "C3",   Type = SquareType.Property },
                new() { Index = 15, Name = "R2",   Type = SquareType.Railroad },
                new() { Index = 16, Name = "D1",   Type = SquareType.Property },
                new() { Index = 17, Name = "CC2",  Type = SquareType.CommunityChest },
                new() { Index = 18, Name = "D2",   Type = SquareType.Property },
                new() { Index = 19, Name = "D3",   Type = SquareType.Property },

                new() { Index = 20, Name = "FP",   Type = SquareType.FreeParking },
                new() { Index = 21, Name = "E1",   Type = SquareType.Property },
                new() { Index = 22, Name = "CH2",  Type = SquareType.Chance },
                new() { Index = 23, Name = "E2",   Type = SquareType.Property },
                new() { Index = 24, Name = "E3",   Type = SquareType.Property },
                new() { Index = 25, Name = "R3",   Type = SquareType.Railroad },
                new() { Index = 26, Name = "F1",   Type = SquareType.Property },
                new() { Index = 27, Name = "F2",   Type = SquareType.Property },
                new() { Index = 28, Name = "U2",   Type = SquareType.Utility },
                new() { Index = 29, Name = "F3",   Type = SquareType.Property },

                new() { Index = 30, Name = "G2J",  Type = SquareType.GoToJail },
                new() { Index = 31, Name = "G1",   Type = SquareType.Property },
                new() { Index = 32, Name = "G2",   Type = SquareType.Property },
                new() { Index = 33, Name = "CC3",  Type = SquareType.CommunityChest },
                new() { Index = 34, Name = "G3",   Type = SquareType.Property },
                new() { Index = 35, Name = "R4",   Type = SquareType.Railroad },
                new() { Index = 36, Name = "CH3",  Type = SquareType.Chance },
                new() { Index = 37, Name = "H1",   Type = SquareType.Property },
                new() { Index = 38, Name = "T2",   Type = SquareType.Tax },
                new() { Index = 39, Name = "H2",   Type = SquareType.Property }
            };
        }

        private readonly Random random = new();
        public int Solve()
        {
            var board = CreateBoard();
            int doubleRollCount = 0;
            int currentPosition = 0;
            int newPosition = 0;
            int jailIndex = board.FindIndex(s => s.Type == SquareType.Jail);
            for (int i = 0; i < 1000000; i++)
            {
                int roll1 = random.Next(1, 5);
                int roll2 = random.Next(1, 5);
                int totalRoll = roll1 + roll2;
                if (roll1 == roll2)
                    doubleRollCount++;
                else
                    doubleRollCount = 0;

                if (doubleRollCount == 3)
                {
                    currentPosition = jailIndex;
                    board[jailIndex].VisitCount++;
                    doubleRollCount = 0;
                   
                    continue;
                }

                currentPosition =   FindNextPosition(board, currentPosition, totalRoll);
                board[currentPosition].VisitCount++;
            }
        
            board.Sort((a, b) => b.VisitCount.CompareTo(a.VisitCount));
            return 0;
        }


        int FindNextPosition(List<BoardSquare> board, int currentPosition, int totalRoll)
        {
            int newPosition = (currentPosition + totalRoll) % board.Count;

            while (true)
            {
                switch (board[newPosition].Type)
                {
                    case SquareType.GoToJail:
                        newPosition = 10;
                        return newPosition;

                    case SquareType.Chance:
                        int chanceMove = random.Next(1, 17);

                        switch (chanceMove)
                        {
                            case 1:
                                newPosition = 0;  // GO
                                return newPosition;

                            case 2:
                                newPosition = 10; // JAIL
                                return newPosition;

                            case 3:
                                newPosition = 11; // C1
                                return newPosition;

                            case 4:
                                newPosition = 24; // E3
                                return newPosition;

                            case 5:
                                newPosition = 39; // H2
                                return newPosition;

                            case 6:
                                newPosition = 5;  // R1
                                return newPosition;

                            case 7:
                            case 8:
                                newPosition = GetNextRailroad(newPosition);
                                return newPosition;

                            case 9:
                                newPosition = GetNextUtility(newPosition);
                                return newPosition;

                            case 10:
                                newPosition = (newPosition - 3 + board.Count) % board.Count;
                                continue; // Çünkü back 3 CC gibi özel kareye denk gelebilir

                            default:
                                return newPosition;
                        }

                    case SquareType.CommunityChest:
                        int communityChestMove = random.Next(1, 17);

                        switch (communityChestMove)
                        {
                            case 1:
                                newPosition = 0;  // GO
                                return newPosition;

                            case 2:
                                newPosition = 10; // JAIL
                                return newPosition;

                            default:
                                return newPosition;
                        }

                    default:
                        return newPosition;
                }
            }
        }

        private static int GetNextRailroad(int position)
        {
            if(position < 5)
                return 5;
            else if (position < 15)
                return 15;
            else if (position < 25)
                return 25;
            else if (position < 35)
                return 35;
            else
                return 5; // Wrap around to the first railroad
        }

        private static int GetNextUtility(int position)
        {
            if(position < 12)
                return 12;
            else if (position < 28)
                return 28;
            else
                return 12; // Wrap around to the first utility)
        }

    }


    

    class BoardSquare
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public SquareType Type { get; set; }

        public int VisitCount { get; set; } = 0;
    }

    public enum SquareType
    {
        Go,
        Property,
        CommunityChest,
        Chance,
        Tax,
        Railroad,
        Utility,
        Jail,
        FreeParking,
        GoToJail
    }


}