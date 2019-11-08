using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinigamesWF.VierGewinntWF
{
    public partial class VierGewinntForm : Form
    {
        private readonly MainmenuForm MainMenu;

        private readonly VierGewinntCore Game;
        private readonly GameInfo GameInfo;
        private readonly VierGewinntBot PlayerTwoBot;

        private Label[,] Labels;
        private List<Button> Buttons;

        public VierGewinntForm(MainmenuForm MainMenu)
        {
            this.MainMenu = MainMenu;
            Game = new VierGewinntCore();
            GameInfo = new GameInfo();
            PlayerTwoBot = new VierGewinntBot();
            InitializeComponent();
        }

        public void UpdateActivePlayerLabel()
        {
            ActivePlayerLabel.Text = "Active Player: " + GameInfo.GetActivePlayerName();
        }

        public void UpdatePlayerScore()
        {
            switch (GameInfo.GetActivePlayer())
            {
                case Player.PlayerOne:
                    ScorePlayerOneLabel.Text = GameInfo.GetActivePlayerScore().ToString();
                    return;
                case Player.PlayerTwo:
                    ScorePlayerTwoLabel.Text = GameInfo.GetActivePlayerScore().ToString();
                    return;
            }
        }

        public void ResetRoundLabels()
        {
            RoundLabel.Text = "1";
            ScorePlayerOneLabel.Text = "0";
            ScorePlayerTwoLabel.Text = "0";
        }

        public void UpdateRound()
        {
            RoundLabel.Text = "Round: " + GameInfo.GetRound().ToString();
        }

        private void ProcessPlayerAction(int RowIndex)
        {
            (bool isFree, Coords LabelCoords) = Game.DropInColumn(RowIndex, GameInfo.GetActivePlayer());
            if (isFree)
            {
                Label ActiveLabel = Labels[LabelCoords.X, LabelCoords.Y];
                ActiveLabel.Text = GameInfo.GetActivePlayerName();
                ActiveLabel.BackColor = GameInfo.GetActivePlayerColor();
                TurnResult Result = Game.TestForWin(LabelCoords, GameInfo.GetActivePlayer());
                switch (Result)
                {
                    case TurnResult.None:
                        GameInfo.SwitchActivePlayer();
                        UpdateActivePlayerLabel();
                        if (PlayerTwoBot.IsActive() && GameInfo.GetActivePlayer() == Player.PlayerTwo)
                        {
                            PlayerTwoBot.ExecuteMove(LabelCoords);
                        }
                        break;
                    case TurnResult.Win:
                        GameInfo.IncrementRound();
                        UpdateRound();
                        GameInfo.IncrementActivePlayerScore();
                        UpdatePlayerScore();
                        PlayerTwoBot.ResetButtons();
                        GameInfo.ResetActivePlayer();
                        Game.ResetBoard();
                        ResetLabels();
                        break;
                    case TurnResult.Draw:
                        GameInfo.IncrementRound();
                        UpdateRound();
                        PlayerTwoBot.ResetButtons();
                        GameInfo.ResetActivePlayer();
                        Game.ResetBoard();
                        ResetLabels();
                        break;
                }
            }
        }

        private void DropButton1_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(0);
        }
        private void DropButton2_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(1);
        }
        
        private void DropButton3_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(2);
        }

        private void DropButton4_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(3);
        } 
        
        private void DropButton5_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(4);
        }

        private void DropButton6_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(5);
        }

        private void DropButton7_Click(object sender, EventArgs e)
        {
            ProcessPlayerAction(6);
        }

        private void VierGewinntForm_Load(object sender, EventArgs e)
        {
            Label[,] Labels = new Label[,] { {label1, label2, label3, label4, label5, label6, label7 },
                                             {label8, label9, label10, label11, label12, label13, label14 },
                                             {label15, label16, label17, label18, label19, label20, label21 },
                                             {label22, label23, label24, label25, label26, label27, label28 },
                                             {label29, label30, label31, label32, label33, label34, label35 },
                                             {label36, label37, label38, label39, label40, label41, label42 } };
            List<Button> Buttons = new List<Button> { DropButton1, DropButton2, DropButton3, DropButton4,
                                                  DropButton5, DropButton6, DropButton7 };
            this.Labels = Labels;
            this.Buttons = Buttons;
            PlayerTwoBot.SetButtons(Buttons);
        }
        
        private void VierGewinntForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenu.Show();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            foreach (Button DropButton in Buttons)
            {
                DropButton.Enabled = true;
            }
        }

        private void EndGameButton_Click(object sender, EventArgs e)
        {
            foreach (Button DropButton in Buttons)
            {
                DropButton.Enabled = false;
            }
            foreach (Label Label in Labels)
            {
                Label.Text = "";
                Label.BackColor = Color.Silver;
            }
            ResetRoundLabels();
            Game.ResetBoard();
            GameInfo.ResetRoundData();
            UpdateActivePlayerLabel();
        }

        private void PlayerTwoCpuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PlayerTwoBot.SwitchActive();
        }

        public void ResetLabels()
        {
            foreach (Label Label in Labels)
            {
                Label.Text = "";
                Label.BackColor = Color.Silver;
            }
        }
    }
}
