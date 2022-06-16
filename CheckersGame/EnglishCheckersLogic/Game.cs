using System;
using System.Collections.Generic;
using Random = System.Random;

namespace EnglishCheckersLogic
{
    public class Game
    {
        public enum eSessionFinishType
        {
            Quit,
            Won,
            Draw,
        }

        private Player m_PlayerO;
        private Player m_PlayerX;
        private Board m_Board;
        private Player m_CurrentPlayer;
        private Player m_PreviousPlayer;
        private Movement m_ComputerMove;
        private bool m_EatingSequence;
        private eSessionFinishType m_FinishReason;
        private Random m_RandomNumber;

        public event Action<Game> GameFinished;

        public event Action<Game> GameStarted;

        public event Action<Board> BoardUpdated;

        public event Action SwitchedPlayers;

        public Game()
        {
            m_PlayerO = null;
            m_PlayerX = null;
            m_Board = null;
            m_CurrentPlayer = null;
            m_PreviousPlayer = null;
            m_ComputerMove = null;
            m_EatingSequence = false;
            m_FinishReason = eSessionFinishType.Won;
            m_RandomNumber = new Random();
        }

        public void InitializeGame(string i_PlayerXName, string i_PlayerOName, Board.eBoradSize i_BoardSize, Player.ePlayerType i_PlayerOType)
        {
            initializeGameDetails(i_PlayerXName, i_PlayerOName, i_BoardSize, i_PlayerOType);
            InitializeSession();
        }

        private void initializeGameDetails(string i_PlayerXName, string i_PlayerOName, Board.eBoradSize i_BoardSize, Player.ePlayerType i_PlayerOType)
        {
            if (i_PlayerOType == Player.ePlayerType.Computer)
            {
                m_ComputerMove = new Movement();
            }

            m_PlayerO = new Player(i_PlayerOType, i_PlayerOName, Player.ePlayerSign.OSign, i_BoardSize);
            m_PlayerX = new Player(Player.ePlayerType.Human, i_PlayerXName, Player.ePlayerSign.XSign, i_BoardSize);
            m_Board = new Board(i_BoardSize);
        }

        private void OnGameStarted()
        {
            if (GameStarted != null)
            {
                GameStarted.Invoke(this);
            }
        }

        private void OnBoardUpdated()
        {
            if (BoardUpdated != null)
            {
                BoardUpdated.Invoke(m_Board);
            }
        }

        public void InitializeSession()
        {
            m_Board.InitializeBoard();
            m_PlayerX.InitializePawnsOnBoard(m_Board);
            m_PlayerO.InitializePawnsOnBoard(m_Board);
            m_CurrentPlayer = m_PlayerX;
            m_PreviousPlayer = m_PlayerO;
            OnGameStarted();
            OnBoardUpdated();
        }

        private bool isSessionFinished()
        {
            return m_CurrentPlayer.NoPawnsLeft() || hasNoAvailableMoves(m_CurrentPlayer);
        }

        private bool hasNoAvailableMoves(Player io_PlayerToCheck)
        {
            createPossibleMoves();

            return io_PlayerToCheck.EatingPossibleMoves.Count == 0 && io_PlayerToCheck.RegularPossibleMoves.Count == 0;
        }

        private void createPossibleMoves()
        {
            if (!m_EatingSequence)
            {
                m_CurrentPlayer.CreatePossibleMoves(m_Board);
            }
        }

        private void endGameSession()
        {
            if (m_FinishReason.Equals(eSessionFinishType.Quit))
            {
                m_PreviousPlayer.Score += m_PreviousPlayer.GetScore();
            }
            else if (hasNoAvailableMoves(PreviousPlayer))
            {
                m_FinishReason = eSessionFinishType.Draw;
            }
            else
            {
                m_FinishReason = eSessionFinishType.Won;
                m_PreviousPlayer.Score += m_PreviousPlayer.GetScore() - m_CurrentPlayer.GetScore();
            }

            OnGameFinished();
        }

        private void OnGameFinished()
        {
            if (GameFinished != null)
            {
                GameFinished.Invoke(this);
            }
        }

        public bool MoveManager(Movement io_NextMove)
        {
            Pawn destinedPawnToMove = null;
            bool ateInLastMove = false;
            bool validMove = true;

            if (!isValidMove(io_NextMove))
            {
                validMove = false;
            }
            else
            {
                destinedPawnToMove = m_CurrentPlayer.SearchPawnByLocation(io_NextMove.CurrentPosition);
                executeMove(io_NextMove, destinedPawnToMove, ref ateInLastMove);
                if (m_EatingSequence)
                {
                    m_EatingSequence = false;
                }

                if (shouldBecomeAKing(destinedPawnToMove))
                {
                    destinedPawnToMove.Type = (destinedPawnToMove.Type == Pawn.eType.OPawn) ? Pawn.eType.OKing : Pawn.eType.XKing;
                    destinedPawnToMove.Value = Pawn.eValue.King;
                    m_Board.SetCellValue(destinedPawnToMove.Location, destinedPawnToMove.Type);
                }

                if (ateInLastMove)
                {
                    m_CurrentPlayer.RegularPossibleMoves.Clear();
                    m_CurrentPlayer.EatingPossibleMoves.Clear();
                    m_CurrentPlayer.AddOptionalMoveToMovesArray(m_Board, destinedPawnToMove);
                    if (m_CurrentPlayer.EatingPossibleMoves.Count > 0)
                    {
                        m_EatingSequence = true;
                    }
                }

                if (!m_EatingSequence)
                {
                    switchPlayers();
                }

                OnBoardUpdated();
                if (isSessionFinished())
                {
                    endGameSession();
                }
                else if (m_CurrentPlayer.PlayerType == Player.ePlayerType.Computer)
                {
                    setComputerNextMove();
                    MoveManager(m_ComputerMove);
                }
            }

            return validMove;
        }

