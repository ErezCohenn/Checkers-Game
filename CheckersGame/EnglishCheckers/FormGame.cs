using EnglishCheckersLogic;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public partial class FormGame : Form
    {

        private const int k_PictureBoxSize = 50;
        private const int k_WidthExtention = 20;
        private const int k_HeightExtention = 60;
        private const string k_RedPawnImage = "RedPawn.png";
        private const string k_RedKingImage = "RedKing.png";
        private const string k_BlackPawnImage = "‏‏BlackPawn.png";
        private const string k_BlackKingImage = "‏‏BlackKing.png";
        private const string k_‏‏DisabledCellImage = "‏‏DisabledCell.png";
        private const string k_EmptyCellImage = "EmptyCell.png";
        private readonly string r_ResourcesFolderPath;
        private System.Windows.Forms.PictureBox[,] pictureBoxMatrix;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Name;
        private FormGameSettings m_FormGameSettings;
        private EventGameDetailsArgs m_GameDetailsArgs;
        public EventHandler GameDetailsUpdated;
        public EventHandler YesNoMessageBoxClicked;

        public FormGame()
        {
            r_ResourcesFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Resources");
            InitializeComponent();
        }

        private void FormGame_Load(object sender, System.EventArgs e)
        {
            m_FormGameSettings.ShowDialog();
        }

        public void SetNewSession(Func<int> getScore1, Func<int> getScore2, string currentPlayer)
        {
            initializePlayersLabels();
            initializePictureBoxMatrix();
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
            setFormSize();
        }

        private void initializePlayersLabels()
        {
            if (m_GameDetailsArgs.PlayerOName == "[Computer]")
            {
                this.labelPlayer1Name.Text = string.Format("{0}: {1}", "Computer", "score");
            }
            else
            {
                this.labelPlayer1Name.Text = string.Format("{0}: {1}", m_GameDetailsArgs.PlayerOName, "score");
            }
            this.labelPlayer2Name.Text = string.Format("{0}: {1}", m_GameDetailsArgs.PlayerXName, "score");
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
            this.Size = new Size(((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_WidthExtention, ((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_HeightExtention + 40);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = sender as PictureBox;

            pictureBox.BorderStyle = BorderStyle.Fixed3D;
        }

        private void initializePictureBoxMatrix()
        {
            string fullFilePath = string.Empty;

            pictureBoxMatrix = new PictureBox[(int)m_GameDetailsArgs.BoardSize, (int)m_GameDetailsArgs.BoardSize];
            for (int i = 0; i < (int)m_GameDetailsArgs.BoardSize; i++)
            {
                for (int j = 0; j < (int)m_GameDetailsArgs.BoardSize; j++)
                {
                    pictureBoxMatrix[i, j] = new PictureBox { Name = "", Size = new Size(k_PictureBoxSize, k_PictureBoxSize), Location = new Point(5 + k_PictureBoxSize * i, k_HeightExtention + k_PictureBoxSize * j), SizeMode = PictureBoxSizeMode.StretchImage };
                    if (diffrentPairing(i, j))
                    {
                        if (j < ((int)m_GameDetailsArgs.BoardSize - 2) / 2)
                        {
                            setPictureBoxCell(k_RedPawnImage, i, j, false);
                        }
                        else if (j > (((int)m_GameDetailsArgs.BoardSize + 2) / 2) - 1)
                        {
                            setPictureBoxCell(k_BlackPawnImage, i, j, true);
                        }
                        else
                        {
                            setPictureBoxCell(k_EmptyCellImage, i, j, false);
                        }
                    }
                    else
                    {

                        setPictureBoxCell(k_‏‏DisabledCellImage, i, j, false);
                    }

                    this.Controls.Add(this.pictureBoxMatrix[i, j]);
                    pictureBoxMatrix[i, j].Click += pictureBox_Click;
                }
            }
        }

        private void setPictureBoxCell(string i_PawnImage, int i_Row, int i_Col, bool i_EnableButton)
        {
            string fullFilePath = string.Empty;

            fullFilePath = Path.Combine(r_ResourcesFolderPath, i_PawnImage);
            pictureBoxMatrix[i_Row, i_Col].Image = Image.FromFile(fullFilePath);
            pictureBoxMatrix[i_Row, i_Col].Enabled = i_EnableButton;
        }
        private bool diffrentPairing(int i_FirstMumber, int i_SecondNumber)
        {
            return i_FirstMumber % 2 == i_SecondNumber % 2;
        }
    }
}
