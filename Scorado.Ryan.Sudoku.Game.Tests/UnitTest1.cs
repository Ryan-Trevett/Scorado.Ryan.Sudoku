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

            var solver = new BruteForceSolver(board);

            solver.Solve();

            Console.WriteLine();
        }
    }
}