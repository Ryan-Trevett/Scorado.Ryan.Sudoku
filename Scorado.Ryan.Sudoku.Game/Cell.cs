using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public class Cell
    {
        private int? m_Value = null;  // 1- 9 with null as unassigned

        // 1- 9 with null as unassigned
        public int? Value
        {
            get
            {
                return m_Value;
            }
            set
            {
                if (value > 9 || value == 0)
                {
                    throw new Exception("Cell assignment out of range");
                }

                if (m_triedValues.Contains(value))
                {
                    m_Value = null;
                }
                else
                {
                    m_Value = value;

                    m_triedValues.Add(value);                   
                }
            }
        }

        // x position in grid can only be 0 - 9
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }

        public bool PuzzleCell { get; set; }

        private List<int?> m_triedValues = new List<int?>();

        public Cell(int xPos_, int yPos_)
        {
            //if (xPos_ > 10 || yPos_ > 10)
            //{
            //    throw new Exception("Cell assignment out of range");
            //}

            Value = null;

            

           XPosition = xPos_;
            YPosition = yPos_;
        }

        public void ResetTriedValues()
        {
            m_triedValues.Clear();
        }
    }
}