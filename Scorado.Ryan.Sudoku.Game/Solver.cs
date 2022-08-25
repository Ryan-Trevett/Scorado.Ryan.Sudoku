namespace Scorado.Ryan.Sudoku.Game
{
    public abstract class Solver
    {
        public Solver()
        {
            Board = new Board(false);
        }

        public Board Board { get; set; }

        public abstract void Solve();          
        
        public virtual bool CheckConstraints(int xPos_, int yPos_, int? value_)
        {
            if (!CheckParticularConstraint(xPos_, yPos_, value_, CellCollectionTypes.Rows))
                return false;

            if (!CheckParticularConstraint(xPos_, yPos_, value_, CellCollectionTypes.Columns))
                return false;

            if (!CheckParticularConstraint(xPos_, yPos_, value_, CellCollectionTypes.Boxes))
                return false;

            return true;
        }

        /// <summary>
        /// Used to help check game constrainsts for any cell collection type
        /// </summary>      
       
        protected virtual bool CheckParticularConstraint(int xPos_, int yPos_, int? value_, CellCollectionTypes collectionType_)
        {
            CellCollection rowCollection = FindCollection(xPos_, yPos_, collectionType_);

            return CheckValueGoodInCollection(rowCollection, value_);
        }

        /// <summary>
        /// Returns the cell collection that the passed cell is in
        /// Dependant on the cell collection type passed
        /// </summary>        
        protected virtual CellCollection FindCollection(int xPos_, int yPos_, CellCollectionTypes collectionType_)
        {
            foreach (CellCollection col in Board.Collection)
            {
                if (col.CollectionType == collectionType_)
                {
                    for (ushort i = 0; i < 9; i++)
                    {
                        if (col[i].XPosition == xPos_ && col[i].YPosition == yPos_)
                            return col;
                    }
                }
            }

#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }

        /// <summary>
        /// Checks the value does not have a duplicate in the current collection
        /// </summary>       
        protected virtual bool CheckValueGoodInCollection(CellCollection collection_, int? value_)
        {
            for (ushort i = 0; i < 9; i++)
            {
                if (collection_[i].Value == value_)
                    return false;
            }

            return true;
        }       
    }
}
