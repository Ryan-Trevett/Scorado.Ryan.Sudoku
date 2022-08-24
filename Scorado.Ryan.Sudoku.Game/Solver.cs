using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public abstract class Solver
    {
        #region Member Variables
        protected Board m_board;
        protected ushort m_xPos = 0; // Used for the step by step solver to display on the UI
        protected ushort m_yPos = 0; // Used for the step by step solver to display on the UI
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        protected Solver()
        {
        }

        /// <summary>
        /// Takes a sudoku board as a parameter
        /// </summary>
        /// <param name="board_"></param>
        protected Solver(Board board_)
        {
            m_board = board_;
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        /// <summary>
        /// Solves the m_board in one go. Must be overriden in an inheriated class
        /// </summary>
        public virtual void Solve()
        {

        }

        /// <summary>
        /// Performs one step of the solving m_board.
        /// </summary>
        /// <returns>True when the puzzle is complete</returns>
        public virtual bool SolveStep()
        {
            return false;
        }

        /// <summary>
        /// Resets the position of the current seach
        /// Used with the SolveStep method
        /// </summary>
        public virtual void ResetPositions()
        {
            m_xPos = 0;
            m_yPos = 0;
        }

        /// <summary>
        /// Check to see if setting the value_ to the passed co-ordinates will break any of the game constraints
        /// </summary>
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        /// <param name="value_"></param>
        /// <returns></returns>
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
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        /// <param name="value_"></param>
        /// <param name="collectionType_"></param>
        /// <returns></returns>
        protected virtual bool CheckParticularConstraint(int xPos_, int yPos_, int? value_, CellCollectionTypes collectionType_)
        {
            CellCollection rowCollection = FindCollection(xPos_, yPos_, collectionType_);

            return CheckValueGoodInCollection(rowCollection, value_);
        }

        /// <summary>
        /// Returns the cell collection that the passed cell is in
        /// Dependant on the cell collection type passed
        /// </summary>
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        /// <param name="collectionType_"></param>
        /// <returns></returns>
        protected virtual CellCollection FindCollection(int xPos_, int yPos_, CellCollectionTypes collectionType_)
        {
            foreach (CellCollection col in m_board.Collection)
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

            return null;
        }

        /// <summary>
        /// Checks the value does not have a duplicate in the current collection
        /// </summary>
        /// <param name="collection_"></param>
        /// <param name="value_"></param>
        /// <returns></returns>
        protected virtual bool CheckValueGoodInCollection(CellCollection collection_, int? value_)
        {
            for (ushort i = 0; i < 9; i++)
            {
                if (collection_[i].Value == value_)
                    return false;
            }

            return true;
        }
        #endregion
    }
}
