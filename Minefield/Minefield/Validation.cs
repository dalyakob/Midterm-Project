using System;

namespace Minefield
{
    class Validation
    {
        public static bool ValidateLevel(string response, out Levels level)
        {
            var valid = Enum.TryParse(response, out level);

            if (!valid)
                Console.WriteLine("\nInvalid Entry, Please Try Again!\n");

            return valid;
        }

        public static bool ValidateCustom(string input, out int row, out int col, out int bombs)
        {
            var custom = input.Split(',');

            if (custom.Length != 3)
            {
                row = 0;
                col = 0;
                bombs = 0;

                Console.WriteLine("Invalid Entry, Please Try Again");
                return false;
            }

            bool x = int.TryParse(custom[0], out row);
            bool y = int.TryParse(custom[1], out col);
            bool z = int.TryParse(custom[2], out bombs);

            int minBombs = Convert.ToInt32((row * col) * .12);
            int maxBombs = Convert.ToInt32((row * col) * .40);
            if (row < 5 || col < 5 || bombs < minBombs || row > 40 || col > 40 || bombs > maxBombs)
            {
                Console.WriteLine("\nInvalid Entry, must follow these guidelines:\n" +
                                  "1 - Row/Column min = 5,\n" +
                                  "2 - Row/Column max = 40\n" +
                                  "3 - Bomb min = 12% of grid size\n" +
                                  "4 - Bomb max = 40% of grid size\n");
                return false;
            }

            return x && y && z;
        }

        public static bool ValidateCoords(string input, out int row, out int col, MinefieldClass minefield)
        {
            var coords = input.Split(',');

            if (coords.Length != 2)
            {
                row = 0;
                col = 0;
                Console.WriteLine("\nInvalid Entry, Please Try Again!\n");
                return false;
            }

            bool x = int.TryParse(coords[0], out row);
            bool y = int.TryParse(coords[1], out col);
            row--;
            col--;

            if (row < 0 || col < 0 || row >= minefield.Rows || col >= minefield.Columns)
            {
                Console.WriteLine("\nInvalid Entry, Please Try Again!\n");
                return false;
            }

            return x && y;
        }

        public static bool ValidateMove(string response, out Moves validMove)
        {
            var valid = Enum.TryParse<Moves>(response, out validMove);

            if (!valid)
                Console.WriteLine("\nInvalid Entry, Please Try Again!\n");

            return valid;
        }

        public static bool WonGame(MinefieldClass minefieldClass)
        {
            var countsBombs = 0;
            for (int i = 0; i < minefieldClass.Rows; i++)
            {
                for (int j = 0; j < minefieldClass.Columns; j++)
                {
                    if (!minefieldClass.Board[i, j].IsRevealed && !minefieldClass.Board[i, j].IsFlagged)
                        return false;
                    else if (minefieldClass.Board[i, j].IsBomb && minefieldClass.Board[i, j].IsFlagged)
                        countsBombs++;
                }
            }
            if (countsBombs == minefieldClass.Bombs)
                return true;
            return false;
        }
    }

}

