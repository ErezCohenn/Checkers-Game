
namespace EnglishCheckersWinUI
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
            this.labelBoardSize = new System.Windows.Forms.Label();
            this.labelPlayers = new System.Windows.Forms.Label();
            this.labelPlayer1 = new System.Windows.Forms.Label();
            this.textButtenXPlayerName = new System.Windows.Forms.TextBox();
            this.textButtonOPlayerName = new System.Windows.Forms.TextBox();
            this.checkBoxButtonPlayerTypeCheck = new System.Windows.Forms.CheckBox();
            this.radioButtonSmallBoardSize = new System.Windows.Forms.RadioButton();
            this.radioButtonMediumBoardSize = new System.Windows.Forms.RadioButton();
            this.radioButtonLargeBoardSize = new System.Windows.Forms.RadioButton();
            this.buttonDone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelBoardSize
            // 
            this.labelBoardSize.AutoSize = true;
            this.labelBoardSize.Location = new System.Drawing.Point(12, 9);
            this.labelBoardSize.Name = "labelBoardSize";
            this.labelBoardSize.Size = new System.Drawing.Size(81, 17);
            this.labelBoardSize.TabIndex = 0;
            this.labelBoardSize.Text = "Board Size:";
            // 
            // labelPlayers
            // 
            this.labelPlayers.AutoSize = true;
            this.labelPlayers.Location = new System.Drawing.Point(12, 83);
            this.labelPlayers.Name = "labelPlayers";
            this.labelPlayers.Size = new System.Drawing.Size(59, 17);
            this.labelPlayers.TabIndex = 4;
            this.labelPlayers.Text = "Players:";
            // 
            // labelPlayer1
            // 
            this.labelPlayer1.AutoSize = true;
            this.labelPlayer1.Location = new System.Drawing.Point(27, 112);
            this.labelPlayer1.Name = "labelPlayer1";
            this.labelPlayer1.Size = new System.Drawing.Size(64, 17);
            this.labelPlayer1.TabIndex = 5;
            this.labelPlayer1.Text = "Player 1:";
            // 
            // textButtenXPlayerName
            // 
            this.textButtenXPlayerName.Location = new System.Drawing.Point(118, 112);
            this.textButtenXPlayerName.Name = "textButtenXPlayerName";
            this.textButtenXPlayerName.Size = new System.Drawing.Size(175, 22);
            this.textButtenXPlayerName.TabIndex = 7;
            // 
            // textButtonOPlayerName
            // 
            this.textButtonOPlayerName.Enabled = false;
            this.textButtonOPlayerName.Location = new System.Drawing.Point(118, 148);
            this.textButtonOPlayerName.Name = "textButtonOPlayerName";
            this.textButtonOPlayerName.Size = new System.Drawing.Size(175, 22);
            this.textButtonOPlayerName.TabIndex = 8;
            this.textButtonOPlayerName.Text = "[Computer]";
            // 
            // checkBoxButtonPlayerTypeCheck
            // 
            this.checkBoxButtonPlayerTypeCheck.AutoSize = true;
            this.checkBoxButtonPlayerTypeCheck.Location = new System.Drawing.Point(30, 149);
            this.checkBoxButtonPlayerTypeCheck.Name = "checkBoxButtonPlayerTypeCheck";
            this.checkBoxButtonPlayerTypeCheck.Size = new System.Drawing.Size(86, 21);
            this.checkBoxButtonPlayerTypeCheck.TabIndex = 9;
            this.checkBoxButtonPlayerTypeCheck.Text = "Player 2:";
            this.checkBoxButtonPlayerTypeCheck.UseVisualStyleBackColor = true;
            this.checkBoxButtonPlayerTypeCheck.CheckedChanged += new System.EventHandler(this.playerTypeCheckBoxButton_CheckedChanged);
            // 
            // radioButtonSmallBoardSize
            // 
            this.radioButtonSmallBoardSize.AutoSize = true;
            this.radioButtonSmallBoardSize.Location = new System.Drawing.Point(34, 46);
            this.radioButtonSmallBoardSize.Name = "radioButtonSmallBoardSize";
            this.radioButtonSmallBoardSize.Size = new System.Drawing.Size(59, 21);
            this.radioButtonSmallBoardSize.TabIndex = 10;
            this.radioButtonSmallBoardSize.TabStop = true;
            this.radioButtonSmallBoardSize.Text = "6 x 6";
            this.radioButtonSmallBoardSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonMediumBoardSize
            // 
            this.radioButtonMediumBoardSize.AutoSize = true;
            this.radioButtonMediumBoardSize.Location = new System.Drawing.Point(127, 46);
            this.radioButtonMediumBoardSize.Name = "radioButtonMediumBoardSize";
            this.radioButtonMediumBoardSize.Size = new System.Drawing.Size(59, 21);
            this.radioButtonMediumBoardSize.TabIndex = 10;
            this.radioButtonMediumBoardSize.TabStop = true;
            this.radioButtonMediumBoardSize.Text = "8 x 8";
            this.radioButtonMediumBoardSize.UseVisualStyleBackColor = true;
            // 
            // radioButtonLargeBoardSize
            // 
            this.radioButtonLargeBoardSize.AutoSize = true;
            this.radioButtonLargeBoardSize.Location = new System.Drawing.Point(214, 46);
            this.radioButtonLargeBoardSize.Name = "radioButtonLargeBoardSize";
            this.radioButtonLargeBoardSize.Size = new System.Drawing.Size(79, 21);
            this.radioButtonLargeBoardSize.TabIndex = 10;
            this.radioButtonLargeBoardSize.TabStop = true;
            this.radioButtonLargeBoardSize.Text = "10 x 10 ";
            this.radioButtonLargeBoardSize.UseVisualStyleBackColor = true;
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.buttonDone.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonDone.Font = new System.Drawing.Font("Microsoft JhengHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonDone.Location = new System.Drawing.Point(172, 190);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(121, 46);
            this.buttonDone.TabIndex = 11;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(312, 243);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.radioButtonLargeBoardSize);
            this.Controls.Add(this.radioButtonMediumBoardSize);
            this.Controls.Add(this.radioButtonSmallBoardSize);
            this.Controls.Add(this.checkBoxButtonPlayerTypeCheck);
            this.Controls.Add(this.textButtonOPlayerName);
            this.Controls.Add(this.textButtenXPlayerName);
            this.Controls.Add(this.labelPlayer1);
            this.Controls.Add(this.labelPlayers);
            this.Controls.Add(this.labelBoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Game Settings";            
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}