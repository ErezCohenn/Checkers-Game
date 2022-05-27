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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.labelPlayer1Name = new System.Windows.Forms.Label();
            this.labelPlayer2Name = new System.Windows.Forms.Label();
            this.m_FormGameSettings = new EnglishCheckersWinUI.FormGameSettings();
            this.SuspendLayout();
            // 
            // labelPlayer1Name
            // 
            this.labelPlayer1Name.AutoSize = true;
            this.labelPlayer1Name.Location = new System.Drawing.Point(29, 28);
            this.labelPlayer1Name.Name = "labelPlayer1Name";
            this.labelPlayer1Name.Size = new System.Drawing.Size(103, 17);
            this.labelPlayer1Name.TabIndex = 0;
            this.labelPlayer1Name.Text = "Player 1: score";
            // 
            // labelPlayer2Name
            // 
            this.labelPlayer2Name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayer2Name.AutoSize = true;
            this.labelPlayer2Name.Location = new System.Drawing.Point(138, 28);
            this.labelPlayer2Name.Name = "labelPlayer2Name";
            this.labelPlayer2Name.Size = new System.Drawing.Size(103, 17);
            this.labelPlayer2Name.TabIndex = 1;
            this.labelPlayer2Name.Text = "Player 2: score";
            // 
            // m_FormGameSettings
            // 
            this.m_FormGameSettings.AutoSize = true;
            this.m_FormGameSettings.ClientSize = new System.Drawing.Size(316, 259);
            this.m_FormGameSettings.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.m_FormGameSettings.Icon = ((System.Drawing.Icon)(resources.GetObject("m_FormGameSettings.Icon")));
            this.m_FormGameSettings.Location = new System.Drawing.Point(3435, 500);
            this.m_FormGameSettings.MaximizeBox = false;
            this.m_FormGameSettings.MinimizeBox = false;
            this.m_FormGameSettings.Name = "m_FormGameSettings";
            this.m_FormGameSettings.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.m_FormGameSettings.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.m_FormGameSettings.Text = "Game Settings";
            this.m_FormGameSettings.Visible = false;
            this.m_FormGameSettings.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormGameSettings_FormClosed);
            // 
            // FormGame
            // 
            this.ClientSize = new System.Drawing.Size(249, 236);
            this.Controls.Add(this.labelPlayer2Name);
            this.Controls.Add(this.labelPlayer1Name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormGame";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Damka";
            this.Load += new System.EventHandler(this.FormGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

  
        }
        #endregion
    }
}