using System;

namespace Minefield
{
    public class Cell
    {
        //required properties
        public char Value { get; set; }

        //useful properties
        public bool IsBomb { get; set; }
        public bool IsRevealed { get; set; }
        public bool IsFlagged { get; set; }


        public Cell()
        {
            Value = ' ';

            IsBomb = false;
            IsRevealed = false;
            IsFlagged = false;
        }

        public char GetValue()
        {  
            if (IsFlagged)
                return '!';

            else if (IsRevealed)
                return Value;

            else
                return '?';

        }

        
    }
}