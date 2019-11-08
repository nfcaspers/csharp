namespace MinigamesWF
{
    partial class MainmenuForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TicTacToeButton = new System.Windows.Forms.Button();
            this.VierGewinntButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TicTacToeButton
            // 
            this.TicTacToeButton.Location = new System.Drawing.Point(12, 12);
            this.TicTacToeButton.Name = "TicTacToeButton";
            this.TicTacToeButton.Size = new System.Drawing.Size(250, 200);
            this.TicTacToeButton.TabIndex = 0;
            this.TicTacToeButton.Text = "Tic-Tac-Toe";
            this.TicTacToeButton.UseVisualStyleBackColor = true;
            this.TicTacToeButton.Click += new System.EventHandler(this.TicTacToeButton_Click);
            // 
            // VierGewinntButton
            // 
            this.VierGewinntButton.Location = new System.Drawing.Point(322, 12);
            this.VierGewinntButton.Name = "VierGewinntButton";
            this.VierGewinntButton.Size = new System.Drawing.Size(250, 200);
            this.VierGewinntButton.TabIndex = 1;
            this.VierGewinntButton.Text = "4 Gewinnt";
            this.VierGewinntButton.UseVisualStyleBackColor = true;
            this.VierGewinntButton.Click += new System.EventHandler(this.VierGewinntButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(13, 219);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(559, 130);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainmenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.VierGewinntButton);
            this.Controls.Add(this.TicTacToeButton);
            this.Name = "MainmenuForm";
            this.Text = "Minigames Mainmenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TicTacToeButton;
        private System.Windows.Forms.Button VierGewinntButton;
        private System.Windows.Forms.Button ExitButton;
    }
}

