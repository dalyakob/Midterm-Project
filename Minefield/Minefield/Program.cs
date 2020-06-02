using System;

namespace Minefield
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minefield!");


            MinefieldClass minefield;
            minefield = new MinefieldClass(9,9,10);
            //adryenne
            //ask user if he would like to play (1)beginner, (2)intermediate, (3)advaced or (4)custom with an enum
            //check using an if or switch statement for enum
            //create an object of MinefieldClass with specified rows, columns, and bombs
            //the instance must be called minefield for all four cases 
            
                minefield.GenerateMinefield();
                minefield.DisplayBoard();

                while(!minefield.GameOver)
                {
                    int row, column;
                    try
                    {
                        Console.Write("\n Enter coordinates(ex: 0,0): ");
                        var input = Console.ReadLine().Split(',');

                        row = int.Parse(input[0]);
                        column = int.Parse(input[1]);

                    }
                    catch (Exception)
                    {
                        Console.Write("\n Error, Invalid Coord please try again!");
                        continue;
                    }

                    minefield.SelectCell(row - 1, column - 1);
                    minefield.CheckCell(row - 1, column - 1);
                
                    minefield.DisplayBoard();
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
*  Generates board with given conditions  
*/
