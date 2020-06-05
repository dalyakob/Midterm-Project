using System;

namespace Minefield
{
    public class MinefieldClass : Grid
    {
        public MinefieldClass(int rows, int columns, int bombs) : base(rows,columns, bombs)
        {
            GameOver = false;
        }

        //Declaring public variables
        public bool GameOver { get; set; }

        public void GenerateMinefield()
        {
            //Generate bombs in random unique positions in _HiddenBoard
            var random = new Random();
            for (int i = 0; i < Bombs; i++)
            {
                int x = random.Next(Rows);
                int j = random.Next(Columns);

                if (!(_Board[x, j].Value == 'X'))
                {
                    _Board[x, j].Value = 'X';
                    SetAdjacentValues(x, j);
                    _Board[x, j].IsBomb = true;
                }
                else
                    i--;
            }
        }


        //I think this checks selected cell for bombs and returns bool value
        public void CheckCell(int row, int col)
        {

            if (!_Board[row, col].IsRevealed)
            {
                Moves move;
                bool valid;
                do
                {
                    Console.WriteLine($"What would you like to do with ({_Board[row, col].GetValue()}): \n(1) {Moves.flag} \n(2) {Moves.reveal}");

                    valid = Validation.ValidateMove(Console.ReadLine(), out move);
                } while (!valid);

                if (move == Moves.flag)
                {
                    //changes value of Board to "!"
                    //Toggle "flagged" status
                    if (_Board[row, col].IsFlagged)
                        _Board[row, col].IsFlagged = false;
                    else
                        _Board[row, col].IsFlagged = true;
                }
                else if (move == Moves.reveal)
                {
                    if (_Board[row, col].IsFlagged)
                        Console.WriteLine("This cell is flagged, try again!");

                    else if (_Board[row, col].IsBomb)
                    {
                        //change game status to GameOver
                        _Board[row, col].IsRevealed = true;
                        GameOver = true;
                    }
                    else
                    {
                        //set value of cell status to "revealed" 
                        _Board[row, col].IsRevealed = true;
                        RevealEmptyCells(row, col);
                    }
                }
            }
            else
                Console.WriteLine("This cell is already revealed.");

            //Continue playing
        }
       

        public void RevealEmptyCells(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i < 0 || j < 0 || i > Rows - 1 || j > Columns - 1)
                        continue;

                    if (_Board[i, j].Value == ' ' && !_Board[i, j].IsRevealed)
                    {
                        _Board[i, j].IsRevealed = true;
                        RevealEmptyCells(i, j);
                    }
                    else if (!_Board[i, j].IsBomb)
                        _Board[i, j].IsRevealed = true;
                    
                }
            }
        }

        //                                               row,column              B     R     T     L    BR    TL    TR    BL
        public void SetAdjacentValues(int row, int col) // 2,2 adjacent cells = 3,2 ; 2,3 ; 1,2 ; 2,1 ; 3,3 ; 1,1 ; 1,3 ; 3,1
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    //set adjacent values for...

                    if (i < 0 || j < 0 || i > Rows - 1 || j > Columns - 1)
                        continue;

                    if (_Board[i, j].Value == ' ')
                        _Board[i, j].Value = '1';
                    else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
                        _Board[i, j].Value = (char)(_Board[i, j].Value + 1);

                }
            }
        }
    }
}

            //set adjacent values for...

            //all rows and columns in the middle of the board
            //if (row > 0 && col > 0 && row < Rows - 1 && col < Columns - 1)
            //{
            //  for (int i = row - 1; i <= row + 1; i++)
            //  {
            //        for (int j = col - 1; j <= col + 1; j++)
            //        {
                        
            //            if (_Board[i, j].Value == ' ')
            //            {
            //                _Board[i, j].Value = '1';
            //            }
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
                        
            //        }
            //    }
            //}
            ////All columns on the TOP row except for corners
            //else if (row == 0 && col > 0 && col < Columns - 1)
            //{
            //    for (int i = 0; i <= 1; i++)
            //    {
            //        for (int j = col - 1; j <= col + 1; j++)
            //        {
            //            if (_Board[i, j].value = ' ') 
            //                _Board[i, j].Value = '1'; 

            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            ////All columns on the BOTTOM row except for corners
            //else if (row == Rows - 1 && col > 0 && col < Columns - 1)
            //{
            //    for (int i = row - 1; i <= row; i++)
            //    {
            //        for (int j = col - 1; j <= col + 1; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            ////All rows on the MOST LEFT column except for corners
            //else if (col == 0 && row > 0 && row < Rows - 1)
            //{
            //    for (int i = row - 1; i <= row + 1; i++)
            //    {
            //        for (int j = col; j <= col + 1; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            ////All rows on the MOST RIGHT column except for corners
            //else if (col == Columns - 1 && row > 0 && row < Rows - 1)
            //{
            //    for (int i = row - 1; i <= row + 1; i++)
            //    {
            //        for (int j = col - 1; j <= col; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            ////Top Left Corner
            //else if (row == 0 && col == 0)
            //{
            //    for (int i = 0; i <= 1; i++)
            //    {
            //        for (int j = 0; j <= 1; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            ////Top Right Corner 
            //else if (row == 0 && col == Columns - 1)
            //{
            //    for (int i = 0; i <= 1; i++)
            //    {
            //        for (int j = col - 1; j <= col; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            //// Bottom Left Corner
            //else if (row == Rows - 1 && col == 0)
            //{
            //    for (int i = row - 1; i <= row; i++)
            //    {
            //        for (int j = col; j <= col + 1; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}
            //// Bottom Right Corner
            //else if (row == Rows - 1 && col == Columns - 1)
            //{
            //    for (int i = row - 1; i <= row; i++)
            //    {
            //        for (int j = col - 1; j <= col; j++)
            //        {
            //            if (_Board[i, j].IsEmpty)
            //                _Board[i, j].Value = '1';
            //            else if (_Board[i, j].Value > (char)48 && _Board[i, j].Value < (char)58)//ASCII
            //                _Board[i, j].Value = (char)(_Board[i, j].Value + 1);
            //        }
            //    }
            //}

