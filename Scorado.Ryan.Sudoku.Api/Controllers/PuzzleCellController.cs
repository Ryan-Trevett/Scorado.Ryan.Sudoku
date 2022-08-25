using Microsoft.AspNetCore.Mvc;
using Scorado.Ryan.Sudoku.Game;

namespace Scorado.Ryan.Sudoku.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PuzzleCellController : ControllerBase
    {
        public PuzzleCellController(IBoardStorage boardStorage, Solver solver)
        {
            BoardStorage = boardStorage;
            Solver = solver;
        }

        public IBoardStorage BoardStorage { get; internal set; }
        public Solver Solver { get; internal set; }

        //TODO: Addition params of user and specific board need to be added later
        // Just asume one user and one board for now       
        public bool Post(int value, int xPosition, int yPosition)
        {
            //TODO: Extra check params here

            var board = BoardStorage.GetBoard();

            if (!board[xPosition, yPosition].PuzzleCell)
            {             
                Solver.Board = board;

                if (Solver.CheckConstraints(xPosition, yPosition, value))
                {
                    board[xPosition, yPosition].Value = value;
                    board[xPosition, yPosition].PuzzleCell = true;
                }
                else
                {              
                    throw new Exception("Invalid constraints");                                   
                }
            }
            else
            {             
                throw new Exception("Value already set");
            }

            return true;
        }
    }
}
