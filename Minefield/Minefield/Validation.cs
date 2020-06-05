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

    }

}

