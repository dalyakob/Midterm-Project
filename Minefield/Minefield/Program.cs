using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minefield!\n");

            bool valid; //used for validation throughout main
            Levels level;
            do
            {
                Console.WriteLine($"Would you like to play " +
                                 $"\n(1){Levels.Beginner} - 9x9: 10 Bombs" +
                                 $"\n(2){Levels.Intermediate} - 16x16: 40 Bombs" +
                                 $"\n(3){Levels.Advanced} - 24x24: 99 Bombs " +
                                 $"\n(4){Levels.Custom}");
                valid = Validation.ValidateLevel(Console.ReadLine().ToLower(), out level);
            } while (!valid);

            MinefieldClass minefield = null;

            switch (level)
            {
                case Levels.Beginner:
                    minefield = new MinefieldClass(9, 9, 10);
                    break;

                case Levels.Intermediate:
                    minefield = new MinefieldClass(16, 16, 40);
                    break;

                case Levels.Advanced:
                    minefield = new MinefieldClass(24, 24, 99);
                    break;

                case Levels.Custom:
                    Console.WriteLine("Board Size (ex: 0,0): ");
                    minefield = new MinefieldClass(9, 9, 10);
                    break;

            }



            minefield.GenerateMinefield();
            minefield.DisplayBoard();

            while(!minefield.GameOver || !minefield.WonGame())
            {
                int row, col;
                do
                {
                    Console.Write("\n Enter coordinates(ex: 0,0): ");
                    valid = Validation.ValidateCoords(Console.ReadLine(), out row, out col, minefield);
                } while (!valid);
              
                minefield.CheckCell(row, col);
                minefield.DisplayBoard();
            }
        }
    }
}
/*
*  ___Requires Different Sizes___
*  beginner     9x9
*  intermediate 16x16
*  advanced     24x24
*  custom       size x size
*
*  
*  _____Requires Bomb Amount_____
*  beginner = 10
*  intermediate = 40
*  advanced = 99
*  custom - give this option for all board sizes
*           and overwrite pre-initialized values
*           
*  Generates board with given conditions  
*/
