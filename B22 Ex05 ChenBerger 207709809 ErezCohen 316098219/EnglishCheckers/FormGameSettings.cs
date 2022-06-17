using System;
using System.Windows.Forms;
using EnglishCheckersLogic;

namespace EnglishCheckersWinUI
{
    public partial class FormGameSettings : Form
    {
        private const int k_MaxNameLength = 20;
        private const string k_ComputerLabel = "[Computer]";
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
            string errorPlayerNameMessage = string.Empty;

            if (!isValidName(textButtenXPlayerName.Text, ref errorPlayerNameMessage) || !isValidName(textButtonOPlayerName.Text, ref errorPlayerNameMessage))
            {
                MessageBox.Show(errorPlayerNameMessage);
            }
            else
            {
                m_FormClosedByDoneButton = true;
                this.Close();
            }
        }

        private bool isValidName(string i_PlayerName, ref string o_ErrorPlayerNameMessage)
        {
            bool validName = true;

            if (string.IsNullOrEmpty(i_PlayerName))
            {
                validName = false;
                o_ErrorPlayerNameMessage = "Error: Player name is empty!";
            }

            if (i_PlayerName.Length > k_MaxNameLength)
            {
                validName = false;
                o_ErrorPlayerNameMessage = "Error: Player name length is too long! The max length is 20 letters";
            }

            for (int i = 0; i < i_PlayerName.Length && validName; i++)
            {
                if (char.IsWhiteSpace(i_PlayerName[i]))
                {
                    validName = false;
                    o_ErrorPlayerNameMessage = "Error: Player name cannot include spaces!";
                }
            }

            return validName;
        }

        public bool IsFormClosedByDoneButton
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