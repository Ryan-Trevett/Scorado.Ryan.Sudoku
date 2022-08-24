namespace Scorado.Ryan.Sudoku.Game.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //var one = Storage.GetBoard();
            //var two = Storage.GetBoard();#
            var board = new Board(true);

            board[7, 0].Value = 4;
            board[7, 0].PuzzleCell = true;


            board[0, 1].Value = 5;
            board[0, 1].PuzzleCell = true;


            board[5, 1].Value = 9;
            board[5, 1].PuzzleCell = true;


            board[4, 2].Value = 1;
            board[4, 2].PuzzleCell = true;


            board[6, 2].Value = 7;
            board[6, 2].PuzzleCell = true;


            board[7, 2].Value = 8;
            board[7, 2].PuzzleCell = true;


            board[0, 3].Value = 6;
            board[0, 3].PuzzleCell = true;


            board[3, 3].Value = 5;
            board[3, 3].PuzzleCell = true;


            board[1, 4].Value = 8;
            board[1, 4].PuzzleCell = true;


            board[4, 4].Value = 4;
            board[4, 4].PuzzleCell = true;


            board[7, 4].Value = 1;
            board[7, 4].PuzzleCell = true;

            board[5, 5].Value = 3;
            board[5, 5].PuzzleCell = true;

            board[8, 5].Value = 2;
            board[8, 5].PuzzleCell = true;

            board[1, 6].Value = 7;
            board[1, 6].PuzzleCell = true;

            board[2, 6].Value = 4;
            board[2, 6].PuzzleCell = true;

            board[4, 6].Value = 8;
            board[4, 6].PuzzleCell = true;

            board[3, 7].Value = 6;
            board[3, 7].PuzzleCell = true;

            board[8, 7].Value = 3;
            board[8, 7].PuzzleCell = true;

            board[1, 8].Value = 2;
            board[1, 8].PuzzleCell = true;

            var solver = new BruteForceSolver(board);

            solver.Solve();

            Console.WriteLine();
        }
    }
}