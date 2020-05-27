using System;
using System.Collections.Generic;

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

        public char[,] HiddenBoard { get; set; } //hidden board has all the mines and values of adjacent tiles in it 
                                      //displays the board in a fancy way
        public void DisplayBoard(char[,] tempBoard)
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
                    Console.Write($" {tempBoard[i, j]} ".PadRight(4, '|'));
                }

                Console.WriteLine();
            }
        }
        public char[,] GenerateMinefield()
        {
            //initializing boards
            Board = new char[Rows, Columns];
            HiddenBoard = new char[Rows, Columns];

            //setting all values of Board = ? which are unknown cells
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Board[i, j] = '?'; //'?'= unknown cell,'!' = flagged cell, 'X' = bomb,
                                       //' ' = empty, '1','2','3','4' = adjacent blocks
                }
            }

            //setting all values for _HiddenBoard = ' '
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    HiddenBoard[i, j] = ' ';
                }
            }


            //Generate bombs in random unique positions in _HiddenBoard
            var random = new Random();
            for (int i = 0; i < Bombs; i++)
            {
                int x = random.Next(Rows);
                int j = random.Next(Columns);

                if (!(HiddenBoard[x, j] == 'X'))
                {
                    HiddenBoard[x, j] = 'X';
                    SetAdjacentValues(x,j);
                }
                else
                    i--;
            }

            return Board;
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
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
                        if (HiddenBoard[i, j] == ' ')
                            HiddenBoard[i, j] = '1';
                        else if (HiddenBoard[i, j] > (char)48 && HiddenBoard[i, j] < (char)58)//ASCII
                            HiddenBoard[i, j] = (char)(HiddenBoard[i, j] + 1);
                    }
                }
            }

        }

        //I think this checks selected cell for bombs and returns bool value
        public bool CheckCell()
        {
            throw new NotImplementedException();
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
