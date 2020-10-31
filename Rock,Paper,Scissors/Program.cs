using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors
{
    class RockPaperScissors
    {
        public string Player1;
        public string Player2;

        public int Player1_Score = 0;
        public int Player2_Score = 0;

        public int Round_Count = 0;

        public string[] ValidInput = { "R", "P", "S" };

        public int PaperCount = 0;
        public int RockCount = 0;
        public int ScissorsCount = 0;

        public string GameType;
        public string[] ValidGameTypes = { "1", "2" };

    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            RockPaperScissors rps = new RockPaperScissors();

            do
            {
                Console.WriteLine("Select Game Mode: AI [1], Player VS Player [2]:");
                rps.GameType = Console.ReadLine();
            } while (!rps.ValidGameTypes.Contains(rps.GameType));

            while (rps.Player1_Score != 2 && rps.Player2_Score != 2) {

                do
                {
                    if (rps.GameType.Equals("1"))
                    {
                        Console.WriteLine("Player, choose Rock [R], Paper [P], or Scissors [S]: ");
                    }
                    else
                    {
                        Console.WriteLine("Player 1, choose Rock [R], Paper [P], or Scissors [S]: ");
                    }
                    rps.Player1 = Console.ReadLine().ToUpper();

                    if (rps.ValidInput.Contains(rps.Player1))
                    {
                        switch (rps.Player1)
                        {
                            case "R":
                                rps.RockCount++;
                                break;
                            case "P":
                                rps.PaperCount++;
                                break;
                            case "S":
                                rps.ScissorsCount++;
                                break;
                        }
                    }
                } while (!rps.ValidInput.Contains(rps.Player1));

                do
                {
                    if (rps.GameType.Equals("1"))
                    {
                        Random rnd = new Random();
                        int rIndex = rnd.Next(rps.ValidInput.Length);
                        rps.Player2 = rps.ValidInput[rIndex];

                        switch (rps.Player2)
                        {
                            case "R":
                                Console.WriteLine("Computer Chose Rock");
                                break;
                            case "P":
                                Console.WriteLine("Computer Chose Paper");
                                break;
                            case "S":
                                Console.WriteLine("Computer Chose Scissors");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Player 2, choose Rock [R], Paper [P], or Scissors [S]: ");
                        rps.Player2 = Console.ReadLine().ToUpper();

                        if (rps.ValidInput.Contains(rps.Player2))
                        {
                            switch (rps.Player2)
                            {
                                case "R":
                                    rps.RockCount++;
                                    break;
                                case "P":
                                    rps.PaperCount++;
                                    break;
                                case "S":
                                    rps.ScissorsCount++;
                                    break;
                            }
                        }

                    }
                } while (!rps.ValidInput.Contains(rps.Player2));

                if (rps.Player1.Equals(rps.Player2))
                {
                    Console.WriteLine("Draw");
                }
                else if ((rps.Player1.Equals("R") && rps.Player2.Equals("S")) ||
                    (rps.Player1.Equals("P") && rps.Player2.Equals("R")) ||
                    (rps.Player1.Equals("S") && rps.Player2.Equals("P")))
                {
                    Console.WriteLine("Player 1 Wins This Round");
                    rps.Player1_Score++;
                }
                else
                {
                    Console.WriteLine("Player 2 Wins This Round");
                    rps.Player2_Score++;
                }
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                rps.Round_Count++;
            }

            Console.WriteLine("Final stats");
            Console.WriteLine("-----------");
            if (rps.Player1_Score == 2)
            {
                Console.WriteLine("Player 1 Wins The Game");
            }
            else
            {
                Console.WriteLine("Player 2 Wins The Game");
            }

            Console.WriteLine("Rounds Played: " + rps.Round_Count);

            int MaxMoves = Math.Max(rps.PaperCount, Math.Max(rps.ScissorsCount, rps.RockCount));

            if (rps.PaperCount == MaxMoves)
            {
                Console.WriteLine("Paper Was The Most Used Move");
            }

            if (rps.ScissorsCount == MaxMoves)
            {
                Console.WriteLine("Scissors Was The Most Used Move");
            }

            if (rps.RockCount == MaxMoves)
            {
                Console.WriteLine("Rock Was The Most Used Move");
            }

            Console.WriteLine("Press Enter To Close...");
            Console.ReadLine();
        }
    }
}
