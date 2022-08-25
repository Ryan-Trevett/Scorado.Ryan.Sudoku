using Microsoft.AspNetCore.Mvc;
using Scorado.Ryan.Sudoku.Game;
using System.Security.Policy;

namespace Scorado.Ryan.Sudoku.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        public SolutionController(IBoardStorage boardStorage, Solver solver)
        {
            BoardStorage = boardStorage;
            Solver = solver;
        }

        public IBoardStorage BoardStorage { get; internal set; }
        public Solver Solver { get; internal set; }

        /// <summary>
        /// Get the solution for the current Sudoku problem
        /// TODO: There is currently only one problem in memory
        /// </summary>
        /// <returns></returns>
        public int?[][] Get()
        {  
            var board = BoardStorage.GetBoard();

            Solver.Board = board;

            Solver.Solve();

            BoardStorage.Clear();

            return ConvertBoardForResult(board);     
        }

        /// <summary>
        /// JSON serialiser doesn't support multidimensional arrays? convert to jagged array instead
        /// Possibly just the serialiser I'm using
        /// Also strip out unwanted data and use SharedCell
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private int?[][] ConvertBoardForResult(Board board)
        {
            int?[][] result = new int?[9][];
            result[0] = new int?[9];
            result[1] = new int?[9];
            result[2] = new int?[9];
            result[3] = new int?[9];
            result[4] = new int?[9];
            result[5] = new int?[9];
            result[6] = new int?[9];
            result[7] = new int?[9];
            result[8] = new int?[9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {                    
                    result[i][j] = board.BoardCells[i, j].Value;                   
                }
            }

            return result;
        }
    }
}