        private void OnSwitchedPlayers()
        {
            if (SwitchedPlayers != null)
            {
                SwitchedPlayers.Invoke();
            }
        }

        private void switchPlayers()
        {
            Player playerSaver = m_CurrentPlayer;

            m_CurrentPlayer = m_PreviousPlayer;
            m_PreviousPlayer = playerSaver;
            OnSwitchedPlayers();
        }

        private bool shouldBecomeAKing(Pawn i_DestinedPawnToMove)
        {
            bool canBecomeAKing = false;

            if (i_DestinedPawnToMove.Type == Pawn.eType.OPawn && i_DestinedPawnToMove.Location.Row == m_Board.LastRow)
            {
                canBecomeAKing = true;
            }
            else if (i_DestinedPawnToMove.Type == Pawn.eType.XPawn && i_DestinedPawnToMove.Location.Row == m_Board.FirstRow)
            {
                canBecomeAKing = true;
            }

            return canBecomeAKing;
        }

        private void executeMove(Movement i_NextMoveToExecute, Pawn io_PawnToMove, ref bool o_AteInCurrentMove)
        {
            Position eatenPawnLocation = null;
            Position directionToMove = Position.Substract(i_NextMoveToExecute.NextPosition, i_NextMoveToExecute.CurrentPosition);
            int diffrenceBetweenPositions = System.Math.Abs(directionToMove.Row);

            if (diffrenceBetweenPositions == 2)
            {
                eatenPawnLocation = new Position(i_NextMoveToExecute.CurrentPosition.Row + (directionToMove.Row / 2), i_NextMoveToExecute.CurrentPosition.Col + (directionToMove.Col / 2));
                removePawnFromBoard(m_PreviousPlayer, eatenPawnLocation);
                o_AteInCurrentMove = true;
            }

            updatePawnOnBoard(io_PawnToMove, i_NextMoveToExecute);
        }

        private void updatePawnOnBoard(Pawn io_CurrentPawn, Movement i_NextMove)
        {
            m_Board.SetCellValue(i_NextMove.CurrentPosition, Pawn.eType.Empty);
            m_Board.SetCellValue(i_NextMove.NextPosition, io_CurrentPawn.Type);
            io_CurrentPawn.Location = i_NextMove.NextPosition;
        }

        private void removePawnFromBoard(Player io_PreviousPlayer, Position i_EatenPawnLocation)
        {
            m_Board.SetCellValue(i_EatenPawnLocation, Pawn.eType.Empty);
            io_PreviousPlayer.RemovePawnFromPawnsArray(i_EatenPawnLocation);
        }

        private void setComputerNextMove()
        {
            int indexInMovesArrForNextMove = 0;

            if (m_CurrentPlayer.EatingPossibleMoves.Count > 0)
            {
                indexInMovesArrForNextMove = m_RandomNumber.Next(0, m_CurrentPlayer.EatingPossibleMoves.Count);
                m_ComputerMove = m_CurrentPlayer.EatingPossibleMoves[indexInMovesArrForNextMove];
            }
            else
            {
                createPossibleMoves();
                indexInMovesArrForNextMove = m_RandomNumber.Next(0, m_CurrentPlayer.RegularPossibleMoves.Count);
                m_ComputerMove = m_CurrentPlayer.RegularPossibleMoves[indexInMovesArrForNextMove];
            }
        }

        private bool isValidMove(Movement i_PlayerInputedMove)
        {
            List<Movement> moveArrayToSearch = null;

            createPossibleMoves();
            moveArrayToSearch = (m_CurrentPlayer.EatingPossibleMoves.Count > 0) ? m_CurrentPlayer.EatingPossibleMoves : m_CurrentPlayer.RegularPossibleMoves;

            return i_PlayerInputedMove == null || searchForValidMoveInMovesArr(i_PlayerInputedMove, moveArrayToSearch);
        }

        private bool searchForValidMoveInMovesArr(Movement i_PlayerDesiredMove, List<Movement> i_MovesArr)
        {
            bool nextDesiredMoveFound = false;

            for (int i = 0; i < i_MovesArr.Count && !nextDesiredMoveFound; i++)
            {
                if (i_MovesArr[i].CurrentPosition.Equals(i_PlayerDesiredMove.CurrentPosition) && i_MovesArr[i].NextPosition.Equals(i_PlayerDesiredMove.NextPosition))
                {
                    nextDesiredMoveFound = true;
                }
            }

            return nextDesiredMoveFound;
        }

        public Board Board
        {
            get
            {
                return m_Board;
            }

            set
            {
                m_Board = value;
            }
        }

        public Player PlayerX
        {
            get
            {
                return m_PlayerX;
            }

            set
            {
                m_PlayerX = value;
            }
        }

        public Player PlayerO
        {
            get
            {
                return m_PlayerO;
            }

            set
            {
                m_PlayerO = value;
            }
        }

        public Player CurrentPlayer
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

        public Player PreviousPlayer
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

        public bool EatingSequence
        {
            get
            {
                return m_EatingSequence;
            }

            set
            {
                m_EatingSequence = value;
            }
        }

        public eSessionFinishType FinishReason
        {
            get
            {
                return m_FinishReason;
            }

            set
            {
                m_FinishReason = value;
            }
        }
    }
}
