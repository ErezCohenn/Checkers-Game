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
        private const int k_HeightExtention = 100;
        private const int k_HeightMargin = 60;
        private const int k_WidthMargin = 5;
        private PictureBoxCell[,] pictureBoxBoard;
        private PictureBoxCell pictureBoxSource;
        private PictureBoxCell pictureBoxDestination;
        private System.Windows.Forms.Label labelPlayer1Name;
        private System.Windows.Forms.Label labelPlayer2Name;
        private FormGameSettings m_FormGameSettings;
        private EventGameDetailsArgs m_GameDetailsArgs;
        public EventHandler GameDetailsUpdated;
        public EventHandler YesNoMessageBoxClicked;
        public event Action<Movement> RecivedMovement;

        public FormGame()
        {
            InitializeComponent();
        }

        private void FormGame_Load(object sender, System.EventArgs e)
        {
            m_FormGameSettings.ShowDialog();
        }

        public void SetNewSession(int i_Player1Sccore, int i_Player2Sccore, string i_CurrentPlayer)
        {
            m_GameDetailsArgs.CurrentPlayer = i_CurrentPlayer;
            setPlayersLabels(i_Player1Sccore, i_Player2Sccore);
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

            initializeForm();
            OnGameDetailsUpdated();
        }

        private void initializeForm()
        {
            initializeGameDetailsArgs();
            initializeFormSize();
            initializePictureBoxBoard();
        }

        private void initializeGameDetailsArgs()
        {
            m_GameDetailsArgs = new EventGameDetailsArgs(m_FormGameSettings.OPlayerName, m_FormGameSettings.XPlayerName, m_FormGameSettings.BoardSize, m_FormGameSettings.PlayerOType);
        }

        private void initializePictureBoxBoard()
        {
            pictureBoxBoard = new PictureBoxCell[(int)m_GameDetailsArgs.BoardSize, (int)m_GameDetailsArgs.BoardSize];
            for (int i = 0; i < (int)m_GameDetailsArgs.BoardSize; i++)
            {
                for (int j = 0; j < (int)m_GameDetailsArgs.BoardSize; j++)
                {
                    pictureBoxBoard[i, j] = new PictureBoxCell(i, j);
                    initializePictureBox(pictureBoxBoard[i, j]);
                    Controls.Add(pictureBoxBoard[i, j]);
                }
            }
        }

        private void initializePictureBox(PictureBoxCell pictureBoxCell)
        {
            pictureBoxCell.Size = new Size(k_PictureBoxSize, k_PictureBoxSize);
            pictureBoxCell.Location = new Point(k_WidthMargin + k_PictureBoxSize * pictureBoxCell.Row, k_HeightMargin + k_PictureBoxSize * pictureBoxCell.Col);
            pictureBoxCell.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void setPlayersLabels(int i_Player1Sccore, int i_Player2Sccore)
        {
            if (m_GameDetailsArgs.PlayerOName == "[Computer]")
            {
                this.labelPlayer1Name.Text = string.Format("{0}: {1}", Enum.GetName(typeof(Player.ePlayerType), Player.ePlayerType.Computer), i_Player1Sccore);
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
            if (GameDetailsUpdated != null)
            {
                GameDetailsUpdated.Invoke(this, m_GameDetailsArgs);
            }
        }

        private void OnReceivedMovement()
        {
            if (RecivedMovement != null)
            {

                RecivedMovement.Invoke(new Movement(pictureBoxSource.PositionOnBoard, pictureBoxDestination.PositionOnBoard));
            }

        }

        private void initializeFormSize()
        {
            this.Size = new Size(((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_WidthExtention, ((int)m_GameDetailsArgs.BoardSize * k_PictureBoxSize) + k_HeightExtention);
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            PictureBoxCell pictureBoxClicked = sender as PictureBoxCell;

            if (pictureBoxSource == null)
            {
                if (pictureBoxClicked.Name != Enum.GetName(typeof(Pawn.eType), Pawn.eType.Empty))
                {
                    pictureBoxSource = pictureBoxClicked;
                    pictureBoxClicked.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            else
            {
                if (pictureBoxClicked.Name == Enum.GetName(typeof(Pawn.eType), Pawn.eType.Empty))
                {
                    pictureBoxDestination = pictureBoxClicked;
                    pictureBoxClicked.BorderStyle = BorderStyle.Fixed3D;
                    OnReceivedMovement();
                    pictureBoxClicked.BorderStyle = BorderStyle.None;
                    pictureBoxSource.BorderStyle = BorderStyle.None;
                    pictureBoxDestination = null;
                    pictureBoxSource = null;
                }
                else if (pictureBoxClicked == pictureBoxSource)
                {
                    pictureBoxClicked.BorderStyle = BorderStyle.None;
                    pictureBoxSource = null;
                }
            }
        }

        public void UpdatePictureBoxBoard(Board i_Board)
        {
            Pawn.eType pawnType = Pawn.eType.Empty;

            for (int i = 0; i < i_Board.Size; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    pawnType = i_Board.GetCellValue(i, j);
                    if (Board.IsDiffrentPairing(i, j))
                    {
                        if (isPlayer1Pawn(pawnType))
                        {
                            pictureBoxBoard[i, j].SetPictureBoxCell(Reasources.RedPawn, false, pawnType);
                        }
                        else if (isPlayer2Pawn(pawnType))
                        {
                            pictureBoxBoard[i, j].SetPictureBoxCell(Reasources.BlackPawn, true, pawnType);
                        }
                        else
                        {
                            pictureBoxBoard[i, j].SetPictureBoxCell(Reasources.Empty, true, pawnType);
                        }

                        pictureBoxBoard[i, j].Click += pictureBox_Click;
                    }
                    else
                    {
                        pictureBoxBoard[i, j].SetPictureBoxCell(Reasources.Disabled, false, Pawn.eType.Disable);
                    }
                }
            }
        }

        private bool isPlayer1Pawn(Pawn.eType i_PawnType)
        {
            return i_PawnType == Pawn.eType.OKing || i_PawnType == Pawn.eType.OPawn;
        }

        private bool isPlayer2Pawn(Pawn.eType i_PawnType)
        {
            return i_PawnType == Pawn.eType.XKing || i_PawnType == Pawn.eType.XPawn;
        }

        public void SwitchPlayers()
        {
            string playerNameSaver = null;

            if (m_GameDetailsArgs.CurrentPlayer == m_GameDetailsArgs.PreviousPlayer)
            {
                m_GameDetailsArgs.CurrentPlayer = m_GameDetailsArgs.PreviousPlayer; //== r_PlayerOName ? r_PlayerXName : r_PlayerOName;
            }
            else
            {
                playerNameSaver = m_GameDetailsArgs.CurrentPlayer;
                m_GameDetailsArgs.CurrentPlayer = m_GameDetailsArgs.PreviousPlayer;
                m_GameDetailsArgs.PreviousPlayer = playerNameSaver;
            }
        }
        public EventGameDetailsArgs GameDetailsArgs
        {
            get
            {
                return m_GameDetailsArgs;
            }
        }
    }
}
