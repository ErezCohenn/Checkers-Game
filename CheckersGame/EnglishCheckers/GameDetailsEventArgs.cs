using EnglishCheckersLogic;
using System;
namespace EnglishCheckersWinUI
{
    public class EventGameDetailsArgs : EventArgs
    {
        private readonly string r_PlayerXName;
        private readonly string r_PlayerOName;
        private readonly Board.eBoradSize r_BoardSize;
        private readonly Player.ePlayerType r_PlayerOType;
        private string m_CurrentPlayer;
        private string m_PreviousPlayer;
        private Player.ePlayerSign m_CurrentPlayerSign;

        public EventGameDetailsArgs(string i_PlayerOName, string i_PlayerXName, Board.eBoradSize i_BoardSize, Player.ePlayerType i_PlayerOType)
        {
            r_PlayerXName = i_PlayerXName;
            r_PlayerOName = i_PlayerOName;
            r_BoardSize = i_BoardSize;
            r_PlayerOType = i_PlayerOType;
            m_CurrentPlayer = r_PlayerXName;
            m_CurrentPlayerSign = Player.ePlayerSign.XSign;
            m_PreviousPlayer = r_PlayerOName;
        }

        public Board.eBoradSize BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public string PlayerOName
        {
            get
            {
                return r_PlayerOName;
            }
        }

        public string PlayerXName
        {
            get
            {
                return r_PlayerXName;
            }
        }

        public Player.ePlayerType PlayerOType
        {
            get
            {
                return r_PlayerOType;
            }
        }

        public string CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }

            set
            {
                m_CurrentPlayer = value;
            }
        }

        public string PreviousPlayer
        {
            get
            {
                return m_PreviousPlayer;
            }

            set
            {
                m_PreviousPlayer = value;
            }
        }

        public Player.ePlayerSign CurrentPlayerSign
        {
            get
            {
                return m_CurrentPlayerSign;
            }

            set
            {
                m_CurrentPlayerSign = value;
            }
        }
    }
}