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
        
        private char[,] _hiddenBoard; //hidden board has all the mines and values of adjacent tiles in it 

        public int[,] Cell { get; set; }
        public int RowLocation { get; set; }
        public int ColLocation { get; set; }

        public char[,] GenerateMinefield()
        {
            Board = new char[Rows, Columns];
            _hiddenBoard = new char[Rows, Columns];
            //setting all values of board = ? which are unknown cells
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Board[i, j] = '?';// '!' = flag, 'x' = bomb, ' ' = empty, '1','2','3','4' = adjacent blocks
                }
            }

            //generate bombs to hidden board here
            var random = new Random();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _hiddenBoard[i, j] = ' ';
                }
            }

            return Board;
        }

        public void SelectCell()
        {
            Cell = new int[RowLocation, ColLocation];
           
            Console.Write($"What would you link to do with ({Cell}): flag or reveal?");
            var selectedCell = Console.ReadLine();
            if(selectedCell == "flag")
            {
                //change value of Board to "!"
                //set value of cell status to "flagged"- bool value? Enum?
            }
            else if(selectedCell =="reveal")
            {
                //change value of Board to cell index value for _hiddenBoard
                //call this 'revealedCell'?
                //set value of cell status to "revealed" bool value? Enum?
            }
        }

        //I think this checks selected cell for bombs and returns bool value
        public bool CheckCell()
        {
            //revealedCell  = cell value from _hiddenBoard;

            if(revealedCell == "X")
            {
                Console.Write("You hit a mine!! GAME OVER!!");
                //change game status to GameOver
            }
            else
            {
                //Continue playing
            }
            
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
