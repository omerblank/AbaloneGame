using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.Controller
{
    internal class GameValidations
    {
        /// <summary>
        /// this function validates that the current player has a marble with his color in the given position
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="position"> the position in the board </param>
        /// <returns> true if the player has a marble with his color in the given position, false if not </returns>
        private static bool ValidatePlayer(Board board, Player currentPlayer, int position)
        {
            if (board.GetCell(position) == currentPlayer.Color)
                return true;
            return false;
        }

        /// <summary>
        /// this function validates a one ball move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="ballPos"> the ball position </param>
        /// <param name="step"> the destination position </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        public static bool ValidateOneBallMove(Board board, Player currentPlayer, int ballPos, int step)
        {
            if (!ValidatePlayer(board, currentPlayer, ballPos) || board.GetCell(step) != Constants.EMPTY_CELL)
                return false;
            if (!board.IsNeighbours(ballPos, step))
                return false;
            if (board.GetCell(step) == Constants.OUT_OF_BOARD)
                return false;
            if (board.GetCell(step) == -currentPlayer.Color)
                return false;
            return true;
        }

        /// <summary>
        /// this function validates a two balls side move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="ball1Pos"> the first ball position </param>
        /// <param name="ball2Pos"> the second ball position </param>
        /// <param name="ball1Side"> the first ball side position (destination position) </param>
        /// <param name="ball2Side"> the second ball side position (destination position) </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        public static bool ValidateTwoBallsSideMove(Board board, Player currentPlayer, int ball1Pos, int ball2Pos, int ball1Side, int ball2Side)
        {
            ValidateTwoBallsMove(board, currentPlayer, ball1Pos, ball2Pos);
            if (!board.IsNeighbours(ball2Pos, ball2Side) || board.GetCell(ball1Side) != Constants.EMPTY_CELL || board.GetCell(ball2Side) != Constants.EMPTY_CELL)
                return false;
            return true;
        }

        /// <summary>
        /// this function validates a two balls forward move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="ball1Pos"> the first ball position </param>
        /// <param name="ball2Pos"> the second ball position </param>
        /// <param name="step"> the desitnation position </param>
        /// <param name="step2"> the position after the destination position </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        public static bool ValidateTwoBallsForwardMove(Board board, Player currentPlayer, int ball1Pos, int ball2Pos, int step, int step2)
        {
            ValidateTwoBallsMove(board, currentPlayer, ball1Pos, ball2Pos);
            if (!board.IsInLine(ball1Pos, ball2Pos, step))
                return false;
            if (board.GetCell(step) == Constants.OUT_OF_BOARD)
                return false;
            if (board.GetCell(step) == -currentPlayer.Color && board.GetCell(step2) == -currentPlayer.Color)
                return false;
            if (board.GetCell(step) == -currentPlayer.Color && board.GetCell(step2) == currentPlayer.Color)
                return false;
            if (board.GetCell(step) == currentPlayer.Color && board.GetCell(step2) == currentPlayer.Color)
                return false;
            return true;
        }

        /// <summary>
        /// this function validates a two balls move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="ball1Pos"> the first ball position </param>
        /// <param name="ball2Pos"> the second ball position </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        private static bool ValidateTwoBallsMove(Board board, Player currentPlayer, int ball1Pos, int ball2Pos)
        {
            if (!board.IsNeighbours(ball1Pos, ball2Pos))
                return false;
            if (!ValidatePlayer(board, currentPlayer, ball1Pos) || !ValidatePlayer(board, currentPlayer, ball2Pos))
                return false;
            return true;
        }

        /// <summary>
        /// this function validates a three marbles side move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble3Pos"> the third marble position </param>
        /// <param name="marble1Side"> the first marble side position (destination position) </param>
        /// <param name="marble2Side"> the second marble side position (destination position) </param>
        /// <param name="marble3Side"> the third marble side position (destination position) </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        public static bool ValidateThreeMarblesSideMove(Board board, Player currentPlayer, int marble1Pos, int marble2Pos, int marble3Pos, int marble1Side, int marble2Side, int marble3Side)
        {
            ValidateThreeMarblesMove(board, currentPlayer, marble1Pos, marble2Pos, marble3Pos);
            if (!board.IsNeighbours(marble3Pos, marble3Side) || board.GetCell(marble1Side) != Constants.EMPTY_CELL || board.GetCell(marble2Side) != Constants.EMPTY_CELL || board.GetCell(marble3Side) != Constants.EMPTY_CELL)
                return false;
            return true;
        }

        /// <summary>
        /// this function validates a three marbles forward move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="marble1Pos"> the first marble position </param>
        /// <param name="marble2Pos"> the second marble position </param>
        /// <param name="marble3Pos"> the third marble position </param>
        /// <param name="step"> the destination position </param>
        /// <param name="step2"> the position after the destination position </param>
        /// <param name="step3"> the position after the position that after the destination position </param>
        /// <returns> true if the move is valid, if not returns false </returns>
        public static bool ValidateThreeMarblesForwardMove(Board board, Player currentPlayer, int marble1Pos, int marble2Pos, int marble3Pos, int step, int step2, int step3)
        {
            ValidateThreeMarblesMove(board, currentPlayer, marble1Pos, marble2Pos, marble3Pos);
            if (!board.IsInLine(marble2Pos, marble3Pos, step))
                return false;
            if (board.GetCell(step) == Constants.OUT_OF_BOARD)
                return false;
            if (board.GetCell(step) == currentPlayer.Color)
                return false;
            if (board.GetCell(step2) != Constants.OUT_OF_BOARD)
            {
                if (board.GetCell(step) == -currentPlayer.Color && board.GetCell(step2) == -currentPlayer.Color && board.GetCell(step3) == -currentPlayer.Color)
                    return false;
                if ((board.GetCell(step) == -currentPlayer.Color && board.GetCell(step2) == currentPlayer.Color || board.GetCell(step) == -currentPlayer.Color && board.GetCell(step2) == -currentPlayer.Color) && board.GetCell(step3) == currentPlayer.Color)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// this function validate a three marbles move
        /// </summary>
        /// <param name="board"> the game's board </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="ball1Pos"> the first ball position </param>
        /// <param name="ball2Pos"> the second ball position </param>
        /// <param name="ball3Pos"> the third ball position </param>
        /// <returns></returns>
        private static bool ValidateThreeMarblesMove(Board board, Player currentPlayer, int ball1Pos, int ball2Pos, int ball3Pos)
        {
            if (!ValidatePlayer(board, currentPlayer, ball1Pos) || !ValidatePlayer(board, currentPlayer, ball2Pos) || !ValidatePlayer(board, currentPlayer, ball3Pos))
                return false;
            if (!board.IsInLine(ball1Pos, ball2Pos, ball3Pos))
                return false;
            return true;
        }
    }
}
