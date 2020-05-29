using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield
{
    public class Cell
    {
        //required properties
        public int RowEntry { get; set; }
        public int ColEntry { get; set; }
        public char Value   { get; set; }

        //useful properties
        public bool IsBomb { get; set; }
        public int IsEmpty { get; set; }
        public bool IsRevealed { get; set; }
        public bool Flagged { get; set; }

        public Cell(int rowEntry, int colEntry)
        {
            RowEntry = rowEntry;
            ColEntry = colEntry;
            Value = ' ';
        }

        public char GetValue()
        {
            if (IsRevealed)
            {
                return Value;
            }
            else
                return '?';
        }
    }
}
