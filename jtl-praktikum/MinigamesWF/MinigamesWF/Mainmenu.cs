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
using MinigamesWF.VierGewinntWF;

namespace MinigamesWF
{
    public partial class MainmenuForm : Form
    {
        public MainmenuForm()
        {
            InitializeComponent();
        }

        private void TicTacToeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form TicTacToeForm = new TicTacToeForm(this);
            TicTacToeForm.Show();
        }

        private void VierGewinntButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form VierGewinntForm = new VierGewinntForm(this);
            VierGewinntForm.Show();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
