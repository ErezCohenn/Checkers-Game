namespace EnglishCheckersWinUI
{
    partial class FormGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1Score = new System.Windows.Forms.Label();
            this.player2Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Score
            // 
            this.player1Score.AutoSize = true;
            this.player1Score.Location = new System.Drawing.Point(36, 28);
            this.player1Score.Name = "player1Score";
            this.player1Score.Size = new System.Drawing.Size(64, 17);
            this.player1Score.TabIndex = 0;
            this.player1Score.Text = "Player 1:";
            // 
            // player2Score
            // 
            this.player2Score.AutoSize = true;
            this.player2Score.Location = new System.Drawing.Point(159, 28);
            this.player2Score.Name = "player2Score";
            this.player2Score.Size = new System.Drawing.Size(64, 17);
            this.player2Score.TabIndex = 1;
            this.player2Score.Text = "Player 2:";
            // 
            // FormGame
            // 
            this.ClientSize = new System.Drawing.Size(249, 236);
            this.Controls.Add(this.player2Score);
            this.Controls.Add(this.player1Score);
            this.Name = "FormGame";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            m_FormGameSettings = new FormGameSettings();
            m_FormGameSettings.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGameSettings_FormClosed);
        }
        #endregion
    }
}