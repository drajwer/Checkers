using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
   public class Piece
    {
        public Color pieceColor { get; } // Kacper: zmienilem pole na wlasciwosc tylko do odczytu, przydatne np w klasie player
        protected Position position;
        public Piece(Color color, Position defaultPosition)
        {
            pieceColor = color;
            position = defaultPosition;
        }

        public virtual bool IsCorrectDestination(bool attackFlag, Position destination, CheckerBoard board)
        {
            if (!destination.IsPositionInRange())
            {
                return false;
            }
            if (attackFlag)
            {
                return CheckAttack(board, destination);
            }
            else
            {
                int diffX = destination.x - position.x;
                int diffY = destination.y - position.y;
                if ((pieceColor == Color.WHITE && diffY == 1 && Math.Abs(diffX) == 1) 
                    || (pieceColor == Color.BLACK && diffY == -1 && Math.Abs(diffX) == 1))
                {
                    if (board[destination] == null)
                        return true;
                }
            }
            return false;
            //jesli attackFlag jest true to jesli jest bicie i destination jest oddalone o dwa zwraca true
            //jesli attackFlag jest false  to zwraca true jesli destination jest oddalone o jeden
        }

        public virtual bool CheckAttack(CheckerBoard board, Position destination)
        {
            // sprawdza czy wykonujac ruch na pozycje destination wystapi bicie
            if(!destination.IsPositionInRange())
            {
                return false;
            }
            int diffX = destination.x - position.x;
            int diffY = destination.y - position.y;
            Position attackedField = new Position(diffX < 0 ? position.x - 1 : position.x + 1, diffY < 0 ? position.y - 1 : position.y + 1);
            if((diffX == 2 || diffX == -2) && (diffY == 2 || diffY == -2)) // jesli destination jest o dwa pola na skos
            {
                if(board[destination] == null)
                {
                    if (board[attackedField] != null && board[attackedField].pieceColor != pieceColor)
                        return true;
                }
            }
            return false;
            
        }
        public virtual bool CanAttack(CheckerBoard board)
        {
            if (!position.IsPositionInRange())
            {
                throw new IndexOutOfRangeException();
            }
            return CheckAttack(board, position.NE().NE()) || CheckAttack(board, position.NW().NW()) || CheckAttack(board, position.SE().SE())
                    || CheckAttack(board, position.SW().SW());
           
            //sprawdza czy pionek ma bicie
        }

        public void Move(CheckerBoard board, Position to)
        { throw new NotImplementedException(); }

        public void RemovePiece(CheckerBoard board, List<Piece> pieces)
        { throw new NotImplementedException();
            //usuwa pionek z listy i z planszy
        }

        public bool IsBecomeQueen()
        { throw new NotImplementedException();
            //sprawdza czy pionek jest dama
        }

        public void ChangePieceToQueen(CheckerBoard board, List<Piece> pieces)
        { throw new NotImplementedException(); }

        public Piece FunkcjaCudzika(Position destination)
        {
            throw new NotImplementedException();
            //zwraca wystepujacego pionka ktory zostal przeskoczony podczas bicia
        }

        //4x funkcja sprawdzajaca po przekatnej 1 pole od siebie
        public override string ToString() // pomocnicza do wypisywania
        {
            if (Color.BLACK == pieceColor)
                return "#";
            return "@";
        }
    }

    public class Queen:Piece
    {
        public Queen(Color color, Position defaultPosition):base(color,defaultPosition)
            {}

        public override bool CheckAttack(CheckerBoard board, Position destination)
        {
            List<Piece> piecesBetweenDestAndPos = new List<Piece>();
            Position iterPosition = new Position(position.x, position.y);
            int directionX = destination.x > position.x ? 1 : -1;
            int directionY = destination.y > position.y ? 1 : -1;
            if(!destination.IsPositionInRange())
            {
                return false;
            }
            if(board[destination] != null)
            {
                return false;
            }
            if(Math.Abs(position.x - destination.x) < 2)
            {
                return false;
            }
            if(position.IsPositionOnBias(destination))
            { 
                while (iterPosition.x != destination.x) // wiemy ze jestesmy na przekatnej, porownujemy tylko x
                {
                    iterPosition.x += directionX;
                    iterPosition.y += directionY;
                    if (board[iterPosition] != null)
                    { 
                        piecesBetweenDestAndPos.Add(board[iterPosition]);
                    }
                }
            }
            if(piecesBetweenDestAndPos.Count == 1)
            {
                if (piecesBetweenDestAndPos[0].pieceColor != pieceColor)
                    return true;
            }
            return false;
        }
        public override bool CanAttack(CheckerBoard board)
        { throw new NotImplementedException(); }

        public override bool IsCorrectDestination(bool attackFlag, Position destination, CheckerBoard board)
        { throw new NotImplementedException(); }
    }
}

