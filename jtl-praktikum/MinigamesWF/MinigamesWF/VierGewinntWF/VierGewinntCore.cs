using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigamesWF.VierGewinntWF
{
    class VierGewinntCore
    {
        private Player[,] Board;
        private int MoveCount;
        public VierGewinntCore()
        {
            Board = new Player[6,7];
        }

        public void ResetBoard()
        {
            Board = new Player[6, 7];
            MoveCount = 0;
        }

        //RowIndex gives the position of the Button in its Row => [?, RowIndex] Position of all Labels under Button
        public (bool, Coords) DropInColumn(int RowIndex, Player ActivePlayer)
        {
            int LowestPosition = -1;
            for (int i = 5; i >= 0; i--)
            {
                if (Board[i, RowIndex] == Player.None)
                {
                    LowestPosition = i;
                    break;
                }
            }
            if (LowestPosition > -1)
            {
                Coords Coords = new Coords(LowestPosition, RowIndex);
                Board[Coords.X, Coords.Y] = ActivePlayer;
                MoveCount++;
                return (true, Coords); 
            }
           return (false, new Coords());
        }

        //Überprüft ob jeweils drei Felder von Zug in jede Richtung durch den 
        //Zug 4 Felder vom selben Spieler in einer Reihe entstanden sind.
        public TurnResult TestForWin(Coords LastInserted, Player ActivePlayer)
        { 
            List<Player> Vertikal = CollectVertikal(LastInserted, ActivePlayer);
            List<Player> Horizontal = CollectHorizontal(LastInserted, ActivePlayer);
            List<Player> DiagonalRight = CollectDiagonalToRight(LastInserted, ActivePlayer);
            List<Player> DiagonalLeft = CollectDiagonalToLeft(LastInserted, ActivePlayer);
            if (Vertikal.Count >= 4 || Horizontal.Count >= 4 || 
                DiagonalRight.Count >= 4 || DiagonalLeft.Count >= 4)
            {
                return TurnResult.Win;
            }

            if (MoveCount >= 42)
            {
                return TurnResult.Draw;
            }

            return TurnResult.None;
        }

        public List<Player> CollectVertikal(Coords LastInserted, Player ActivePlayer)
        {
            Coords LICopy = LastInserted;
            List<Player> Vertikal = new List<Player>
            {
                ActivePlayer 
            };
            LICopy.X++; //Starte mit nächstem Feld
            for (int i = LICopy.X; i <= LastInserted.X + 3; i++)
            {
                //Wenn größer Fünf => Kein weiteres Label vorhanden
                if (i > 5)
                {
                    break;
                }
                if (Board[i, LICopy.Y] == ActivePlayer)
                {
                    Vertikal.Add(ActivePlayer);
                    continue;
                }
                else
                {
                    break;
                }
            }
            return Vertikal;
        }

        public List<Player> CollectHorizontal(Coords LastInserted, Player ActivePlayer)
        {
            Coords LICopy = LastInserted;
            List<Player> Horizontal = new List<Player>
            {
                ActivePlayer
            };
            LICopy.Y++;
            for (int i = LICopy.Y; i <= LastInserted.Y + 3; i++)
            {
                //Wenn größer Sechs => Kein weiteres Label vorhanden
                if (i > 6)
                {
                    break;
                }
                if (Board[LICopy.X, i] == ActivePlayer)
                {
                    Horizontal.Add(ActivePlayer);
                    continue;
                } else 
                {
                    break;
                }
            }

            LICopy = LastInserted;
            LICopy.Y--;
            for (int i = LICopy.Y; i >= LastInserted.Y - 3; i--)
            {
                if (i < 0)
                {
                    break;
                }
                if (Board[LICopy.X, i] == ActivePlayer)
                {
                    Horizontal.Insert(0, ActivePlayer); //Insert at beginning
                    continue;
                } else 
                {
                    break;
                }
            }

            return Horizontal;
        }

        public List<Player> CollectDiagonalToRight(Coords LastInserted, Player ActivePlayer)
        {
            Coords LICopy = LastInserted;
            List<Player> DiagonalRight = new List<Player>
            {
                ActivePlayer
            };
            LICopy.X++;
            LICopy.Y++;
            for (int i = LICopy.X; i <= LastInserted.X + 3; i++)
            {
                if (i > 5 || LICopy.Y > 6) 
                {
                    break;
                }
                if (Board[i, LICopy.Y] == ActivePlayer)
                {
                    DiagonalRight.Add(ActivePlayer);
                    LICopy.Y++;
                } else
                {
                    break;
                }
            }

            LICopy = LastInserted;
            LICopy.X--;
            LICopy.Y--;
            for (int i = LICopy.X; i >= LastInserted.X - 3; i--)
            {
                if (i < 0 || LICopy.Y < 0)
                {
                    break;
                }
                if (Board[i, LICopy.Y] == ActivePlayer)
                {
                    DiagonalRight.Insert(0, ActivePlayer);
                    LICopy.Y--;
                } else 
                {
                    break;
                }
            }

            return DiagonalRight;
        }

        public List<Player> CollectDiagonalToLeft(Coords LastInserted, Player ActivePlayer)
        {
            Coords LICopy = LastInserted;
            List<Player> DiagonalLeft = new List<Player>
            {
                ActivePlayer
            };
            LICopy.X--;
            LICopy.Y++;
            for (int i = LICopy.X; i >= LastInserted.X - 3; i--)
            {
                if (i < 0 || LICopy.Y > 6)
                {
                    break;
                }
                if (Board[i, LICopy.Y] == ActivePlayer)
                {
                    DiagonalLeft.Add(ActivePlayer);
                    LICopy.Y++;
                } else
                {
                    break;
                }
            }

            LICopy = LastInserted;
            LICopy.X++;
            LICopy.Y--;
            for (int i = LICopy.X; i <= LastInserted.X + 3; i++)
            {
                if (i > 5 || LICopy.Y < 0)
                {
                    break;
                }
                if (Board[i, LICopy.Y] == ActivePlayer)
                {
                    DiagonalLeft.Insert(0, ActivePlayer);
                    LICopy.Y--;
                } else
                {
                    break;
                }
            }
            return DiagonalLeft;
        }
    }

    //Enum zum Darstellen von Möglichen werten für Spieler
    enum Player
    {
        None, 
        PlayerOne,
        PlayerTwo,
    }

    //Enum für Mögliche Ausgangswerte für einzelne Runden
    enum TurnResult
    {
        None,
        Win,
        Draw,
    }

    //Struct für Koordinaten zur Verwendung mit 2-Dimensionalen Arrays
    public struct Coords
    {
        public int X;
        public int Y;
        public Coords(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
