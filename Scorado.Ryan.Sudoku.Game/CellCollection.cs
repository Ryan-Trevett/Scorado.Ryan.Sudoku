using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public class CellCollection
    {
        private Cell[] m_collection = new Cell[9];      // The acuall collection of cells
        private CellCollectionTypes m_collectionType;   // Column, Row or Box
        private int m_collectionIndex = 0;           // 0 - 8 position of the collection on the board

        public CellCollection(Cell[] collection_, ushort collectionIndex_, CellCollectionTypes collectionType_)
        {
            SetCells(collection_, collectionIndex_, collectionType_);
        }

        public CellCollection()
        { }

        public Cell this[ushort index]
        {
            get
            {
                return m_collection[index];
            }
        }

        public int CollectionIndex
        {
            get
            {
                return m_collectionIndex;
            }
        }

        public CellCollectionTypes CollectionType
        {
            get
            {
                return m_collectionType;
            }
        }

        public void SetCells(Cell[] collection_, int collectionIndex_, CellCollectionTypes collectionType_)
        {
            if (collection_.GetLength(0) != 9)
                throw new Exception("Cell collection assignment out of range");

            if (collectionIndex_ > 8)
                throw new Exception("Cell collection assignment out of range");

            m_collection = collection_;

            m_collectionIndex = collectionIndex_;

            m_collectionType = collectionType_;
        }
    }
}
