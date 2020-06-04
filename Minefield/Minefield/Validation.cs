using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    class Validation
    {
        //public static ValidateLevel(string )
        //{
        //    do
        //    {
        //        //insert Adreynne's code here
        //    } while (validLevel == false);


        public static bool ValidateCoords(string input, out int row, out int col, MinefieldClass minefield)
        {
            var coords = input.Split(',');

            if (coords.Length != 2)
            {
                row = 0;
                col = 0;
                Console.WriteLine("Invalid Entry, Please Try Again");
                return false;
            }

            bool x = int.TryParse(coords[0], out row);
            bool y = int.TryParse(coords[1], out col);
            row--;
            col--;

            if (row < 0 || col < 0 || row >= minefield.Rows || col >= minefield.Columns)
            {
                Console.WriteLine("Invalid Entry, Please Try Again");
                return false;
            }

            return x && y;
        }

        public static bool ValidateMove(string response, out Moves validMove)
        {
            return Enum.TryParse<Moves>(response, out validMove);
        }
    }
}

