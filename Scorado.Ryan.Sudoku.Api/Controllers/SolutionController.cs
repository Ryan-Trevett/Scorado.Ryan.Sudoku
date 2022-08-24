using Microsoft.AspNetCore.Mvc;
using Scorado.Ryan.Sudoku.Game;

namespace Scorado.Ryan.Sudoku.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        public int[,] Get()
        {
            var board = Storage.GetBoard();

            var solver = new BruteForceSolver(board);

            solver.Solve();

            return new int[9, 9];
        }
    }
}
