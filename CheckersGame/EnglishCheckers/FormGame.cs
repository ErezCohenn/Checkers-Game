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
        private const int k_HeightExtention = 60;
        public static readonly string sr_RedPawnImage = "RedPawn.png";
        public static readonly string sr_RedKingImage = "RedKing.png";
        public static readonly string sr_BlackPawnImage = "‏‏BlackPawn.png";
        public static readonly string sr_BlackKingImage = "‏‏BlackKing.png";
        public static readonly string sr_‏‏DisabledCellImage = "‏‏DisabledCell.png";
        private static readonly string sr_EmptyCellImage = "EmptyCell.png";
        private PictureBoxCell[,] pictureBoxMatrix;
        private PictureBoxCell pictureBoxSource;
        private PictureBoxCell pictureBoxDestination;
        private bool m_PictureBoxInProgress;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Name;
        private FormGameSettings m_FormGameSettings;
        private EventGameDetailsArgs m_GameDetailsArgs;
        public EventHandler GameDetailsUpdated;
        public EventHandler YesNoMessageBoxClicked;
        public event Action<Movement> RecivedMovement;

        public FormGame()
        {
            m_PictureBoxInProgress = false;
            InitializeComponent();
        }

        private void FormGame_Load(object sender, System.EventArgs e)
        {
            m_FormGameSettings.ShowDialog();
        }

        public void SetNewSession(int i_Player1Sccore, int i_Player2Sccore, string i_CurrentPlayer)
        {
            m_GameDetailsArgs.CurrentPlayer = i_CurrentPlayer;
            initializePlayersLabels(i_Player1Sccore, i_Player2Sccore);
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

        private void initializePlayersLabels(int i_Player1Sccore, int i_Player2Sccore)
        {
            if (m_GameDetailsArgs.PlayerOName == "[Computer]")
            {
                this.labelPlayer1Name.Text = string.Format("{0}: {1}", "Computer", i_Player1Sccore);
            }
            else
            {
                this.labelPlayer1Name.Text = string.Format("{0}: {1}", m_GameDetailsArgs.PlayerOName, i_Player1Sccore);
            }

            this.labelPlayer2Name.Text = string.Format("{0}: {1}", m_GameDetailsArgs.PlayerXName, i_Player2Sccore);
            this.labelPlayer2Name.ForeColor = Color.Blue;
        }

        private void OnGameDetailsUpdated()
        {
            m_GameDetailsArgs = new EventGameDetailsArgs(m_FormGameSettings.OPlayerName, m_FormGameSettings.XPlayerName, m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOType);

            if (GameDetailsUpdated != null)
            {
                GameDetailsUpdated.Invoke(this, m_GameDetailsArgs);
            }

        }

        private void OnReceivedMovement()
        {
            Movement movementToHandle = new Movement(pictureBoxSource.PositionOnBoard, pictureBoxDestination.PositionOnBoard);
            if (RecivedMovement != null)
            {

                RecivedMovement.Invoke(movementToHandle);
            }

        }

        private void setFormSize()
        {
            this.Size = new Size(((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_WidthExtention, ((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_HeightExtention + 40);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBoxCell pictureBoxClicked = sender as PictureBoxCell;

            if (m_PictureBoxInProgress)
            {
                if (pictureBoxSource == null)
                {
                    pictureBoxSource = pictureBoxClicked;
                    pictureBoxClicked.BorderStyle = BorderStyle.Fixed3D;
                    //disablePictureBoxByType(m_GameDetailsArgs.CurrentPlayer);
                    //enablePictureBoxByType(Enum.GetName(typeof(Pawn.eType), Pawn.eType.Empty));
                }
                else
                {
                    if (pictureBoxClicked.Name == Enum.GetName(typeof(Pawn.eType), Pawn.eType.Empty))
                    {
                        pictureBoxDestination = pictureBoxClicked;
                        OnReceivedMovement();
                        pictureBoxClicked.BorderStyle = BorderStyle.FixedSingle;
                        pictureBoxDestination = null;
                        pictureBoxSource = null;
                    }
                    else if (pictureBoxClicked == pictureBoxSource)
                    {
                        pictureBoxClicked.BorderStyle = BorderStyle.FixedSingle;
                        pictureBoxSource = null;
                        //disablePictureBoxByType(m_GameDetailsArgs.CurrentPlayer);
                        //enablePictureBoxByType(Enum.GetName(typeof(Pawn.eType), Pawn.eType.Empty));
                    }
                }
            }
        }

        private void initializePictureBoxMatrix()
        {
            string fullFilePath = string.Empty;

            pictureBoxMatrix = new PictureBoxCell[(int)m_GameDetailsArgs.BoardSize, (int)m_GameDetailsArgs.BoardSize];
            for (int i = 0; i < (int)m_GameDetailsArgs.BoardSize; i++)
            {
                for (int j = 0; j < (int)m_GameDetailsArgs.BoardSize; j++)
                {
                    pictureBoxMatrix[i, j] = new PictureBoxCell(i, j)
                    {
                        Size = new Size(k_PictureBoxSize, k_PictureBoxSize),
                        Location = new Point(5 + k_PictureBoxSize * i,
                        k_HeightExtention + k_PictureBoxSize * j),
                        SizeMode = PictureBoxSizeMode.StretchImage
                    };
                    if (diffrentPairing(i, j))
                    {
                        if (j < ((int)m_GameDetailsArgs.BoardSize - 2) / 2)
                        {
                            pictureBoxMatrix[i, j].SetPictureBoxCell(sr_RedPawnImage, false, Pawn.eType.OPawn);
                        }
                        else if (j > (((int)m_GameDetailsArgs.BoardSize + 2) / 2) - 1)
                        {
                            pictureBoxMatrix[i, j].SetPictureBoxCell(sr_BlackPawnImage, true, Pawn.eType.XPawn);
                        }
                        else
                        {
                            pictureBoxMatrix[i, j].SetPictureBoxCell(sr_EmptyCellImage, false, Pawn.eType.Empty);
                        }

                        pictureBoxMatrix[i, j].Click += pictureBox_Click;
                    }
                    else
                    {
                        pictureBoxMatrix[i, j].SetPictureBoxCell(sr_‏‏DisabledCellImage, false, Pawn.eType.Disable);
                    }

                    Controls.Add(pictureBoxMatrix[i, j]);

                }
            }
        }
        private bool diffrentPairing(int i_FirstMumber, int i_SecondNumber)
        {
            return i_FirstMumber % 2 == i_SecondNumber % 2;
        }
    }
}
