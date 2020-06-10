using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Welcome to Minefield!\n");
            Console.ResetColor();

            bool valid; //used for validation throughout main
            Levels level;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Would you like to play " +
                                 $"\n(1){Levels.Beginner} - 9x9: 10 Bombs" +
                                 $"\n(2){Levels.Intermediate} - 16x16: 40 Bombs" +
                                 $"\n(3){Levels.Advanced} - 24x24: 99 Bombs " +
                                 $"\n(4){Levels.Custom}");
                Console.ResetColor();
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
                    int row, col, bombs;
                    do
                    {
                        Console.Write("\n Enter Rows, Columns, Bombs (ex. 0,0,0): ");
                        valid = Validation.ValidateCustom(Console.ReadLine().Trim(), out row , out col, out bombs);
                    } while (!valid);
                    minefield = new MinefieldClass(row, col, bombs);
                    break;

            }

            PlayGame.Play(minefield);
        }
    }
}
