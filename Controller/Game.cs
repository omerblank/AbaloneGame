using AbaloneGame.Model;
using AbaloneGame.View;
using AbaloneGame.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbaloneGame.Controller
{
    internal class Game
    {
        private Player whitePlayer;// the white player information
        private Player blackPlayer;// the black player information
        private Player currentPlayer;// the current player information
        private Turn playerTurn;// the turn of the current player
        private AIManager bot;// the AI bot
        private Board board;// the board

        /// <summary>
        /// constructor
        /// </summary>
        public Game()
        {
            board = new Board();
            whitePlayer = new Player(Constants.WHITE_MARBLE, "White");
            blackPlayer = new Player(Constants.BLACK_MARBLE, "Black");
            currentPlayer = blackPlayer;
            playerTurn = new Turn(this);
            bot = new AIManager(this);
        }

        /// <summary>
        /// this function makes a move of one ball
        /// </summary>
        /// <param name="marblePos"> the marble position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeOneBallMove(int marblePos, int step)
        {
            Move oneBallMove = new Move();
            if (!GameValidations.ValidateOneBallMove(board, currentPlayer, marblePos, step))
                return null;
            oneBallMove.OneBallMove(marblePos, step);
            return oneBallMove;
        }

        /// <summary>
        /// this function makes a two marbles forward move
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeTwoMarblesForwardMove(int marble1Pos, int marble2Pos, int step)
        {
            Move twoBallsMove = new Move();
            if (!board.IsInBoard(step) || board.GetCell(step) == currentPlayer.Color)
                return null;
            int step2 = board.GetNextPositionInLine(marble2Pos, step);
            if (!GameValidations.ValidateTwoBallsForwardMove(board, currentPlayer, marble1Pos, marble2Pos, step, step2))
                return null;
            if (board.GetCell(step) == Constants.EMPTY_CELL)
                twoBallsMove.TwoBallsForwardMove(marble1Pos, marble2Pos, step);
            else if (step2 == Constants.OUT_OF_BOARD)
                twoBallsMove.TwoBallsPushOneMove(marble1Pos, marble2Pos, step);
            else if (board.GetCell(step2) == Constants.EMPTY_CELL)
                twoBallsMove.TwoBallsPushOneMove(marble1Pos, marble2Pos, step, step2);
            return twoBallsMove;
        }

        /// <summary>
        /// this function makes a two marbles side move
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble2Side"> the second marble side position (destination position) </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeTwoMarblesSideMove(int marble1Pos, int marble2Pos, int marble2Side)
        {
            Move twoBallsMove = new Move();
            if (!board.IsNeighbours(marble2Pos, marble2Side))//TODO: insert it to gamevalidations
                return null;
            int pos1Side = board.GetFirstPosSide(marble1Pos, marble2Pos, marble2Side);
            if (!GameValidations.ValidateTwoBallsSideMove(board, currentPlayer, marble1Pos, marble2Pos, pos1Side, marble2Side))
                return null;
            twoBallsMove.TwoBallsSideMove(marble1Pos, marble2Pos, pos1Side, marble2Side);
            return twoBallsMove;
        }

        /// <summary>
        /// this function makes a two marbles move
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeTwoMarblesMove(int marble1Pos, int marble2Pos, int step)
        {
            if (board.IsInLine(marble1Pos, marble2Pos, step))
                return MakeTwoMarblesForwardMove(marble1Pos, marble2Pos, step);
            return MakeTwoMarblesSideMove(marble1Pos, marble2Pos, step);
        }

        /// <summary>
        /// this function makes a three marbles forward move
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble3Pos"> the third marble position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeThreeMarblesForwardMove(int marble1Pos, int marble2Pos, int marble3Pos, int step)
        {
            Move threeMarblesMove = new Move();
            int step2 = Constants.OUT_OF_BOARD, step3 = Constants.OUT_OF_BOARD;
            if (!board.IsInBoard(step))
                return null;
            if (board.GetNextPositionInLine(marble3Pos, step) != Constants.OUT_OF_BOARD)
            {
                step2 = board.GetNextPositionInLine(marble3Pos, step);
                step3 = board.GetNextPositionInLine(step, step2);
            }
            if (!GameValidations.ValidateThreeMarblesForwardMove(board, currentPlayer, marble1Pos, marble2Pos, marble3Pos, step, step2, step3))
                return null;
            if (board.GetCell(step) == Constants.EMPTY_CELL)
                threeMarblesMove.ThreeBallsForwardMove(marble1Pos, marble2Pos, marble3Pos, step);
            else if (board.GetCell(step2) == Constants.EMPTY_CELL)
                threeMarblesMove.ThreeBallsPushOneMove(marble1Pos, marble2Pos, marble3Pos, step, step2);
            else if (board.GetCell(step2) == Constants.OUT_OF_BOARD)
                threeMarblesMove.ThreeBallsPushOneMove(marble1Pos, marble2Pos, marble3Pos, step);
            else if (board.GetCell(step3) == Constants.EMPTY_CELL)
                threeMarblesMove.ThreeBallsPushTwoMove(marble1Pos, marble2Pos, marble3Pos, step, step2, step3);
            else if (board.GetCell(step3) == Constants.OUT_OF_BOARD)
                threeMarblesMove.ThreeBallsPushTwoMove(marble1Pos, marble2Pos, marble3Pos, step, step2);
            return threeMarblesMove;
        }

        /// <summary>
        /// this function makes a three marbles side move
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble3Pos"> the third marble position </param>
        /// <param name="marble3Side"> the third marble side position (destination position) </param>
        /// <returns> the move if it's valid, bull if not </returns>
        public Move MakeThreeMarblesSideMove(int marble1Pos, int marble2Pos, int marble3Pos, int marble3Side)
        {
            Move threeMarblesMove = new Move();
            if (!board.IsNeighbours(marble3Pos, marble3Side))//TODO: add it to gamevalidations
                return null;
            int marble2Side = board.GetFirstPosSide(marble2Pos, marble3Pos, marble3Side);
            int marble1Side = board.GetFirstPosSide(marble1Pos, marble2Pos, marble2Side);
            if (!GameValidations.ValidateThreeMarblesSideMove(board, currentPlayer, marble1Pos, marble2Pos, marble3Pos, marble1Side, marble2Side, marble3Side))
                return null;
            threeMarblesMove.ThreeBallsSideMove(marble1Pos, marble2Pos, marble3Pos, marble1Side, marble2Side, marble3Side);
            return threeMarblesMove;
        }

        /// <summary>
        /// this function makes a move of three balls
        /// </summary>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble3Pos"> the third marble position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> the move if it's valid, null if not </returns>
        public Move MakeThreeMarblesMove(int marble1Pos, int marble2Pos, int marble3Pos, int step)
        {
            if (!board.IsInLine(marble1Pos, marble2Pos, marble3Pos))
                return null;
            if (board.IsInLine(marble2Pos, marble3Pos, step))
                return MakeThreeMarblesForwardMove(marble1Pos, marble2Pos, marble3Pos, step);
            return MakeThreeMarblesSideMove(marble1Pos, marble2Pos, marble3Pos, step);
        }

        /// <summary>
        /// this function plays a turn in the game
        /// </summary>
        /// <param name="move"> the player's move </param>
        public void PlayTurn(Move move)
        {
            // board update
            board.UpdateBoard(move);
            // score update
            IncreaseScore(move);
            // switch player
            SwitchPlayer();
        }

        /// <summary>
        /// this function gets the index that the player chose and tries to play a turn,
        /// only if the turn is over the turn is played
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="boardPic"> the board's picture </param>
        public void TryToPlayPlayerTurn(int index, PictureBox boardPic)
        {
            Move move = playerTurn.ChosenPosition(index, currentPlayer, boardPic);
            if (move != null)
                PlayTurn(move);
        }

        /// <summary>
        /// this function gets a click input from the user in a player vs computer mode and manages the game in accordance
        /// </summary>
        /// <param name="e"> the information about the mouse event (the click) </param>
        /// <param name="boardPic"> the board's picture </param>
        public void ClickInPlayerVsComputer(MouseEventArgs e, PictureBox boardPic)
        {
            int index = GraphicUtils.ChoosePiece(boardPic.CreateGraphics(), e.X - GraphicConstants.PIECE_RADIUS, e.Y - GraphicConstants.PIECE_RADIUS, currentPlayer, board);// TODO: the problem is here
            TryToPlayPlayerTurn(index, boardPic);
            if (currentPlayer == whitePlayer)
                bot.PlayAIMove();
        }

        /// <summary>
        /// this function gets a click input from the user in a player vs player mode and manages the game in accordance
        /// </summary>
        /// <param name="e"> the information about the mouse event (the click) </param>
        /// <param name="boardPic"> the board's picture </param>
        public void ClickInPlayerVsPlayer(MouseEventArgs e, PictureBox boardPic)
        {
            int index = GraphicUtils.ChoosePiece(boardPic.CreateGraphics(), e.X - GraphicConstants.PIECE_RADIUS, e.Y - GraphicConstants.PIECE_RADIUS, currentPlayer, board);// TODO: the problem is here
            TryToPlayPlayerTurn(index, boardPic);
        }

        /// <summary>
        /// this function increases the current player's score if he made a scoring move
        /// </summary>
        /// <param name="move"> the move that the player made </param>
        public void IncreaseScore(Move move)
        {
            if (move.Score)
                currentPlayer.Score++;
        }

        /// <summary>
        /// this function switches the current player to the other player
        /// </summary>
        public void SwitchPlayer()
        {
            currentPlayer = currentPlayer.Equals(whitePlayer) ? blackPlayer : whitePlayer;
        }

        /// <summary>
        /// this function checks if the game is over
        /// </summary>
        /// <returns> true if the game is over, false if not </returns>
        public bool GameOver()
        {
            return whitePlayer.IsWinner() || blackPlayer.IsWinner();
        }

        /// <summary>
        /// this function finds the winner player
        /// </summary>  
        /// <returns> the winner player </returns>
        public Player GetWinner()
        {
            return whitePlayer.IsWinner() ? whitePlayer : blackPlayer;
        }

        /// <summary>
        /// currentPlayer properties
        /// </summary>
        public Player CurrentPlayer
        {
            get { return currentPlayer; }
            set { currentPlayer = value; }
        }

        /// <summary>
        /// board properties
        /// </summary>
        public Board Board
        {
            get { return board; }
            set { board = value; }
        }

        /// <summary>
        /// whitePlayer properties
        /// </summary>
        public Player WhitePlayer
        {
            get { return whitePlayer; }
            set { whitePlayer = value; }
        }

        /// <summary>
        /// blackPlayer properties
        /// </summary>
        public Player BlackPlayer
        {
            get { return blackPlayer; }
            set { blackPlayer = value; }
        }

        /// <summary>
        /// playerTurn properties
        /// </summary>
        public Turn PlayerTurn
        {
            get { return playerTurn; }
            set { playerTurn = value; }
        }
    }
}
