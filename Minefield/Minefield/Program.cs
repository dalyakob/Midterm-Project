using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Minefield!");
            var customMinefield = new CustomMinefield(5,10,10);
            customMinefield.DisplayBoard();
        }
    }
}
