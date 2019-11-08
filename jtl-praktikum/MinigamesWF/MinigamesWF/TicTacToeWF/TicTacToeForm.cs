using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinigamesWF.TicTacToeWF;

namespace MinigamesWF.TicTacToeWF
{
    public partial class TicTacToeForm : Form
    {
        private MainmenuForm MainMenu;

        private readonly GameInfo GameData;
        private readonly TicTacToeCore Game;
        private TicTacToeBot PlayerOBot;

        private List<Button> ButtonList;

        public TicTacToeForm(MainmenuForm MainMenu)
        {
            this.MainMenu = MainMenu;
            GameData = new GameInfo();
            Game = new TicTacToeCore();
            PlayerOBot = new TicTacToeBot();
            InitializeComponent();
        }

        public void UpdateTurn() 
        {
            TurnLabel.Text = "Turn: " + GameData.GetTurn().ToString();
        }

        public void UpdateActivePlayer()
        {
            ActivePlayerLabel.Text = "Active Player: " + GameData.GetActivePlayerName();
               
        }

        public void UpdatePlayerScore()
        {
            switch (GameData.GetActivePlayer())
            {
                case Players.PlayerX:
                    PlayerXScoreLabel.Text = GameData.GetPlayerScore(Players.PlayerX).ToString();
                    break;
                case Players.PlayerO:
                    PlayerOScoreLabel.Text = GameData.GetPlayerScore(Players.PlayerO).ToString();
                    break;
            }
        }
        public void ResetPlayerScores()
        {
            PlayerXScoreLabel.Text = "0";
            PlayerOScoreLabel.Text = "0";
        }
        public void EnableButtons()
        {
            foreach (Button Btn in ButtonList)
            {
                Btn.Enabled = true;
            }
        }
        public void DisableButtons()
        {
            foreach (Button Btn in ButtonList)
            {
                Btn.Enabled = false;
            }
        }
        public void ResetButtons()
        {
            Button1.Text = "";
            Button2.Text = "";
            Button3.Text = "";
            Button4.Text = "";
            Button5.Text = "";
            Button6.Text = "";
            Button7.Text = "";
            Button8.Text = "";
            Button9.Text = "";
        }

        public void ProcessPlayerAction(Coordinates Coords, Button PressedButton)
        {
            if (Game.SetNewTileOwner(Coords, GameData.GetActivePlayer())) 
            {
                PressedButton.Text = GameData.GetActivePlayerName();
                switch (Game.TestForWin(Coords, GameData.GetActivePlayer()))
                {
                    case TurnResult.None:
                        UpdateTurn();
                        GameData.SwitchActivePlayer();
                        UpdateActivePlayer();
                        if (PlayerOBot.IsActive() && GameData.GetActivePlayer() == Players.PlayerO)
                        {
                            PlayerOBot.ExecuteMove(Coords, PressedButton);
                        }
                        break;
                    case TurnResult.Win:
                        GameData.UpdatePlayerScore();
                        UpdatePlayerScore();
                        GameData.NewTurn();
                        UpdateTurn();
                        GameData.ResetActivePlayer();
                        UpdateActivePlayer();
                        Game.ResetBoard();
                        ResetButtons();
                        if (PlayerOBot.IsActive())
                        {
                            PlayerOBot.ResetButtonList();
                        }
                        break;
                    case TurnResult.Draw:
                        GameData.NewTurn();
                        GameData.ResetActivePlayer();
                        Game.ResetBoard();
                        ResetButtons();
                        break;
                }
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(0, 0), Button1);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(0, 1), Button2);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(0, 2), Button3);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(1, 0), Button4);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(1, 1), Button5);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(1, 2), Button6);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(2, 0), Button7);
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(2, 1), Button8);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(new Coordinates(2, 2), Button9);
        }

        private void SetPlayerINameButton_Click(object sender, EventArgs e)
        {
            Name = NamePlayerITextBox.Text;
            NamePlayerITextBox.Text = "";
            GameData.SetNewPlayerName(Players.PlayerX, Name);
        }

        private void SetPlayerIINameButton_Click(object sender, EventArgs e)
        {
            Name = this.NamePlayerIITextbox.Text;
            this.NamePlayerIITextbox.Text = "";
            GameData.SetNewPlayerName(Players.PlayerO, Name);
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            NamePlayerITextBox.Enabled = false;
            SetPlayerINameButton.Enabled = false;
            NamePlayerIITextbox.Enabled = false;
            SetPlayerIINameButton.Enabled = false;
            PlayerIICpuCheckBox.Enabled = false;
            GameData.ResetGameData();
            Game.ResetBoard();
            ResetButtons();
            ResetPlayerScores();
            UpdateActivePlayer();
            UpdateTurn();
            EnableButtons();
            if (PlayerIICpuCheckBox.Checked)
            {
                PlayerOBot.ResetButtonList();
            }
        }

        private void EndGameButton_Click(object sender, EventArgs e)
        {
            NamePlayerITextBox.Enabled = true;
            SetPlayerINameButton.Enabled = true;
            NamePlayerIITextbox.Enabled = true;
            SetPlayerIINameButton.Enabled = true;
            PlayerIICpuCheckBox.Enabled = true;
            DisableButtons();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //PlayerXBot.SwitchActive();

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            PlayerOBot.SwitchActive();
            List<Button> CopyList = new List<Button>(ButtonList);
            PlayerOBot.SetButtons(ButtonList);
        }

        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            List<Button> ButtonList = new List<Button>() { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };   
            
            foreach (Button Btn in ButtonList)
            {
                Btn.Enabled = false;
            }
            this.ButtonList = ButtonList;
        }

        private void TicTacToeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.Show();
        }
    }
}
