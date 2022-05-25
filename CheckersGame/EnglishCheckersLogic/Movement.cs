namespace EnglishCheckers
{
    public class Movement
    {
        private Position m_CurrentPlayerPosition;
        private Position m_NextPlayerPosition;

        public Movement()
        {
            m_CurrentPlayerPosition = null;
            m_NextPlayerPosition = null;
        }

        public Movement(Position i_CurrentPosition, Position i_NextPosition)
        {
            m_CurrentPlayerPosition = i_CurrentPosition;
            m_NextPlayerPosition = i_NextPosition;
        }

        public Position CurrentPosition
        {
            get
            {
                return m_CurrentPlayerPosition;
            }

            set
            {
                m_CurrentPlayerPosition = value;
            }
        }

        public Position NextPosition
        {
            get
            {
                return m_NextPlayerPosition;
            }

            set
            {
                m_NextPlayerPosition = value;
            }
        }
    }
}
