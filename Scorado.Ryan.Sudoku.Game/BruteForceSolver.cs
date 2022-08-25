namespace Scorado.Ryan.Sudoku.Game
{
    public  class BruteForceSolver : Solver
    {
        public BruteForceSolver()
            : base()
        {

        }   
        
        public override void Solve()
        {  
            BruteForceSolve();
        }

        /// <summary>
        /// Controlling method for solving the puzzle in one go using a backtracking algorithm
        /// </summary>
        private void BruteForceSolve()
        {
            for (int yPos = 0; yPos < 9; yPos++)
            {
                for (int xPos = 0; xPos < 9; xPos++)
                {
                    if (AttemptToSetCell(xPos, yPos, 1) == AttemptToSetReturnTypes.False)
                    {
                        ResetTriedValues(xPos, yPos);

                        // Move back a cell and increment - backtrack
                        IncrementPreviousCell(ref xPos, ref yPos);
                    }
                }
            }
        }
        
        private void IncrementPreviousCell(ref int xPos_, ref int yPos_)
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

            int? valueToTry;

            if (Board[xPos_, yPos_].Value != 9)
            {
                valueToTry = (Board[xPos_, yPos_].Value + 1);
            }
            else
            {
                valueToTry = 1;
            }

            // Check the new value and if it fails carry on backwards
            if (AttemptToSetCell(xPos_, yPos_, valueToTry) != AttemptToSetReturnTypes.True)
            {
                ResetTriedValues(xPos_, yPos_);

                // Backtrack again
                IncrementPreviousCell(ref xPos_, ref yPos_);
            }
        }
        
        private AttemptToSetReturnTypes AttemptToSetCell(int xPos_, int yPos_, int? value_)
        {
            // If this is a cell that is part of the puzzle itself
            // it must be correct so just return
            if (Board[xPos_, yPos_].PuzzleCell)
                return AttemptToSetReturnTypes.Puzzle;

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

                        return AttemptToSetReturnTypes.False;
                    }

                    return AttemptToSetReturnTypes.True;
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

            return AttemptToSetReturnTypes.False;
        }
       
        private void ResetTriedValues(int xPos_, int yPos_)
        {
            Board[xPos_, yPos_].ResetTriedValues();
        }       
    }
}
