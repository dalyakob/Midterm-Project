using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Minefield!");

            var customMinefield = new CustomMinefield(10, 10, 10);

            customMinefield.DisplayBoard();

            Console.Write("\nWhat coords would you like to enter: ");

            var input= Console.ReadLine();

           
        }
    }
}
