namespace Scorado.Ryan.Sudoku.Game
{
    public class Board
    {
        private CellCollection[] cellCollections = new CellCollection[27];

        public Board(bool initialise_)
        {
            BoardCells = new Cell[9, 9];

            if (initialise_)
                InitialiseEmptyBoard();
        }

        public Cell[,] BoardCells { get; private set; }           

        public Cell this[int xPos_, int yPos_]
        {
            get
            {
                return BoardCells[xPos_, yPos_];
            }
        }
        
        public CellCollection[] Collection
        {
            get
            {
                return cellCollections;
            }
        }       

        private void InitialiseEmptyBoard()
        {           
            CreateBoardMain();           
            CreateColumnCollections();            
            CreateRowCollections();            
            CreateBoxCollections();
        }

        private void CreateBoardMain()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    BoardCells[i, j] = new Cell(i, j);
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
                    cellsToSet[j] = BoardCells[i, j];
                }

                cellCollections[i] = new CellCollection();
                cellCollections[i].SetCells(cellsToSet, i, CellCollectionTypes.Columns);
            }
        }

        private void CreateRowCollections()
        {
            for (int i = 9; i < 18; i++)
            {
                Cell[] cellsToSet = new Cell[9];

                for (int j = 0; j < 9; j++)
                {
                    cellsToSet[j] = BoardCells[j, i - 9];
                }

                int collectionIndex = (int)(i - 9);

                cellCollections[i] = new CellCollection();
                cellCollections[i].SetCells(cellsToSet, collectionIndex, CellCollectionTypes.Rows);
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

                box[0] = BoardCells[i, j];
                box[1] = BoardCells[i + 1, j];
                box[2] = BoardCells[i + 2, j];
                box[3] = BoardCells[i, j + 1];
                box[4] = BoardCells[i + 1, j + 1];
                box[5] = BoardCells[i + 2, j + 1];
                box[6] = BoardCells[i, j + 2];
                box[7] = BoardCells[i + 1, j + 2];
                box[8] = BoardCells[i + 2, j + 2];

                int collectionIndex = (int)(n - 18);

                cellCollections[n] = new CellCollection();
                cellCollections[n].SetCells(box, collectionIndex, CellCollectionTypes.Boxes);
            }
        }
        public void SetPuzzleCells()
        {
            for (int yPos = 0; yPos < 9; yPos++)
            {
                for (int xPos = 0; xPos < 9; xPos++)
                {
                    if (BoardCells[xPos, yPos].Value != null)
                        BoardCells[xPos, yPos].PuzzleCell = true;
                }
            }
        }
    }
}
