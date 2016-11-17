using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    public enum Color { WHITE, BLACK };

    class Game
    {
        protected enum State { GAME, GAMEOVER, NOGAME };

        protected State gameState;
        protected CheckerBoard board;
        protected Player player1,
            player2,
            currentPlayer;

        public Game()
        {
            InitGame();
        }

        public void InitGame()
        {

            throw new NotImplementedException();

            // kolor dla gracza wylosowac
            // ustawic graczy, plansze stworzyc

        }

        public void Run()
        {
            while (gameState == State.GAME)
            {
                if (IsGameOver())
                    gameState = State.GAMEOVER;

                currentPlayer.Turn(board);
                //zmienia bierzacego gracza
            }
        }

        private bool IsGameOver()
        {
            throw new NotImplementedException();

        }

        private void AnnounceWinning()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Checkers");
        }
    }
}