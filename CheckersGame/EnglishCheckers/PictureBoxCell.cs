using EnglishCheckersLogic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public class PictureBoxCell : PictureBox
    {
        private Position m_PositionOnBoard;

        public PictureBoxCell(int i_Row, int i_Col)
        {
            m_PositionOnBoard = new Position(i_Row, i_Col);
        }

        public Position PositionOnBoard
        {
            get
            {
                return m_PositionOnBoard;
            }
        }

        public void SetPictureBoxCell(string i_PawnImage, bool i_Enable, Pawn.eType i_CellType)
        {
            string fullFilePath = Path.Combine(Reasources.ResourcesFolderPath, i_PawnImage);
            this.Image = Image.FromFile(fullFilePath);
            this.Name = Enum.GetName(typeof(Pawn.eType), i_CellType);
            this.Enabled = i_Enable;
        }

        public int Row
        {
            get
            {
                return m_PositionOnBoard.Row;
            }
        }

        public int Col
        {
            get
            {
                return m_PositionOnBoard.Col;
            }
        }
    }
}