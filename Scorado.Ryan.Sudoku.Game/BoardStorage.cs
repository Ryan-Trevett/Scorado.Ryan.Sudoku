using System.Runtime.Caching;

namespace Scorado.Ryan.Sudoku.Game
{
    public class BoardStorage : IBoardStorage
    {
        /// <summary>
        /// Currently there is only one board. This could be expanded to many boards per user by using this key
        /// </summary>
        private static readonly string cacheKeyForOnlyBoard = "ryan-first";

        public Board GetBoard()
        {
            var cache = MemoryCache.Default;

            var board = (Board)cache.Get(cacheKeyForOnlyBoard);

            if (board == null)
            {
                var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddDays(1) };

                board = new Board(true);

                cache.Set(cacheKeyForOnlyBoard, board, policy);
            }

            return board;
        }

        public void Clear()
        {
            MemoryCache.Default.Remove(cacheKeyForOnlyBoard);
        }
    }
}
