using System.Collections.Generic;

namespace EnglishCheckers
{
    public class Player
    {
        public enum ePlayerType
        {
            Computer,
            Human,
        }

        public enum ePlayerSign
        {
            OSign = 'O',
            XSign = 'X',
        }

        private readonly ePlayerType r_PlayerType;
        private readonly string r_PlayerName;
        private readonly ePlayerSign r_SignType;
        private List<Pawn> m_PlayerPawns;
        private List<Movement> m_RegularPossibleMoves;
        private List<Movement> m_EatingPossibleMoves;
        private int m_PlayerScore;

        public Player(ePlayerType i_PlayerType, string i_PlayerName, ePlayerSign i_SignType, Board.eBoradSize i_Size)
        {
            int sizeOfPawnsArray = getNumberOfPawnsByBoardSize(i_Size);

            r_PlayerType = i_PlayerType;
            r_PlayerName = i_PlayerName;
            r_SignType = i_SignType;
            m_PlayerScore = 0;
            m_RegularPossibleMoves = new List<Movement>();
            m_EatingPossibleMoves = new List<Movement>();
            m_PlayerPawns = new List<Pawn>(sizeOfPawnsArray);
        }

        private int getNumberOfPawnsByBoardSize(Board.eBoradSize i_Size)
        {
            return ((int)i_Size - 2) * (int)i_Size / 2;
        }

        public bool NoPawnsLeft()
        {
            return m_PlayerPawns.Count == 0;
        }

        public void InitializePawnsOnBoard(Board i_Board)
        {
            Position initializePosition = null;
            int startingRow = 0;
            int endingRow = i_Board.Size;

            if (r_SignType == ePlayerSign.OSign)
            {
                startingRow = 0;
                endingRow = (i_Board.Size - 2) / 2;
            }
            else
            {
                startingRow = (i_Board.Size + 2) / 2;
                endingRow = i_Board.Size;
            }

            m_PlayerPawns.Clear();
            for (int i = startingRow; i < endingRow; i++)
            {
                for (int j = 0; j < i_Board.Size; j++)
                {
                    if (Board.isDiffrentPairing(i, j))
                    {
                        initializePosition = new Position(i, j);
                        m_PlayerPawns.Add(new Pawn((Pawn.eType)r_SignType, initializePosition, Pawn.eValue.Pawn));
                    }
                }
            }
        }

        public int GetScore()
        {
            int playerScore = 0;

            foreach (Pawn pawn in m_PlayerPawns)
            {
                playerScore += (int)pawn.Value;
            }

            return playerScore;
        }

        public Pawn SearchPawnByLocation(Position i_CurrentPosition)
        {
            Pawn foundedPawn = null;

            foreach (Pawn pawn in m_PlayerPawns)
            {
                if (pawn.Location.Equals(i_CurrentPosition))
                {
                    foundedPawn = pawn;
                }
            }

            return foundedPawn;
        }

        public void AddOptionalMoveToMovesArray(Board i_Board, Pawn i_PawnToCheck)
        {
            List<Position> directionToMove = i_PawnToCheck.GetDirectionByType();

            createOptionalMoves(directionToMove, i_PawnToCheck.Location, i_Board);
            if (i_PawnToCheck.IsKing())
            {
                directionToMove = i_PawnToCheck.SwitchDirections(directionToMove);
                createOptionalMoves(directionToMove, i_PawnToCheck.Location, i_Board);
            }
        }

        private void createOptionalMoves(List<Position> i_DirectionsToMove, Position i_CurrentPosition, Board i_Board)
        {
            Position nextPositionToMove = null;

            foreach (Position diagonalDirection in i_DirectionsToMove)
            {
                nextPositionToMove = Position.Add(i_CurrentPosition, diagonalDirection);
                addRegularMove(i_Board, i_CurrentPosition, nextPositionToMove);
                addEatingMove(i_Board, i_CurrentPosition, nextPositionToMove);
            }
        }

        public void RemovePawnFromPawnsArray(Position i_EatenPawnLocation)
        {
            bool foundPawn = false;

            for (int i = 0; i < m_PlayerPawns.Count && !foundPawn; i++)
            {
                if (m_PlayerPawns[i].Location.Equals(i_EatenPawnLocation))
                {
                    m_PlayerPawns.RemoveAt(i);
                    foundPawn = true;
                }
            }
        }

        private void addEatingMove(Board i_Board, Position i_CurrentPosition, Position i_NextPosition)
        {
            Position nextPositionAfterEating = null;

            if (!i_Board.IsPositionOutOfRange(i_NextPosition) && isOpponent(i_Board, i_NextPosition))
            {
                nextPositionAfterEating = Position.Substract(i_NextPosition, i_CurrentPosition);
                nextPositionAfterEating.MultipleByConstant(2);
                nextPositionAfterEating = Position.Add(i_CurrentPosition, nextPositionAfterEating);
                if (isCellEmpty(i_Board, nextPositionAfterEating))
                {
                    m_EatingPossibleMoves.Add(new Movement(i_CurrentPosition, nextPositionAfterEating));
                }
            }
        }

        private bool isOpponent(Board i_Board, Position i_NextPosition)
        {
            Pawn.eType nextPositionType = i_Board.GetCellValue(i_NextPosition);
            bool result = false;

            if (r_SignType == ePlayerSign.OSign)
            {
                result = nextPositionType == Pawn.eType.XKing || nextPositionType == Pawn.eType.XPawn;
            }
            else
            {
                result = nextPositionType == Pawn.eType.OKing || nextPositionType == Pawn.eType.OPawn;
            }

            return result;
        }

        private void addRegularMove(Board i_Board, Position i_CurrentPosition, Position i_NextPosition)
        {
            if (isCellEmpty(i_Board, i_NextPosition))
            {
                m_RegularPossibleMoves.Add(new Movement(i_CurrentPosition, i_NextPosition));
            }
        }

        private bool isCellEmpty(Board i_Board, Position i_NextPosition)
        {
            return !i_Board.IsPositionOutOfRange(i_NextPosition) && i_Board.GetCellValue(i_NextPosition) == Pawn.eType.Empty;
        }

        public void CreatePossibleMoves(Board i_Board)
        {
            m_RegularPossibleMoves.Clear();
            m_EatingPossibleMoves.Clear();
            foreach (Pawn pawnToCheck in PawnsArray)
            {
                AddOptionalMoveToMovesArray(i_Board, pawnToCheck);
            }
        }

        public string Name
        {
            get
            {
                return r_PlayerName;
            }
        }

        public ePlayerSign SignType
        {
            get
            {
                return r_SignType;
            }
        }

        public int Score
        {
            get
            {
                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore = value;
            }
        }

        public ePlayerType PlayerType
        {
            get
            {
                return r_PlayerType;
            }
        }

        public List<Pawn> PawnsArray
        {
            get
            {
                return m_PlayerPawns;
            }

            set
            {
                m_PlayerPawns = value;
            }
        }

        public List<Movement> RegularPossibleMoves
        {
            get
            {
                return m_RegularPossibleMoves;
            }

            set
            {
                m_RegularPossibleMoves = value;
            }
        }

        public List<Movement> EatingPossibleMoves
        {
            get
            {
                return m_EatingPossibleMoves;
            }

            set
            {
                m_EatingPossibleMoves = value;
            }
        }
    }
}