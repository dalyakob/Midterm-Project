using System;
namespace Minefield
{
    public abstract class MinefieldClass
    {
        public MinefieldClass()
        {
        }

        // Declaring public variables
        public char[,] Board { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }

        //hidden board has all the mines and values of adjacent tiles in it 
        private char[,] _hiddenBoard;

        public char[,] GenerateMinefield()
        {
            Board = new char[Rows, Columns];

            //setting all values of board = ? which are unknown tiles
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Board[i, j] = '?';
                }
            }

            //generate bombs to hidden board here
            var random = new Random();

            return Board;
        }

        //I think this checks selected cell for bombs and returns bool value
        public bool CheckCell()
        {
            throw new NotImplementedException();
        }

        //displays the board in a fancy way
        public void DisplayBoard()
        {
            Console.Write("\t|");

            for (int i = 0; i < Columns; i++)
            {
                Console.Write($"\t{i + 1}");
            }

            Console.WriteLine();

            for (int i = 0; i < Columns + 1; i++)
            {
                if (i >= 1)
                    Console.Write("________");
                else
                    Console.Write("\t");
            }

            Console.WriteLine("_");

            for (int i = 0; i < Rows; i++)
            {
                Console.Write($"{i + 1}\t|\t");

                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(Board[i, j] + "\t");
                }

                Console.WriteLine();
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
*  Generates board with given conditions set it equal to Board 
*/
