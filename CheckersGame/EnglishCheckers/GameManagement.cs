using EnglishCheckersLogic;
using System;
using System.Windows.Forms;

namespace EnglishCheckersWinUI
{
    public class GameManagement
    {
        private readonly string r_InvalidInputmessage = "Invalid move entered, please try again";
        private readonly string r_InvalidInputBoxtitle = "Error";
        private readonly Game r_EnglishCheckersLogic;
        private readonly FormGame r_FormGame;

        public GameManagement()
        {
            r_FormGame = new FormGame();
            r_EnglishCheckersLogic = new Game();

        }

        public void RunGame()
        {
            r_FormGame.GameDetailsUpdated += r_FormGame_GameDetailsUpdated;
            r_FormGame.YesNoMessageBoxClicked += r_FormGame_YesNoMessageBoxClicked;
            r_FormGame.RecivedMovement += r_FormGame_RecivedMovment;
            r_EnglishCheckersLogic.GameFinshed += r_EnglishCheckersLogic_GameFinished;
            r_EnglishCheckersLogic.GameStarted += r_EnglishCheckersLogic_GameStarted;
            r_EnglishCheckersLogic.BoardUpdated += r_EnglishCheckersLogic_BoardUpdated;
            r_FormGame.ShowDialog();
        }

        private void r_EnglishCheckersLogic_BoardUpdated(Board i_Board)
        {
            r_FormGame.UpdatePictureBoxBoard(i_Board);
        }

        private void r_EnglishCheckersLogic_GameStarted(Game i_Game)
        {
            r_FormGame.SetNewSession(i_Game.PlayerX.Score, i_Game.PlayerO.Score, i_Game.CurrentPlayer.Name);
        }

        private void r_FormGame_YesNoMessageBoxClicked(object sender, EventArgs e)
        {
            YesNoMessageBoxEventArgs yesNoMessageBoxEventArgs = e as YesNoMessageBoxEventArgs;

            if (yesNoMessageBoxEventArgs.IsPressedYesInMessageBox)
            {
                r_EnglishCheckersLogic.InitializeSession();
                r_EnglishCheckersLogic_GameStarted(r_EnglishCheckersLogic);
            }
            else
            {
                r_FormGame.Close();
            }
        }

        private void r_EnglishCheckersLogic_GameFinished(object sender)
        {
            Game gameLogic = sender as Game;

            r_FormGame.ContinuePlayingMessageBox(gameLogic);
        }

        private void r_FormGame_GameDetailsUpdated(object sender, EventArgs e)
        {
            EventGameDetailsArgs gameDetails = e as EventGameDetailsArgs;
            r_EnglishCheckersLogic.InitializeGameDetails(gameDetails.PlayerXName, gameDetails.PlayerOName, gameDetails.BoardSize, gameDetails.PlayerOType);
        }

        private void r_FormGame_RecivedMovment(Movement sender)
        {
            if (r_EnglishCheckersLogic.IsValidMove(sender))
            {
                r_EnglishCheckersLogic.MoveManager(sender);
                if (!r_EnglishCheckersLogic.EatingSequence)
                {
                    r_FormGame.SwitchPlayers();
                }
                else
                {
                    r_FormGame.GameDetailsArgs.PreviousPlayer = r_FormGame.GameDetailsArgs.CurrentPlayer;
                }
            }
            else
            {
                MessageBox.Show(r_InvalidInputmessage, r_InvalidInputBoxtitle);
            }
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
