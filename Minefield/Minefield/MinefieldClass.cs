using System;

namespace Minefield
{
    public class MinefieldClass : Grid
    {
        public MinefieldClass(int rows, int columns, int bombs) : base(rows,columns, bombs)
        {
            GameOver = false;
        }
        public bool GameOver { get; set; }

        public void GenerateMinefield()
        {
            //Generate bombs in random unique positions in _HiddenBoard
            var random = new Random();
            for (int i = 0; i < Bombs; i++)
            {
                int x = random.Next(Rows);
                int j = random.Next(Columns);

                if (!(Board[x, j].Value == 'X'))
                {
                    Board[x, j].Value = 'X';
                    SetAdjacentValues(x, j);
                    Board[x, j].IsBomb = true;

                }
                else
                    i--;
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

                    if (Board[i, j].Value == ' ')
                        Board[i, j].Value = '1';
                    else if (Board[i, j].Value > (char)48 && Board[i, j].Value < (char)58)//ASCII
                        Board[i, j].Value = (char)(Board[i, j].Value + 1);

                }
            }
        }

        public void CheckCell(int row, int col)
        {
            if (!Board[row, col].IsRevealed)
            {
                Moves move;
                bool valid;
                do
                {
                    Console.WriteLine($"What would you like to do with ({Board[row, col].GetValue()}): \n(1) {Moves.reveal} \n(2) {Moves.flag}");

                    valid = Validation.ValidateMove(Console.ReadLine(), out move);
                } while (!valid);

                if (move == Moves.flag)
                {
                    //changes value of Board to "!"
                    //Toggle "flagged" status
                    if (Board[row, col].IsFlagged)
                        Board[row, col].IsFlagged = false;
                    else
                        Board[row, col].IsFlagged = true;
                }
                else if (move == Moves.reveal)
                {
                    if (Board[row, col].IsFlagged)
                        Console.WriteLine("This cell is flagged, try again!");

                    //if bomb end game
                    else if (Board[row, col].IsBomb)
                    {
                        Board[row, col].IsRevealed = true;
                        GameOver = true;
                    }
                    //if adjacent to bomb reveal only that cell
                    else if (Board[row, col].Value != ' ')
                        Board[row, col].IsRevealed = true;
                    else
                    {
                        //set value of cell status to "revealed" 
                        Board[row, col].IsRevealed = true;
                        RevealEmptyCells(row, col);
                    }
                }
            }
            else
                Console.WriteLine("This cell is already revealed.");

            Console.ResetColor();

            //Continue playing
        }
       
        //This function takes selected cell and checks if empty then reveal all adjacent cells
        //if another empty cell is found it calls this function again
        public void RevealEmptyCells(int row, int col)
        {
            for (int i = row - 1; i <= row + 1; i++)
            {
                for (int j = col - 1; j <= col + 1; j++)
                {
                    if (i < 0 || j < 0 || i > Rows - 1 || j > Columns - 1)
                        continue;

                    if (Board[i, j].Value == ' ' && !Board[i, j].IsRevealed)
                    {
                        Board[i, j].IsRevealed = true;
                        RevealEmptyCells(i, j);
                    }
                    else if (!Board[i, j].IsBomb)
                        Board[i, j].IsRevealed = true;
                    
                }
            }
        }
    }
}