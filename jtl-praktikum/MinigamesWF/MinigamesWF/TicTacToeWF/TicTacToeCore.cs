using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigamesWF.TicTacToeWF
{
    class TicTacToeCore
    {
        private Players[,] Board;
        private int Moves;

        public TicTacToeCore()
        {
            Board = new Players[3, 3];
            Moves = 0;
        }
        public void ResetBoard()
        {
            Board = new Players[3, 3];
            Moves = 0;
        }
        public bool SetNewTileOwner(Coordinates Coords, Players ActivePlayer)
        {
            if (Board[Coords.X, Coords.Y] == Players.None)
            {
                Board[Coords.X, Coords.Y] = ActivePlayer;
                Moves++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public TurnResult TestForWin(Coordinates Coords, Players ActivePlayer)
        {
            bool previousOwned = false;
            //Überprüfe horizontale Reihe
            for (int i = 0; i < 3; i++)
            {
                if (Board[Coords.X, i] == ActivePlayer)
                {
                    previousOwned = true;
                }
                else
                {
                    previousOwned = false;
                    break;
                }
            }

            if (previousOwned)
            {
                return TurnResult.Win;
            }

            //Überprüfe vertikale Reihe
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, Coords.Y] == ActivePlayer)
                {
                    previousOwned = true;
                }
                else
                {
                    previousOwned = false;
                    break;
                }
            }

            if (previousOwned)
            {
                return TurnResult.Win;
            }

            //Überprüfe diagonale Felder
            if (Board[0, 0] == ActivePlayer &&
                Board[1, 1] == ActivePlayer &&
                Board[2, 2] == ActivePlayer)
            {

                return TurnResult.Win;
            }
            if (Board[0, 2] == ActivePlayer &&
                Board[1, 1] == ActivePlayer &&
                Board[2, 0] == ActivePlayer)
            {
                return TurnResult.Win;
            }

            if (Moves == 9)
            {
                return TurnResult.Draw;
            }

            return TurnResult.None;
        }
    }

    //Mögliche Werte für Spieler
    enum Players
    {
        None,
        PlayerX,
        PlayerO,
    }

    //Mögliche Werte für Rundenausgang
    enum TurnResult
    {
        None,
        Win,
        Draw,
    }
    //Koordinaten für TicTacToeCore
    public struct Coordinates
    {
        public readonly int X;
        public readonly int Y;

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int ToIndex()
        {
            return X * Y;
        }
    }
}