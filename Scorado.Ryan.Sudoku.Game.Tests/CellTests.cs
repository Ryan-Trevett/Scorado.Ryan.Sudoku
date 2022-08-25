namespace Scorado.Ryan.Sudoku.Game.Tests
{
    public class CellTests
    {
        [Test]
        public void Cell_ValueSet_ThrowsAnExceptionWhenPassedAnOutOfRangeCellValue ()
        {
            // Arrange
            var objectUnderTest = new Cell(0, 0);
            var invalidCellValue = -4;

            try
            {
                // Act
                objectUnderTest.Value = invalidCellValue;
            }
            catch (Exception)
            {
                // Assert
                Assert.Pass();
            }

            Assert.Fail();
        }

        [Test]
        public void Cell_ValueSet_DoesNotThrowAnExceptionWhenPassedAnInRangeCellValue()
        {
            // Arrange
            var objectUnderTest = new Cell(0, 0);
            var validCellValue = 4;

            try
            {
                // Act
                objectUnderTest.Value = validCellValue;
            }
            catch (Exception)
            {
                // Assert
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}
