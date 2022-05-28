namespace EnglishCheckersLogic
{
    public class Board
    {
        public enum eBoradSize
        {
            Small = 6,
            Medium = 8,
            Large = 10
        }

        private readonly int r_Size;
        private readonly Pawn.eType[,] r_GameBoard;
        private readonly int r_FirstRow;
        private readonly int r_LastRow;

        public Board(eBoradSize i_BoardSize)
        {
            r_Size = (int)i_BoardSize;
            r_GameBoard = new Pawn.eType[r_Size, r_Size];
            r_FirstRow = 0;
            r_LastRow = r_Size - 1;
        }

        public static bool IsDiffrentPairing(int i_FirstNumber, int i_SecondNumber)
        {
            return (i_FirstNumber % 2) != (i_SecondNumber % 2);
        }

        public void Clear()
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    r_GameBoard[i, j] = Pawn.eType.Empty;
                }
            }
        }

        public bool IsPositionOutOfRange(Position i_PositionToCheck)
        {
            bool isInValidPosition = false;

            if (i_PositionToCheck.Row < 0 || i_PositionToCheck.Row >= r_Size || i_PositionToCheck.Col < 0 || i_PositionToCheck.Col >= r_Size)
            {
                isInValidPosition = true;
            }

            return isInValidPosition;
        }

        public void InitializeBoard()
        {
            for (int i = 0; i < r_Size; i++)
            {
                for (int j = 0; j < r_Size; j++)
                {
                    if (IsDiffrentPairing(i, j))
                    {
                        if (i < (r_Size - 2) / 2)
                        {
                            r_GameBoard[i, j] = Pawn.eType.OPawn;
                        }
                        else if (i > ((r_Size + 2) / 2) - 1)
                        {
                            r_GameBoard[i, j] = Pawn.eType.XPawn;
                        }
                        else
                        {
                            r_GameBoard[i, j] = Pawn.eType.Empty;
                        }
                    }
                    else
                    {
                        r_GameBoard[i, j] = Pawn.eType.Empty;
                    }
                }
            }
        }

        public void DeletePawnFromBoard(Position i_PositionToDelete)
        {
            r_GameBoard[i_PositionToDelete.Row, i_PositionToDelete.Col] = Pawn.eType.Empty;
        }

        public void SetCellValue(Position i_PositionToUpdate, Pawn.eType i_CellType)
        {
            r_GameBoard[i_PositionToUpdate.Row, i_PositionToUpdate.Col] = i_CellType;
        }

        public Pawn.eType GetCellValue(Position i_Position)
        {
            return r_GameBoard[i_Position.Row, i_Position.Col];
        }

        public Pawn.eType GetCellValue(int i_Row, int i_Col)
        {
            return r_GameBoard[i_Row, i_Col];
        }

        public int Size
        {
            get
            {
                return r_Size;
            }
        }

        public int FirstRow
        {
            get
            {
                return r_FirstRow;
            }
        }

        public int LastRow
        {
            get
            {
                return r_LastRow;
            }
        }
    }
}