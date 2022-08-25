namespace Scorado.Ryan.Sudoku.Game
{
    public class Cell
    {
        private int? cellValue = null;
        private List<int?> triedValues = new List<int?>();

        public Cell(int xPos_, int yPos_)
        {
            Value = null;
            XPosition = xPos_;
            YPosition = yPos_;
        }

        public int? Value
        {
            get
            {
                return cellValue;
            }
            set
            {
                if (value > 9 || value == 0)
                {
                    throw new Exception("Cell assignment out of range");
                }

                if (triedValues.Contains(value))
                {
                    cellValue = null;
                }
                else
                {
                    cellValue = value;

                    triedValues.Add(value);                   
                }
            }
        }
        
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }

        public bool PuzzleCell { get; set; }    

        public void ResetTriedValues()
        {
            triedValues.Clear();
        }
    }
}