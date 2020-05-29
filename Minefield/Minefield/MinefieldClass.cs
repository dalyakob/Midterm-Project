using System;
using System.Collections.Generic;

namespace Minefield
{
    public abstract class MinefieldClass 
    {
        public MinefieldClass()
        {
            _Board = new Cell[Rows, Columns];
        }

        //Declaring public variables
      
        private Cell[,] _Board { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Bombs { get; set; }

        //Displays the board in a fancy way
        public void DisplayBoard()
        {
            Console.Write("    ");
            for (int i = 0; i < Columns; i++)
            {
                Console.Write($" {i + 1}".PadRight(4));
            }

            Console.WriteLine();

            for (int i = 0; i < Columns + 1; i++)
            {
                if (i >= 1)
                    Console.Write("____");
                else
                    Console.Write("    ");
            }

            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                if(i < 9)
                    Console.Write($" {i + 1} ".PadRight(4, '|'));
                else
                    Console.Write($" {i + 1}".PadRight(4, '|'));


                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($" {_Board[i, j].GetValue()} ".PadRight(4, '|'));
                }

                Console.WriteLine();
            }
        }
        

        public int[,] Cell { get; set; }
        public int RowLocation { get; set; }
        public int ColLocation { get; set; }

        public void GenerateMinefield()
        { 
            //Generate bombs in random unique positions in _HiddenBoard
            var random = new Random();
            for (int i = 0; i < Bombs; i++)
            {
                int x = random.Next(Rows);
                int j = random.Next(Columns);

                if (_Board[x,j].Value == 'X')
                {
                    _Board[x, j].Value = 'X';
                    SetAdjacentValues(x,j);
                }
                else
                    i--;
            }
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

            //if(revealedCell == "X")
            //{
            //    Console.Write("You hit a mine!! GAME OVER!!");
            //    //change game status to GameOver
            //}
            //else
            //{
            //    //Continue playing
            //}
            return false;
        }
                                                         // row,column              B     R     T     L    BR    TL    TR    BL
        public void SetAdjacentValues(int row, int column) // 2,2 adjacent cells = 3,2 ; 2,3 ; 1,2 ; 2,1 ; 3,3 ; 1,1 ; 1,3 ; 3,1
        {
            //set adjacent values for...

            //all rows and columns in the middle of the board
            if (row > 0 && column > 0  && row < Rows-1 && column < Columns-1)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //All columns on the TOP row except for corners
            else if (row == 0 && column > 0 && column < Columns - 1)
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value> (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //All columns on the BOTTOM row except for corners
            else if (row == Rows-1 && column > 0 && column < Columns - 1)
            {
                for (int i = row-1; i <= row; i++)
                {
                    for (int j = column - 1; j <= column + 1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //All rows on the MOST LEFT column except for corners
            else if (column == 0 && row > 0 && row < Rows - 1)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column; j <= column + 1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //All rows on the MOST RIGHT column except for corners
            else if (column == Columns - 1 && row > 0 && row < Rows - 1)
            {
                for (int i = row - 1; i <= row + 1; i++)
                {
                    for (int j = column - 1; j <= column; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //Top Left Corner
            else if (row == 0 && column == 0) 
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = 0; j <= 1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            //Top Right Corner 
            else if (row == 0 && column == Columns-1) 
            {
                for (int i = 0; i <= 1; i++)
                {
                    for (int j = column-1; j <= column; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            // Bottom Left Corner
            else if (row == Rows-1 && column == 0) 
            {
                for (int i = row-1; i <= row; i++)
                {
                    for (int j = column; j <= column+1; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
            }
            // Bottom Right Corner
            else if (row == Rows - 1 && column == Columns-1)
            {
                for (int i = row - 1; i <= row; i++)
                {
                    for (int j = column-1; j <= column; j++)
                    {
                        if (_Board[i, j].Value == ' ')
                            _Board[i, j].Value = '1';
                        else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                            _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                    }
                }
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
