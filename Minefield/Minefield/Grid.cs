using System;
using System.Drawing;

namespace Minefield
{
    public abstract class Grid 
    {
        public Grid(int rows, int columns, int bombs)
        {
            Rows = rows;
            Columns = columns;
            Bombs = bombs;

            //Generate board size
            _Board = new Cell[Rows, Columns];

            //initialize board 
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {

                    _Board[i, j] = new Cell();
                }
            }
        }

        protected Cell[,] _Board;

        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }

        //Displays the board in a fancy way
        public void DisplayBoard()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("    ");
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($" {i + 1}".PadRight(4));
            }

            Console.WriteLine();

            for (int i = 0; i < Columns + 1; i++)
            {
                if (i >= 1)
                    Console.Write("----");
                else
                    Console.Write("    ");
            }

            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                if (i < 9)
                    Console.Write($" {i + 1} ".PadRight(4, '|'));
                else
                    Console.Write($" {i + 1}".PadRight(4, '|'));


                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($" {_Board[i, j].GetValue()} ".PadRight(4, '|'), Color.AliceBlue);
                }
                Console.WriteLine();

            }
            for (int i = 0; i < Columns + 1; i++)
            {
                if (i >= 1)
                    Console.Write("----");
                else
                    Console.Write("    ");
            }
            Console.WriteLine();
        }
    }
}
