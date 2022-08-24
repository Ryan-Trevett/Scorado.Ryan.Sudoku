using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public class Board
    {
        private Cell[,] m_board = new Cell[9, 9];
        //private Control.ControlCollection m_controls;
        private CellCollection[] m_cellCollections = new CellCollection[27];

        public Board(bool initialise_)
        {
            if (initialise_)
                InitialiseEmptyBoard();
        }

        public Cell this[int xPos_, int yPos_]
        {
            get
            {
                return m_board[xPos_, yPos_];
            }
        }

        /// <summary>
        /// Returns all the Cell Collections
        /// </summary>
        public CellCollection[] Collection
        {
            get
            {
                return m_cellCollections;
            }
        }

        /// <summary>
        /// Read only - Actual board of 9,9 
        /// </summary>
        public Cell[,] InnerBoard
        {
            get
            {
                return m_board;
            }
        }

        private void InitialiseEmptyBoard()
        {
            // Board main
            CreateBoardMain();

            // Collections
            // Columns
            CreateColumnCollections();

            // Rows
            CreateRowCollections();

            // Boxes - Manual assignation
            CreateBoxCollections();
        }

        private void CreateBoardMain()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    m_board[i, j] = new Cell(i, j);
                }
            }
        }

        private void CreateColumnCollections()
        {
            for (int i = 0; i < 9; i++)
            {
                Cell[] cellsToSet = new Cell[9];

                for (int j = 0; j < 9; j++)
                {
                    cellsToSet[j] = m_board[i, j];
                }

                m_cellCollections[i] = new CellCollection();
                m_cellCollections[i].SetCells(cellsToSet, i, CellCollectionTypes.Columns);
            }
        }

        private void CreateRowCollections()
        {
            for (ushort i = 9; i < 18; i++)
            {
                Cell[] cellsToSet = new Cell[9];

                for (int j = 0; j < 9; j++)
                {
                    cellsToSet[j] = m_board[j, i - 9];
                }

                int collectionIndex = (int)(i - 9);

                m_cellCollections[i] = new CellCollection();
                m_cellCollections[i].SetCells(cellsToSet, collectionIndex, CellCollectionTypes.Rows);
            }
        }

        /// <summary>
        /// Creates all the boxes -- assigns 9 cells in a box to a box collection
        /// </summary
        private void CreateBoxCollections()
        {
            int i = 0;
            int j = 0;

            for (int n = 18; n < 27; n++)
            {
                switch (n)
                {
                    case 19:
                        i = 3;
                        j = 0;
                        break;
                    case 20:
                        i = 6;
                        j = 0;
                        break;
                    case 21:
                        i = 0;
                        j = 3;
                        break;
                    case 22:
                        i = 3;
                        j = 3;
                        break;
                    case 23:
                        i = 6;
                        j = 3;
                        break;
                    case 24:
                        i = 0;
                        j = 6;
                        break;
                    case 25:
                        i = 3;
                        j = 6;
                        break;
                    case 26:
                        i = 6;
                        j = 6;
                        break;
                    default:
                        i = 0;
                        j = 0;
                        break;
                }

                Cell[] box = new Cell[9];

                box[0] = m_board[i, j];
                box[1] = m_board[i + 1, j];
                box[2] = m_board[i + 2, j];
                box[3] = m_board[i, j + 1];
                box[4] = m_board[i + 1, j + 1];
                box[5] = m_board[i + 2, j + 1];
                box[6] = m_board[i, j + 2];
                box[7] = m_board[i + 1, j + 2];
                box[8] = m_board[i + 2, j + 2];

                int collectionIndex = (int)(n - 18);

                m_cellCollections[n] = new CellCollection();
                m_cellCollections[n].SetCells(box, collectionIndex, CellCollectionTypes.Boxes);
            }
        }

        public void SetPuzzleCells()
        {
            for (int yPos = 0; yPos < 9; yPos++)
            {
                for (int xPos = 0; xPos < 9; xPos++)
                {
                    if (m_board[xPos, yPos].Value != null)
                        m_board[xPos, yPos].PuzzleCell = true;
                }
            }
        }
    }
}
