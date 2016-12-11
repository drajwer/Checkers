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
            throw new NotImplementedException();
            //jesli attackFlag jest true to jesli jest bicie i destination jest oddalone o dwa zwraca true
            //jesli attackFlag jest false  to zwraca true jesli destination jest oddalone o jeden
        }

        public virtual bool CanAttack(CheckerBoard board)
        { throw new NotImplementedException();
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
    }

    public class Queen:Piece
    {
        public Queen(Color color, Position defaultPosition):base(color,defaultPosition)
            {}

        public override bool CanAttack(CheckerBoard board)
        { throw new NotImplementedException(); }

        public override bool IsCorrectDestination(bool attackFlag, Position destination, CheckerBoard board)
        { throw new NotImplementedException(); }
    }
}
