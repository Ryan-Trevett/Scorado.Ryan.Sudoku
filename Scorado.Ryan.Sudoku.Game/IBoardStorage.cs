namespace Scorado.Ryan.Sudoku.Game
{
    public interface IBoardStorage
    {
        Board GetBoard();

        void Clear();
    }
}