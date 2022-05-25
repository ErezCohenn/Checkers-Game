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
        private bool m_EatingSequence;
        private eSessionFinishType m_FinishReason;
        public EventHandler GameFinshed;

        public Game()
        {
            m_PlayerO = null;
            m_PlayerX = null;
            m_Board = null;
            m_CurrentPlayer = null;
            m_PreviousPlayer = null;
            m_EatingSequence = false;
            m_FinishReason = eSessionFinishType.Won;
        }

        public void InitializeGameDetails(string i_PlayerOName, string i_PlayerXName, Board.eBoradSize i_BoardSize, Player.ePlayerType i_PlayerOType)
        {
            m_PlayerO = new Player(i_PlayerOType, i_PlayerOName, Player.ePlayerSign.OSign, i_BoardSize);
            m_PlayerX = new Player(Player.ePlayerType.Human, i_PlayerXName, Player.ePlayerSign.XSign, i_BoardSize);
            m_Board = new Board(i_BoardSize);
            InitializeSession();
        }

        public void InitializeSession()
        {
            m_Board.InitializeBoard();
            m_PlayerX.InitializePawnsOnBoard(m_Board);
            m_PlayerO.InitializePawnsOnBoard(m_Board);
            m_CurrentPlayer = m_PlayerX;
            m_PreviousPlayer = m_PlayerO;
        }

        public bool IsSessionFinished()
        {
            return m_CurrentPlayer.NoPawnsLeft() || hasNoAvailableMoves(m_CurrentPlayer);
        }

        private bool hasNoAvailableMoves(Player io_PlayerToCheck)
        {
            if (!EatingSequence)
            {
                io_PlayerToCheck.CreatePossibleMoves(m_Board);
            }

            return io_PlayerToCheck.EatingPossibleMoves.Count == 0 && io_PlayerToCheck.RegularPossibleMoves.Count == 0;
        }

        public void EndGameSession()
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
            if (GameFinshed != null)
            {
                GameFinshed.Invoke(this, null);
            }
        }

        public void MoveManager(Movement io_NextMove)
        {
            Pawn destinedPawnToMove = m_CurrentPlayer.SearchPawnByLocation(io_NextMove.CurrentPosition);
            bool ateInLastMove = false;

            ExecuteMove(io_NextMove, destinedPawnToMove, ref ateInLastMove);
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
        }

        private void switchPlayers()
        {
            Player playerSaver = m_CurrentPlayer;
            m_CurrentPlayer = m_PreviousPlayer;
            m_PreviousPlayer = playerSaver;
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

        public void ExecuteMove(Movement i_NextMoveToExecute, Pawn io_PawnToMove, ref bool io_AteInCurrentMove)
        {
            Position eatenPawnLocation = null;
            Position directionToMove = Position.Substract(i_NextMoveToExecute.NextPosition, i_NextMoveToExecute.CurrentPosition);
            int diffrenceBetweenPositions = System.Math.Abs(directionToMove.Row);

            if (diffrenceBetweenPositions == 2)
            {
                eatenPawnLocation = new Position(i_NextMoveToExecute.CurrentPosition.Row + (directionToMove.Row / 2), i_NextMoveToExecute.CurrentPosition.Col + (directionToMove.Col / 2));
                removePawnFromBoard(m_PreviousPlayer, eatenPawnLocation);
                io_AteInCurrentMove = true;
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

        public Movement GetComputerNextMove()
        {
            Movement nextComputerMove = new Movement();
            int indexInMovesArrForNextMove = 0;
            Random randomNumber = new Random();

            if (m_CurrentPlayer.EatingPossibleMoves.Count > 0)
            {
                indexInMovesArrForNextMove = randomNumber.Next(0, m_CurrentPlayer.EatingPossibleMoves.Count);
                nextComputerMove = m_CurrentPlayer.EatingPossibleMoves[indexInMovesArrForNextMove];
            }
            else
            {
                indexInMovesArrForNextMove = randomNumber.Next(0, m_CurrentPlayer.RegularPossibleMoves.Count);
                nextComputerMove = m_CurrentPlayer.RegularPossibleMoves[indexInMovesArrForNextMove];
            }

            return nextComputerMove;
        }

        public bool IsValidMove(Movement i_playerInputedMove)
        {
            List<Movement> moveArrayToSearch = (m_CurrentPlayer.EatingPossibleMoves.Count > 0) ? m_CurrentPlayer.EatingPossibleMoves : m_CurrentPlayer.RegularPossibleMoves;

            return i_playerInputedMove == null || SearchForValidMoveInMovesArr(i_playerInputedMove, moveArrayToSearch);
        }

        public bool SearchForValidMoveInMovesArr(Movement i_PlayerDesiredMove, List<Movement> i_MovesArr)
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
