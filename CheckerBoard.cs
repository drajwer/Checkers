using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public class CheckerBoard
    {
        public Piece[,] board;
        public Piece this[Position pos]
        {
            get
            {
                if(!pos.IsPositionInRange())
                    throw new IndexOutOfRangeException();
                return board[pos.x, pos.y];
            }
        }
        public Piece this[int x, int y]
        {
            get
            {
                Position pos = new Position(x, y);
                if (!pos.IsPositionInRange())
                    throw new IndexOutOfRangeException();
                return board[x, y];
            }
        }
        public CheckerBoard()
        {
            //ustawia pionki w board
            throw new NotImplementedException();
        }

        public void DrawBoard(Player player)
        { throw new NotImplementedException(); }
    }
}
