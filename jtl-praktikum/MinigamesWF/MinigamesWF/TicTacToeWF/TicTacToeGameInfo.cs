using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinigamesWF.TicTacToeWF
{
    class GameInfo
    {
        private int Turn;
        private Players ActivePlayer;
        private int PlayerXScore;
        private int PlayerOScore;
        private string PlayerXName;
        private string PlayerOName;

        public GameInfo()
        {
            Turn = 1;
            ActivePlayer = Players.PlayerX;
            PlayerXScore = 0;
            PlayerOScore = 0;
            PlayerXName = "X";
            PlayerOName = "O";
        }
        //Setze Werte von letzer Partie zurück
        public void ResetGameData()
        {
            Turn = 1;
            ActivePlayer = Players.PlayerX;
            PlayerXScore = 0;
            PlayerOScore = 0;
        }
        public void NewTurn()
        {
            Turn++;
        }
        public int GetTurn()
        {
            return Turn;
        }
        public void ResetActivePlayer()
        {
            ActivePlayer = Players.PlayerX;
        }
        public void SwitchActivePlayer()
        {
            switch (ActivePlayer)
            {
                case Players.PlayerX:
                    ActivePlayer = Players.PlayerO;
                    break;
                case Players.PlayerO:
                    ActivePlayer = Players.PlayerX;
                    break;
            }
        }
        public Players GetActivePlayer()
        {
            return ActivePlayer;
        }

        public void UpdatePlayerScore()
        {
            switch (ActivePlayer)
            {
                case Players.PlayerX:
                    PlayerXScore++;
                    break;
                case Players.PlayerO:
                    PlayerOScore++;
                    break;
            }
        }
        public int GetPlayerScore(Players Player)
        {
            switch (Player)
            {
                case Players.PlayerX:
                    return PlayerXScore;
                case Players.PlayerO:
                    return PlayerOScore;
            }
            return 0;
        }
        public void SetNewPlayerName(Players Player, string Name)
        {
            switch (Player)
            {
                case Players.PlayerX:
                    PlayerXName = Name;
                    break;
                case Players.PlayerO:
                    PlayerOName = Name;
                    break;
            }
        }
        public string GetPlayerName(Players Player)
        {
            switch (Player)
            {
                case Players.PlayerX:
                    return PlayerXName;
                case Players.PlayerO:
                    return PlayerOName;
            }
            return "";
        }
        public string GetActivePlayerName()
        {
            return GetPlayerName(ActivePlayer);
        }
    }
}
