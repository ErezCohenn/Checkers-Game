namespace EnglishCheckersLogic
{
    public class Position
    {
        private int m_Row;
        private int m_Col;

        public Position(int i_Row = -1, int i_Col = -1)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }

        public static Position Add(Position i_FirstPosition, Position i_SecondPosition)
        {
            return new Position(i_FirstPosition.Row + i_SecondPosition.Row, i_FirstPosition.Col + i_SecondPosition.Col);
        }

        public static Position Substract(Position i_Minuend, Position i_Substractor)
        {
            return new Position(i_Minuend.Row - i_Substractor.Row, i_Minuend.Col - i_Substractor.Col);
        }

        public void MultipleByConstant(int i_Constant)
        {
            m_Row *= i_Constant;
            m_Col *= i_Constant;
        }

        public bool Equals(Position i_PositionToCheck)
        {
            return m_Row == i_PositionToCheck.m_Row && m_Col == i_PositionToCheck.Col;
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        public void SetPosition(Position i_NewPosition)
        {
            m_Row = i_NewPosition.Row;
            m_Col = i_NewPosition.Col;
        }

        public void SetPosition(int i_Row, int i_Col)
        {
            m_Row = i_Row;
            m_Col = i_Col;
        }
    }
}