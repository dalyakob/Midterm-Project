using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minefield!");

            var customMinefield = new CustomMinefield(10, 10, 10);
            
                customMinefield.GenerateMinefield();
                customMinefield.DisplayBoard();

                bool valid;
                while(!customMinefield.GameOver)
                {
                    Console.Write("\n Enter coordinates: (ex: 0,0) ");
                    var input = Console.ReadLine().Split(',');
                    try
                    {
                        valid = int.TryParse(input[0], out var row);
                        valid = int.TryParse(input[1], out var column) && valid;

                        customMinefield.SelectCell(row - 1, column - 1);
                        customMinefield.CheckCell(row - 1, column - 1);

                        if (!valid)
                        {
                            Console.Write("\n Error, Invalid Coord please try again!");
                            continue;
                        }
                        customMinefield.DisplayBoard();
                    }
                    catch (IndexOutOfRangeException)
                    {
                        Console.Write("\n Error, Invalid Coord please try again!");
                        continue;
                    }
                }
        }
    }
}