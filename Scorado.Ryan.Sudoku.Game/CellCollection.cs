namespace Scorado.Ryan.Sudoku.Game
{
    public class CellCollection
    {
        private Cell[] collection = new Cell[9];      // The acuall collection of cells
        private CellCollectionTypes collectionType;   // Column, Row or Box
        private int collectionIndex = 0;              // 0 - 8 position of the collection on the board   

        public Cell this[ushort index]
        {
            get
            {
                return collection[index];
            }
        }

        public int CollectionIndex
        {
            get
            {
                return collectionIndex;
            }
        }

        public CellCollectionTypes CollectionType
        {
            get
            {
                return collectionType;
            }
        }

        public void SetCells(Cell[] collection_, int collectionIndex_, CellCollectionTypes collectionType_)
        {
            if (collection_.GetLength(0) != 9)
                throw new Exception("Cell collection assignment out of range");

            if (collectionIndex_ > 8)
                throw new Exception("Cell collection assignment out of range");

            collection = collection_;

            collectionIndex = collectionIndex_;

            collectionType = collectionType_;
        }
    }
}
