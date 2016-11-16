using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Config;
namespace Checkers
{
    public struct Position
    {
        public int x, y;
        public bool IsPositionInRange()
        {
            if (x < 0 || y < 0 || x >= Cfg.board_size || y >= Cfg.board_size)
                return false;
            return true;
        }
    }
}
