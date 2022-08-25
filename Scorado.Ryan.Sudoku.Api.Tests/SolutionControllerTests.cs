using Moq;
using Scorado.Ryan.Sudoku.Api.Controllers;
using Scorado.Ryan.Sudoku.Game;

namespace Scorado.Ryan.Sudoku.Api.Tests
{
    public class SolutionControllerTests
    {    
        [Test]
        public void SolutionController_Get_CallsBoardStorageGetBoard()
        {
            // Arrange
            var boardStorageMock = new Mock<IBoardStorage>();
            boardStorageMock.Setup(x => x.GetBoard()).Returns(new Board(true));
            var solverStub = new Mock<Solver>();

            var objectUnderTest = new SolutionController(boardStorageMock.Object, solverStub.Object);

            // Act
            objectUnderTest.Get();

            // Assert
            boardStorageMock.Verify(x => x.GetBoard(), Times.Once);
        }
    }
}