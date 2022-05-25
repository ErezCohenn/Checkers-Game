using EnglishCheckersLogic;
namespace EnglishCheckersWinUI
{
    public class GameManagement
    {
        private readonly Game r_EnglishCheckersLogic;
        private readonly FormGame r_FormGame;

        public GameManagement()
        {
            r_FormGame = new FormGame();
            r_EnglishCheckersLogic = new Game();

        }

        public void RunGame()
        {
            bool wantToQuit = false;

            r_FormGame.ShowDialog();
            //r_EnglishCheckersLogic.InitializeGameDetails(r_FormGameSettings.XPlayerName, r_FormGameSettings.OPlayerName, r_FormGameSettings.BoardSize, r_FormGameSettings.PlayerOType);
            do
            {
                r_EnglishCheckersLogic.InitializeSession();
                //r_UserInterface.GameDetails.InitializeSessionDetails();
                //playGameSession();
                //wantToQuit = r_UserInterface.IsPlayerWantToEndTheGame();
            }
            while (!wantToQuit);
        }

        /*private void playGameSession()
        {
            bool sessionFinished = false;
            Movement playerInputMove = null;

            do
            {
                sessionFinished = r_EnglishCheckersLogic.IsSessionFinished();
                if (!sessionFinished)
                {
                    r_UserInterface.PrintBoard(r_EnglishCheckersLogic.Board);
                    playerInputMove = getNextMoveFromCurrentPlayer();
                    if (playerInputMove == null)
                    {
                        sessionFinished = true;
                        r_EnglishCheckersLogic.FinishReason = Game.eSessionFinishType.Quit;
                    }
                    else
                    {
                        r_EnglishCheckersLogic.MoveManager(playerInputMove);
                        if (!r_EnglishCheckersLogic.EatingSequence)
                        {
                            r_UserInterface.GameDetails.SwitchPlayers();
                        }
                        else
                        {
                            r_UserInterface.GameDetails.PreviousPlayerName = r_UserInterface.GameDetails.CurrentPlayerName;
                        }
                    }
                }
            }
            while (!sessionFinished);

            r_EnglishCheckersLogic.EndGameSession();
            r_UserInterface.PrintEndSession(r_EnglishCheckersLogic.FinishReason, r_EnglishCheckersLogic.PlayerX.Score, r_EnglishCheckersLogic.PlayerO.Score, r_EnglishCheckersLogic.PreviousPlayer);
        }

        private Movement getNextMoveFromCurrentPlayer()
        {
            Movement playerNextMove = null;
            bool validMove = false;

            if (r_EnglishCheckersLogic.CurrentPlayer.PlayerType == Player.ePlayerType.Computer)
            {
                playerNextMove = r_EnglishCheckersLogic.GetComputerNextMove();
            }
            else
            {
                do
                {
                    playerNextMove = r_UserInterface.GetPlayerNextMove();
                    validMove = r_EnglishCheckersLogic.IsValidMove(playerNextMove);

                    if (!validMove)
                    {
                        r_UserInterface.PrintInvalidInputMessage();
                    }
                }
                while (!validMove);
            }

            r_UserInterface.GameDetails.LastMove = playerNextMove;

            return playerNextMove;
        }*/
    }
}
