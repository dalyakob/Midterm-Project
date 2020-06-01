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
        public bool IsEmpty { get; set; }

        public Cell()
        {
            Value = ' ';

            IsBomb = false;
            IsRevealed = false;
            IsFlagged = false;
            IsEmpty = true;
        }

        public char GetValue()
        {
            if (IsRevealed)
                return Value;
            else if (IsFlagged)
                return '!';
            else
                return '?';
        }
    }
}