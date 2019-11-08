using System;

//TicTacToe
//Erst konsole dann WinForms
//Koordinaten erst 1-9 dann (1,1) - (3,3)

namespace TicTacToeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Koordinaten auf dem Spielfeld:\n{0}\n", TicTacToeSpielfeld.GetSpielfeldKoordinaten());
            while (true)
            {
                TicTacToeGame game = new TicTacToeGame();
                game.Start();
            }
        }
    }
    class TicTacToeGame
    {
        Players activePlayer;
        TicTacToeSpielfeld Feld;
        public TicTacToeGame()
        {
            this.activePlayer = Players.None;
        }
        //Neues Tic-Tac-Toe Spiel wird gestartet
        public void Start()
        {
            Console.WriteLine("Starte neue Runde...\n");
            this.Feld = new TicTacToeSpielfeld();
            this.activePlayer = Players.SpielerX;
            Console.Write(this.Feld.GetSpielfeldString());
            while (this.activePlayer != Players.None)
            {
                (int indexX, int indexY) = GetUserInput();

                if (this.Feld.SetNewFeldOwner(--indexX, --indexY, this.activePlayer))
                {
                    Console.WriteLine("Der Spieler {0} hat das Feld {1}:{2} ausgewählt.", 
                        PlayerToString(this.activePlayer), ++indexX, ++indexY);
                    switch (this.Feld.TestForWin(this.activePlayer, indexX, indexY))
                    {
                        case TicTacToeSpielfeld.MoveResult.None:
                            break;
                        case TicTacToeSpielfeld.MoveResult.Win:
                            Console.Write(this.Feld.GetSpielfeldString());
                            Console.WriteLine("Der Spieler {0} hat die Runde gewonnen!\n", PlayerToString(this.activePlayer));
                            this.activePlayer = Players.None;
                            return;
                    }
                    Console.Write(Feld.GetSpielfeldString());
                    switch (this.activePlayer)
                    {
                        case Players.SpielerX:
                            this.activePlayer = Players.SpielerO;
                            break;
                        case Players.SpielerO:
                            this.activePlayer = Players.SpielerX;
                            break;
                    }
                } else
                {
                    Console.WriteLine("Dieses Feld kann nicht ausgewählt werden!");
                }
            }
        }
        public (int,int) GetUserInput()
        {
            String userInput;
            int indexX, indexY;
            bool isXSet = false, isYSet = false;
            //Wenn zweimal falsch eingegeben IndexOutOfBounds von SetNewFeldOwner
            do
            {
                Console.Write("Spieler {0} X-Koordinate:", PlayerToString(this.activePlayer));
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out indexX))
                {
                    isXSet = true;
                }
            } while (!isXSet);
            do
            {
                Console.Write("Spieler {0} Y-Koordinate:", PlayerToString(this.activePlayer));
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out indexY))
                {
                    isYSet = true;
                }
            } while (!isYSet);
            return (indexX, indexY);
        }
        private string PlayerToString(Players Player)
        {
            switch (Player)
            {
                case Players.SpielerX:
                    return "X";
                case Players.SpielerO:
                    return "O";
                case Players.None:
                    return "";
            }
            return "";
        }
    }
    class TicTacToeSpielfeld
    {
        private int moves;
        public enum MoveResult { Win, Draw, None};
        private Players[,] Spielfeld;
        public TicTacToeSpielfeld()
        {
            this.moves = 0;
            this.Spielfeld = new Players[3,3] { { Players.None, Players.None, Players.None },
                                              { Players.None, Players.None, Players.None },
                                              { Players.None, Players.None, Players.None } };
        }

        //Neuer Besitzer des Feldes am index wird festgelegt.
        //Boolean true => Neuer Besitzer wurde festgelegt, 
        //Boolean false => Feld ist bereits besetzt.
        public bool SetNewFeldOwner(int indexX, int indexY, Players newFeldOwner)
        {
            if (this.Spielfeld[indexX, indexY] == Players.None)
            {
                this.Spielfeld[indexX, indexY] = newFeldOwner;
                this.moves++;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Überprüft ob der aktive Spieler einen Siegeszug ausgeführt hat
        //Trift dies beim neunten Zug immer noch nicht zu wird MoveResult.Draw zurückgegeben
        public MoveResult TestForWin(Players activePlayer, int indexX, int indexY)
        {
            indexX -= 1;
            indexY -= 1;
            //Überprüfe Reihen auf 3 in einer Reihe
            bool previousOwned = false;
            for (int y = 0; y < 3; y++)
            {
                if (this.Spielfeld[indexX, y] != activePlayer)
                {
                    previousOwned = false;
                    break;
                } else
                {
                        previousOwned = true;
                }
            }
            if (previousOwned)
            {
                return MoveResult.Win;
            }
            //Überprüfe Spalten auf 3 in einer Reihe
            previousOwned = false;
            for (int x = 0; x < 3; x++)
            {
                if (this.Spielfeld[x, indexY] != activePlayer)
                {
                    previousOwned = false;
                    break;
                } else
                {
                    previousOwned = true;
                }
                    
            }
            if (previousOwned)
            {
                return MoveResult.Win;
            }
            //Überprüfe diagonale Felder
            if (this.Spielfeld[0, 0] == activePlayer && 
                this.Spielfeld[1, 1] == activePlayer && 
                this.Spielfeld[2, 2] == activePlayer)
            {

                return MoveResult.Win;
            }
            if (this.Spielfeld[0, 2] == activePlayer &&
                this.Spielfeld[1, 1] == activePlayer &&
                this.Spielfeld[2, 0] == activePlayer)
            {
                return MoveResult.Win;
            }
            if (this.moves == 9)
            {
                return MoveResult.Draw;
            }
            return MoveResult.None;
        }
        
        //Wandelt Inhalt des Feldes am index zu String um
        private string StrFeldAtIndex(int indexX, int indexY)
        {
            switch(this.Spielfeld[indexX, indexY])
            {
                case Players.None:
                    return " ";
                case Players.SpielerX:
                    return "X";
                case Players.SpielerO:
                    return "O";
            }
            return "";
        }
        //Spielfeld wird zu String umgewandelt
        public string GetSpielfeldString()
        {
            return string.Format("+---+---+---+\n| {0} | {1} | {2} |\n" +
                                 "+---+---+---+\n| {3} | {4} | {5} |\n" +
                                 "+---+---+---+\n| {6} | {7} | {8} |\n" +
                                 "+---+---+---+\n",
                                 StrFeldAtIndex(0, 0), StrFeldAtIndex(0, 1), StrFeldAtIndex(0, 2),
                                 StrFeldAtIndex(1, 0), StrFeldAtIndex(1, 1), StrFeldAtIndex(1, 2),
                                 StrFeldAtIndex(2, 0), StrFeldAtIndex(2, 1), StrFeldAtIndex(2, 2));
        }
        //Beispielhafte Darstellung von möglichen Koordinaten
        public static string GetSpielfeldKoordinaten()
        {
            return "+---+---+---+\n|1,1|1,2|1,3|\n" +
                   "+---+---+---+\n|2,1|2,2|2,3|\n" +
                   "+---+---+---+\n|3,1|3,2|3,3|\n" +
                   "+---+---+---+\n";
        }
    }
    enum Players { None, SpielerX, SpielerO };
}
