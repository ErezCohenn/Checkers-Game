
namespace EnglishCheckersLogic
{
    partial class FormGameSettings
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
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.PlayersLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.xPlayerName = new System.Windows.Forms.TextBox();
            this.oPlayerName = new System.Windows.Forms.TextBox();
            this.playerTypeCheckBoxButton = new System.Windows.Forms.CheckBox();
            this.smallBoardSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.mediumBoardSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.largeBoardSizeRadioButton = new System.Windows.Forms.RadioButton();
            this.doneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.Location = new System.Drawing.Point(12, 9);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(81, 17);
            this.boardSizeLabel.TabIndex = 0;
            this.boardSizeLabel.Text = "Board Size:";
            // 
            // PlayersLabel
            // 
            this.PlayersLabel.AutoSize = true;
            this.PlayersLabel.Location = new System.Drawing.Point(12, 83);
            this.PlayersLabel.Name = "PlayersLabel";
            this.PlayersLabel.Size = new System.Drawing.Size(59, 17);
            this.PlayersLabel.TabIndex = 4;
            this.PlayersLabel.Text = "Players:";
            this.PlayersLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Player 1:";
            // 
            // xPlayerName
            // 
            this.xPlayerName.Location = new System.Drawing.Point(118, 112);
            this.xPlayerName.Name = "xPlayerName";
            this.xPlayerName.Size = new System.Drawing.Size(175, 22);
            this.xPlayerName.TabIndex = 7;
            // 
            // oPlayerName
            // 
            this.oPlayerName.Enabled = false;
            this.oPlayerName.Location = new System.Drawing.Point(118, 148);
            this.oPlayerName.Name = "oPlayerName";
            this.oPlayerName.Size = new System.Drawing.Size(175, 22);
            this.oPlayerName.TabIndex = 8;
            this.oPlayerName.Text = "[Computer]";
            this.oPlayerName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // playerTypeCheckBoxButton
            // 
            this.playerTypeCheckBoxButton.AutoSize = true;
            this.playerTypeCheckBoxButton.Location = new System.Drawing.Point(30, 149);
            this.playerTypeCheckBoxButton.Name = "playerTypeCheckBoxButton";
            this.playerTypeCheckBoxButton.Size = new System.Drawing.Size(86, 21);
            this.playerTypeCheckBoxButton.TabIndex = 9;
            this.playerTypeCheckBoxButton.Text = "Player 2:";
            this.playerTypeCheckBoxButton.UseVisualStyleBackColor = true;
            this.playerTypeCheckBoxButton.CheckedChanged += new System.EventHandler(this.playerTypeCheckBoxButton_CheckedChanged);
            // 
            // smallBoardSizeRadioButton
            // 
            this.smallBoardSizeRadioButton.AutoSize = true;
            this.smallBoardSizeRadioButton.Location = new System.Drawing.Point(34, 46);
            this.smallBoardSizeRadioButton.Name = "smallBoardSizeRadioButton";
            this.smallBoardSizeRadioButton.Size = new System.Drawing.Size(59, 21);
            this.smallBoardSizeRadioButton.TabIndex = 10;
            this.smallBoardSizeRadioButton.TabStop = true;
            this.smallBoardSizeRadioButton.Text = "6 x 6";
            this.smallBoardSizeRadioButton.UseVisualStyleBackColor = true;
            this.smallBoardSizeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // mediumBoardSizeRadioButton
            // 
            this.mediumBoardSizeRadioButton.AutoSize = true;
            this.mediumBoardSizeRadioButton.Location = new System.Drawing.Point(127, 46);
            this.mediumBoardSizeRadioButton.Name = "mediumBoardSizeRadioButton";
            this.mediumBoardSizeRadioButton.Size = new System.Drawing.Size(59, 21);
            this.mediumBoardSizeRadioButton.TabIndex = 10;
            this.mediumBoardSizeRadioButton.TabStop = true;
            this.mediumBoardSizeRadioButton.Text = "8 x 8";
            this.mediumBoardSizeRadioButton.UseVisualStyleBackColor = true;
            this.mediumBoardSizeRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // largeBoardSizeRadioButton
            // 
            this.largeBoardSizeRadioButton.AutoSize = true;
            this.largeBoardSizeRadioButton.Location = new System.Drawing.Point(214, 46);
            this.largeBoardSizeRadioButton.Name = "largeBoardSizeRadioButton";
            this.largeBoardSizeRadioButton.Size = new System.Drawing.Size(79, 21);
            this.largeBoardSizeRadioButton.TabIndex = 10;
            this.largeBoardSizeRadioButton.TabStop = true;
            this.largeBoardSizeRadioButton.Text = "10 x 10 ";
            this.largeBoardSizeRadioButton.UseVisualStyleBackColor = true;
            // 
            // doneButton
            // 
            this.doneButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.doneButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.doneButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.doneButton.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.doneButton.Location = new System.Drawing.Point(172, 190);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(121, 46);
            this.doneButton.TabIndex = 11;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = false;
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(312, 243);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.largeBoardSizeRadioButton);
            this.Controls.Add(this.mediumBoardSizeRadioButton);
            this.Controls.Add(this.smallBoardSizeRadioButton);
            this.Controls.Add(this.playerTypeCheckBoxButton);
            this.Controls.Add(this.oPlayerName);
            this.Controls.Add(this.xPlayerName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayersLabel);
            this.Controls.Add(this.boardSizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.Label PlayersLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox xPlayerName;
        private System.Windows.Forms.TextBox oPlayerName;
        private System.Windows.Forms.CheckBox playerTypeCheckBoxButton;
        private System.Windows.Forms.RadioButton smallBoardSizeRadioButton;
        private System.Windows.Forms.RadioButton mediumBoardSizeRadioButton;
        private System.Windows.Forms.RadioButton largeBoardSizeRadioButton;
        private System.Windows.Forms.Button doneButton;
    }
}