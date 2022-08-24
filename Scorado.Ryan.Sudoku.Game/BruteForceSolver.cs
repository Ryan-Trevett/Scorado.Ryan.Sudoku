using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public  class BruteForceSolver : Solver
    {
        #region Member Variables
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BruteForceSolver()
            : base()
        {

        }

       #endregion

        #region Properties
        #endregion

        #region Methods       


        /// <summary>
        /// Attempts to solve the puzzle in one go
        /// </summary>
        public override void Solve()
        {
            base.Solve();

            BruteForceSolve();
        }

        /// <summary>
        /// Controlling method for solving the puzzle in one go using the backtracking algorithm
        /// </summary>
        private void BruteForceSolve()
        {
            for (ushort yPos = 0; yPos < 9; yPos++)
            {
                for (ushort xPos = 0; xPos < 9; xPos++)
                {
                    if (AttemptToSetCell(xPos, yPos, 1) == AttemptSetReturnTypes.False)
                    {
                        ResetTriedValues(xPos, yPos);

                        // Move back a cell and increment - backtrack
                        IncrementPreviousCell(ref xPos, ref yPos);
                    }
                }
            }
        }

        /// <summary>
        /// Backtrack
        /// </summary>
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        private void IncrementPreviousCell(ref ushort xPos_, ref ushort yPos_)
        {
            if (xPos_ == 0 && yPos_ == 0)
            {
                throw new Exception("Brute force solver error - can't move back");
            }

            // Move back one
            if (xPos_ != 0)
            {
                xPos_ -= 1;
            }
            else
            {
                xPos_ = 8;
                yPos_ -= 1;
            }

            ushort? valueToTry;

            if (Board[xPos_, yPos_].Value != 9)
            {
                valueToTry = (ushort?)(Board[xPos_, yPos_].Value + 1);
            }
            else
            {
                valueToTry = 1;
            }

            // Check the new value and if it fails carry on backwards
            if (AttemptToSetCell(xPos_, yPos_, valueToTry) != AttemptSetReturnTypes.True)
            {
                ResetTriedValues(xPos_, yPos_);

                // Backtrack again
                IncrementPreviousCell(ref xPos_, ref yPos_);
            }
        }

        /// <summary>
        /// Attempts to set a cell with a new value
        /// Carrys out checks to see whether this is a valid value for the cell
        /// </summary>
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        /// <param name="value_"></param>
        /// <returns></returns>
        private AttemptSetReturnTypes AttemptToSetCell(ushort xPos_, ushort yPos_, ushort? value_)
        {
            // If this is a cell that is part of the puzzle itself
            // it must be correct so just return
            if (Board[xPos_, yPos_].PuzzleCell)
                return AttemptSetReturnTypes.Puzzle;

            for (ushort n = 0; n < 9; n++)
            {
                if (CheckConstraints(xPos_, yPos_, value_))
                {
                    Board[xPos_, yPos_].Value = value_;

                    // If after setting the value above it was actually set to null
                    // this means the value has already been tried and we need to backtrack
                    if (Board[xPos_, yPos_].Value == null)
                    {
                        ResetTriedValues(xPos_, yPos_);

                        return AttemptSetReturnTypes.False;
                    }

                    return AttemptSetReturnTypes.True;
                }

                if (value_ == 9)
                {
                    value_ = 1;
                }
                else
                {
                    value_++;
                }
            }

            Board[xPos_, yPos_].Value = null;

            return AttemptSetReturnTypes.False;
        }

        /// <summary>
        /// Once a cell has been backtracked the list of values already tried for it needs to be reset
        /// </summary>
        /// <param name="xPos_"></param>
        /// <param name="yPos_"></param>
        private void ResetTriedValues(ushort xPos_, ushort yPos_)
        {
            Board[xPos_, yPos_].ResetTriedValues();
        }
        #endregion
    }
}
