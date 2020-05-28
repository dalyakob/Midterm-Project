using System;
namespace Minefield
{

    //I think this may be better suited for the Custom size class
    public class Beginner : MinefieldClass
    {
        public int width = 0;
        public int height = 0;
        private int beginnerMines = 10;
          while (width <= 0)
        {
            width = GetWidth();
        WidthErrors(width);
    }

        while (height <= 0)
        {
            height = GetHeight();
    HeightErrors(height);
}

        while (mines <= 0)
        {
            mines = GetMines();
MinesErrors(mines);
        }

        Board = new GameBoard(width, height, mines);
    }

    public SingleGameSolver(GameBoard board, Random rand)
{
    Board = board;
    Random = rand;
}
}