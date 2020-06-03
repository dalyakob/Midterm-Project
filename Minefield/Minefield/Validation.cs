using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    class Validation
    {
        public static ValidateLevel(string )
        {
            do
            {
                //insert Adreynne's code here
            } while (validLevel == false);
        }

        public static int ValidateCoords(string[] input)
        {
            input = Console.ReadLine().Split(',');
            int x = 0;
            int y = 0; 
            bool resultRow = int.TryParse(input[0], out x);
            bool resultColumn = int.TryParse(input[1], out y);
            while((resultRow = false) || (resultColumn = false))
            {
                Console.Write("Please enter valid coords (x, y): ");
                input = Console.ReadLine().Split(',');
             
            }return x & y;

            //validate to make sure x & y aren't more than the number of rows/columns in game
        }    
    

        public static Moves ValidateMove(string response)
        {
            Moves validMove;

            while (!Enum.TryParse<Moves>(response, true, out validMove))
            {
                Console.Write("Please enter a valid move: ");
                response = Console.ReadLine();
            }
            return validMove;
        }    
    }
}
