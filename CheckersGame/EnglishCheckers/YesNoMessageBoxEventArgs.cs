using System;

namespace EnglishCheckersWinUI
{
    public class YesNoMessageBoxEventArgs : EventArgs
    {
        private readonly bool r_IsPressedYesInMessageBox;

        public YesNoMessageBoxEventArgs(bool i_IsPressedYesInMessageBox)
        {
            r_IsPressedYesInMessageBox = i_IsPressedYesInMessageBox;
        }

        public bool IsPressedYesInMessageBox
        {
            get
            {
                return r_IsPressedYesInMessageBox;
            }
        }
    }
}
