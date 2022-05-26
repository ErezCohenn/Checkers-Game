using EnglishCheckersLogic;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public partial class FormGame : Form
    {

        private const int k_PictureBoxSize = 50;
        private const int k_WidthExtention = 20;
        private const int k_HeightExtention = 80;
        private System.Windows.Forms.PictureBox[,] pictureBoxMatrix;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Name;
        private FormGameSettings m_FormGameSettings;
        private EventGameDetailsArgs m_GameDetailsArgs;
        public EventHandler GameDetailsUpdated;
        public EventHandler YesNoMessageBoxClicked;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, System.EventArgs e)
        {
            m_FormGameSettings.ShowDialog();
        }

        public void ContinuePlayingMessageBox(Game i_GameLogic)
        {
            DialogResult userChoice = new DialogResult();
            StringBuilder message = new StringBuilder();
            YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = null;
            bool wantToQuit = false;

            if (i_GameLogic.FinishReason == Game.eSessionFinishType.Draw)
            {
                message.Append("Tie!");
            }
            else if (i_GameLogic.FinishReason == Game.eSessionFinishType.Won)
            {
                message.Append(string.Format("{0} Won!", i_GameLogic.PreviousPlayer.Name));
            }

            message.Append(Environment.NewLine);
            message.Append("Another Round?");
            userChoice = MessageBox.Show(message.ToString(), "Damka", MessageBoxButtons.YesNo);
            wantToQuit = userChoice == DialogResult.No;
            yesNoMessageBoxEventArgs = new YesNoMessageBoxEventArgs(wantToQuit);
            OnYesNoMessageBoxClicked(yesNoMessageBoxEventArgs);


        }

        private void OnYesNoMessageBoxClicked(YesNoMessageBoxEventArgs i_YesNoMessageBoxEventArgs)
        {
            if (YesNoMessageBoxClicked != null)
            {
                YesNoMessageBoxClicked.Invoke(this, i_YesNoMessageBoxEventArgs);
            }
        }

        private void FormGameSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            /*      if (e.CloseReason == CloseReason.UserClosing)
                  {
                      this.Close();
                  }*/

            OnGameDetailsUpdated();
            initializeGameForm();
        }

        private void initializeGameForm()
        {
            setFormSize();
            initializePlayersLabels();
            initializePictureBoxMatrix();
        }

        private void initializePlayersLabels()
        {

        }

        private void OnGameDetailsUpdated()
        {
            m_GameDetailsArgs = new EventGameDetailsArgs(m_FormGameSettings.OPlayerName, m_FormGameSettings.XPlayerName, m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOType);

            if (GameDetailsUpdated != null)
            {
                GameDetailsUpdated.Invoke(this, m_GameDetailsArgs);
            }

        }

        private void setFormSize()
        {
            this.Size = new Size(((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_WidthExtention, ((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_HeightExtention);
        }

        private void initializePictureBoxMatrix()
        {
            pictureBoxMatrix = new PictureBox[(int)m_GameDetailsArgs.BoardSize, (int)m_GameDetailsArgs.BoardSize];

            for (int i = 0; i < (int)m_GameDetailsArgs.BoardSize; i++)
            {
                for (int j = 0; j < (int)m_GameDetailsArgs.BoardSize; j++)
                {
                    pictureBoxMatrix[i, j] = new PictureBox();
                    if (i % 2 != j % 2)
                    {
                        pictureBoxMatrix[i, j].BackColor = Color.Bisque;
                    }
                    else
                    {
                        pictureBoxMatrix[i, j].BackColor = Color.White;
                        pictureBoxMatrix[i, j].Image = @"C:\Users\erez6\Desktop\לימודים\אקדמית יפו\שנה ב\ותכנות מונחה עצמים בסביבת דוט נט C#\C-SHARP-EX05\Checkers-Game\CheckersGame\EnglishCheckers\test.jpeg";
                    }

                    pictureBoxMatrix[i, j].Size = new System.Drawing.Size(k_PictureBoxSize, k_PictureBoxSize);
                    pictureBoxMatrix[i, j].Location = new System.Drawing.Point(k_PictureBoxSize * i, k_HeightExtention + k_PictureBoxSize * j);
                    this.Controls.Add(this.pictureBoxMatrix[i, j]);
                }
            }
        }
    }
}
