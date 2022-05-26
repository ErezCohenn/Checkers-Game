using EnglishCheckersLogic;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public class PictureBoxCell : PictureBox
    {
        private Position m_CellOnBoard;
        private readonly string r_ResourcesFolderPath;

        public PictureBoxCell(int i_Row, int i_Col)
        {
            m_CellOnBoard = new Position(i_Row, i_Col);
            r_ResourcesFolderPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"Resources");
        }

        public Position PlaceOnBoard
        {
            get
            {
                return m_CellOnBoard;
            }
        }
        public void SetPictureBoxCell(string i_PawnImage, bool i_Enable, Pawn.eType i_CellType)
        {
            string fullFilePath = Path.Combine(r_ResourcesFolderPath, i_PawnImage);
            this.Image = Image.FromFile(fullFilePath);
            this.Name = Enum.GetName(typeof(Pawn.eType), i_CellType);
            this.Enabled = i_Enable;
        }

    }
}