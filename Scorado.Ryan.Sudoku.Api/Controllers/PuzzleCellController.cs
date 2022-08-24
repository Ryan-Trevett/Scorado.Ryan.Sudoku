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

            var one = Storage.GetBoard();
            var two = Storage.GetBoard();


            return true;
        }
    }
}
