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
        public int x { get; set; } // zmienilem na wlasciwosci
        public int y { get; set; }
        public Position(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
        public bool IsPositionInRange()
        {
            if (x < 0 || y < 0 || x >= Cfg.board_size || y >= Cfg.board_size)
                return false;
            return true;
        }

        // Dodalem pomocnicze funkcje do "chodzenia po planszy"
        public Position NE()
        {
            return new Position(x + 1, y + 1);
        }
        public Position NW()
        {
            return new Position(x - 1, y + 1);
        }
        public Position SE()
        {
            return new Position(x + 1, y - 1);
        }
        public Position SW()
        {
            return new Position(x - 1, y - 1);
        }
    }
}
