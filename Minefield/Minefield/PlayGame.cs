using System;
namespace Minefield
{
    public class PlayGame
    {
        public static void Play(MinefieldClass minefield)
        { 
            minefield.GenerateMinefield();
            minefield.DisplayBoard();

            

            while (!minefield.GameOver && !Validation.WonGame(minefield))
            {
                Console.ForegroundColor = ConsoleColor.Gray;

                int row, col;

                //user input for coordinants
                bool valid;
                do
                {
                    Console.Write("\n Enter coordinates(ex: 0,0): ");
                    valid = Validation.ValidateCoords(Console.ReadLine(), out row, out col, minefield);

                } while (!valid);

                Console.Clear();

                minefield.CheckCell(row, col);

                Console.ResetColor();

                //DisplayBoard has its own color scheme in the Grid class
                minefield.DisplayBoard();

            }

            //Win/loss conditions

            if (minefield.GameOver)
            {
                Console.WriteLine();

                minefield.DisplayHiddenBoard();

                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("\nYou hit a mine... GAME OVER!!");

                Console.ResetColor();
            }

            else
            {
                Console.WriteLine();

                minefield.DisplayHiddenBoard();

                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("\nYOU WINN!!!");

                Console.ResetColor();
            }
        }

    }
}
