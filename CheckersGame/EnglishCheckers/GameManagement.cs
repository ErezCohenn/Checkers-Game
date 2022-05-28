using EnglishCheckersLogic;
using System;
using System.Windows.Forms;

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
            listenToWinUIEvents();
            listenToGameLogicEvents();
            r_FormGame.ShowDialog();
        }

        private void listenToGameLogicEvents()
        {
            r_EnglishCheckersLogic.GameFinshed += r_EnglishCheckersLogic_GameFinished;
            r_EnglishCheckersLogic.GameStarted += r_EnglishCheckersLogic_GameStarted;
            r_EnglishCheckersLogic.BoardUpdated += r_EnglishCheckersLogic_BoardUpdated;
            r_EnglishCheckersLogic.SwitchedPlayers += r_EnglishCheckersLogic_SwitchedPlayers;
        }

        private void listenToWinUIEvents()
        {
            r_FormGame.GameDetailsUpdated += r_FormGame_GameDetailsUpdated;
            r_FormGame.YesNoMessageBoxClicked += r_FormGame_YesNoMessageBoxClicked;
            r_FormGame.RecivedMovement += r_FormGame_RecivedMovment;
        }

        private void r_EnglishCheckersLogic_SwitchedPlayers()
        {
            r_FormGame.SwitchPlayers();
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

            r_EnglishCheckersLogic.InitializeGame(gameDetails.PlayerXName, gameDetails.PlayerOName, gameDetails.BoardSize, gameDetails.PlayerOType);
        }

        private void r_FormGame_RecivedMovment(Movement i_NextMove)
        {
            bool validMove = r_EnglishCheckersLogic.MoveManager(i_NextMove);

            if (!validMove)
            {
                MessageBox.Show("Invalid move entered, please try again", "Error");
            }
        }
    }
}