namespace Scorado.Ryan.Sudoku.Game.Tests
{
    /// <summary>
    /// Long running tests, will actually solve a problem
    /// </summary>
    public class IntegrationTests
    {
        /// <summary>
        /// https://sandiway.arizona.edu/sudoku/examples.html
        /// The not fun example
        /// </summary>
        [Test]
        public void TestASolutionFoundOnTheInternet()
        {  
            // Arrange
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

            var solver = new BruteForceSolver
            {
                Board = board
            };

            // Act
            solver.Solve();

            // Assert the top row
            Assert.That(board[0, 8].Value, Is.EqualTo(1));
            Assert.That(board[1, 8].Value, Is.EqualTo(2));
            Assert.That(board[2, 8].Value, Is.EqualTo(6));
            Assert.That(board[3, 8].Value, Is.EqualTo(4));
            Assert.That(board[4, 8].Value, Is.EqualTo(3));
            Assert.That(board[5, 8].Value, Is.EqualTo(7));
            Assert.That(board[6, 8].Value, Is.EqualTo(9));
            Assert.That(board[7, 8].Value, Is.EqualTo(5));
            Assert.That(board[8, 8].Value, Is.EqualTo(8));            
        }
    }
}