using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scorado.Ryan.Sudoku.Game;

namespace Scorado.Ryan.Sudoku.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuzzleCellController : ControllerBase
    {
        // Addition params of user and specific board if using more than one
        public bool Post(int value, int xPosition, int yPosition)
        {
            // Check params

            // Check if board initialised

            var board = Storage.GetBoard();

            

            if (!board[xPosition, yPosition].PuzzleCell)
            {
                var solver = new BruteForceSolver(board);

                if (solver.CheckConstraints(xPosition, yPosition, value))
                {
                    board[xPosition, yPosition].Value = value;
                    board[xPosition, yPosition].PuzzleCell = true;
                }
                else
                {
                    return false;
                    //lblMessage.Text = "Invalid cell value";
                }
            }         

            return true;
        }
    }
}
