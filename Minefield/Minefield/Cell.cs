using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    public class Cell
    {
        public int RowEntry { get; set; }
        public int ColEntry { get; set; }
        public bool IsBomb { get; set; }
        public int AdjacentBombs { get; set; }
        public bool Uncovered { get; set; }
        public bool Flagged { get; set; }

        public Cell(int rowEntry, int colEntry)
        {
            rowEntry = RowEntry;
            colEntry = ColEntry;
        }
    }
}
