using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MinigamesWF.VierGewinntWF
{
    class GameInfo
    {
        private int Round;
        private Player ActivePlayer;
        private string PlayerOneName;
        private Color PlayerOneColor;
        private string PlayerTwoName;
        private Color PlayerTwoColor;
        private int PlayerOneScore;
        private int PlayerTwoScore;

        public GameInfo()
        {
            Round = 1;
            ActivePlayer = Player.PlayerOne;
            PlayerOneName = "Player One";
            PlayerOneColor = Color.Red;
            PlayerTwoName = "Player Two";
            PlayerTwoColor = Color.Yellow;
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }

        public void ResetRoundData()
        {
            Round = 1;
            ActivePlayer = Player.PlayerOne;
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }

        public void IncrementRound() 
        {
            Round++;
        }

        public int GetRound()
        {
            return Round;
        }

        public void SwitchActivePlayer() 
        {
            switch (ActivePlayer)
            {
                case Player.PlayerOne:
                    ActivePlayer = Player.PlayerTwo;
                    break;
                case Player.PlayerTwo:
                    ActivePlayer = Player.PlayerOne;
                    break;
            }
        }

        public Player GetActivePlayer()
        {
            return ActivePlayer;
        }

        public void ResetActivePlayer()
        {
            ActivePlayer = Player.PlayerOne;
        }

        public string GetPlayerName(Player Player)
        {
            switch (Player)
            {
                case Player.PlayerOne:
                    return PlayerOneName;
                case Player.PlayerTwo:
                    return PlayerTwoName;
                default:
                    return "";
            }
        }

        public string GetActivePlayerName()
        {
            return GetPlayerName(ActivePlayer);
        }

        public Color GetPlayerColor(Player Player)
        {
            switch (Player)
            {
                case Player.PlayerOne:
                    return PlayerOneColor;
                case Player.PlayerTwo:
                    return PlayerTwoColor;
                default:
                    return Color.Silver;
            }
        }

        public Color GetActivePlayerColor()
        {
            return GetPlayerColor(ActivePlayer);
        }

        public int GetPlayerScore(Player Player)
        {
            switch (Player)
            {
                case Player.PlayerOne:
                    return PlayerOneScore;
                case Player.PlayerTwo:
                    return PlayerTwoScore;
                default:
                    return 0;
            }
        }

        public int GetActivePlayerScore()
        {
            return GetPlayerScore(ActivePlayer);
        }

        public void IncrementActivePlayerScore()
        {
            switch (ActivePlayer)
            {
                case Player.PlayerOne:
                    PlayerOneScore++;
                    break;
                case Player.PlayerTwo:
                    PlayerTwoScore++;
                    break;
                default:
                    return;
            }
        }
    }
}
