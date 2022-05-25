using System.Collections.Generic;

namespace EnglishCheckers
{
    public class Pawn
    {
        public enum eType
        {
            OPawn = 'O',
            XPawn = 'X',
            OKing = 'U',
            XKing = 'K',
            Empty = ' ',
        }

        public enum eValue
        {
            King = 4,
            Pawn = 1,
        }

        private static readonly List<Position> sr_UpDirections = new List<Position>(2);
        private static readonly List<Position> sr_DownDirections = new List<Position>(2);
        private eType m_PawnType;
        private Position m_PawnLocation;
        private eValue m_PawnValue;

        public Pawn(eType i_PawnType, Position i_PawnLocation, eValue i_PawnValue = eValue.Pawn)
        {
            m_PawnType = i_PawnType;
            m_PawnLocation = i_PawnLocation;
            m_PawnValue = i_PawnValue;
            sr_UpDirections.Add(new Position(-1, -1));
            sr_UpDirections.Add(new Position(-1, 1));
            sr_DownDirections.Add(new Position(1, -1));
            sr_DownDirections.Add(new Position(1, 1));
        }

        public bool IsKing()
        {
            return m_PawnType == eType.OKing || m_PawnType == eType.XKing;
        }

        public List<Position> GetDirectionByType()
        {
            return (m_PawnType == eType.OKing || m_PawnType == eType.OPawn) ? sr_DownDirections : sr_UpDirections;
        }

        public List<Position> SwitchDirections(List<Position> i_DirectionsToMove)
        {
            return i_DirectionsToMove == sr_DownDirections ? sr_UpDirections : sr_DownDirections;
        }

        public eType Type
        {
            get
            {
                return m_PawnType;
            }

            set
            {
                m_PawnType = value;
            }
        }

        public Position Location
        {
            get
            {
                return m_PawnLocation;
            }

            set
            {
                m_PawnLocation = value;
            }
        }

        public eValue Value
        {
            get
            {
                return m_PawnValue;
            }

            set
            {
                m_PawnValue = value;
            }
        }

        public List<Position> DownDiagonalDirections
        {
            get
            {
                return sr_DownDirections;
            }
        }

        public List<Position> UpDiagonalDirections
        {
            get
            {
                return sr_UpDirections;
            }
        }
    }
}