using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace Scorado.Ryan.Sudoku.Game
{
    public static class Storage
    {
        public static Board GetBoard()
        {
            var cache = MemoryCache.Default;

            var board = (Board)cache.Get("ryan-first");

            if (board == null)
            {
                var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddDays(1) };

                board = new Board(true);

                cache.Set("ryan-first", board, policy);               
            }

            return board;
        }

       

    }
}
