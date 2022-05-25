using System;
using System.Windows.Forms;

namespace EnglishCheckersLogic
{
    public partial class FormGameSettings : Form
    {

        private const string k_ComputerLabel = "[Computer]";
        public FormGameSettings()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerTypeCheckBoxButton_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox playerTypeCheckBox = sender as CheckBox;

            if (playerTypeCheckBox.Checked)
            {
                oPlayerName.Enabled = true;
                oPlayerName.Text = string.Empty;
            }
            else
            {
                oPlayerName.Enabled = false;
                oPlayerName.Text = k_ComputerLabel;
            }
        }

        public string XPlayerName
        {
            get
            {
                return xPlayerName.Text;
            }

        }

        public string OPlayerName
        {
            get
            {
                return oPlayerName.Text;
            }
        }

        public Player.ePlayerType PlayerOType
        {
            get
            {
                return playerTypeCheckBoxButton.Checked == true ? Player.ePlayerType.Human : Player.ePlayerType.Computer;
            }
        }

        public Board.eBoradSize BoardSize
        {
            get
            {
                Board.eBoradSize boardSize = Board.eBoradSize.Medium;


                if (smallBoardSizeRadioButton.Checked)
                {
                    boardSize = Board.eBoradSize.Small;
                }
                else if (mediumBoardSizeRadioButton.Checked)
                {
                    boardSize = Board.eBoradSize.Medium;
                }
                else
                {
                    boardSize = Board.eBoradSize.Large;
                }

                return boardSize;
            }
        }
    }
}
