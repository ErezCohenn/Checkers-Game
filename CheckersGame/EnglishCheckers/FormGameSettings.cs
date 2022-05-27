using EnglishCheckersLogic;
using System;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public partial class FormGameSettings : Form
    {
        private System.Windows.Forms.Label labelBoardSize;
        private System.Windows.Forms.Label labelPlayers;
        private System.Windows.Forms.Label labelPlayer1;
        private System.Windows.Forms.TextBox textButtenXPlayerName;
        private System.Windows.Forms.TextBox textButtonOPlayerName;
        private System.Windows.Forms.CheckBox checkBoxButtonPlayerTypeCheck;
        private System.Windows.Forms.RadioButton radioButtonSmallBoardSize;
        private System.Windows.Forms.RadioButton radioButtonMediumBoardSize;
        private System.Windows.Forms.RadioButton radioButtonLargeBoardSize;
        private System.Windows.Forms.Button buttonDone;
        private bool m_FormClosedByDoneButton = false;
        private const string k_ComputerLabel = "[Computer]";

        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void playerTypeCheckBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox playerTypeCheckBox = sender as CheckBox;

            if (playerTypeCheckBox.Checked)
            {
                textButtonOPlayerName.Enabled = true;
                textButtonOPlayerName.Text = string.Empty;
            }
            else
            {
                textButtonOPlayerName.Enabled = false;
                textButtonOPlayerName.Text = k_ComputerLabel;
            }
        }

        public string XPlayerName
        {
            get
            {
                return textButtenXPlayerName.Text;
            }

        }

        public string OPlayerName
        {
            get
            {
                return textButtonOPlayerName.Text;
            }
        }

        public Player.ePlayerType PlayerOType
        {
            get
            {
                return checkBoxButtonPlayerTypeCheck.Checked == true ? Player.ePlayerType.Human : Player.ePlayerType.Computer;
            }
        }

        public Board.eBoradSize BoardSize
        {
            get
            {
                Board.eBoradSize boardSize = Board.eBoradSize.Medium;

                if (radioButtonSmallBoardSize.Checked)
                {
                    boardSize = Board.eBoradSize.Small;
                }
                else if (radioButtonMediumBoardSize.Checked)
                {
                    boardSize = Board.eBoradSize.Medium;
                }
                else if (radioButtonLargeBoardSize.Checked)
                {
                    boardSize = Board.eBoradSize.Large;
                }

                return boardSize;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textButtenXPlayerName.Text) || string.IsNullOrEmpty(textButtonOPlayerName.Text))
            {
                MessageBox.Show("Error: A player name cannot be empty!");
            }
            else
            {
                m_FormClosedByDoneButton = true;
                this.Close();
            }
        }

        public bool FormClosedByDoneButton
        {
            get
            {
                return m_FormClosedByDoneButton;
            }
        }

        public string ComputerLabel
        {
            get
            {
                return k_ComputerLabel;
            }
        }
    }
}