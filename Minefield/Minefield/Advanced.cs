using System;
namespace Minefield
{
    public class Advanced : MinefieldClass
    {
        public Advanced()
        {
            Rows = 24;
            Columns = 24;
            Bombs = 99;
            Board = GenerateMinefield();
        }
    }
}
