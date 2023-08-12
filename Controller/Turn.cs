using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbaloneGame.Controller
{
    internal class Turn
    {
        private int[] indexes;// the indexes on the board that the player choose for his turn
        private Game game;// the information about the game
        
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="game"> the information about the game </param>
        public Turn(Game game)
        {
            indexes = new int[6];
            ResetIndexes();
            this.game = game;
        }

        /// <summary>
        /// this function gets an index that the player chose and adds it to the player's turn,
        /// if it's the last position, it returns the whole move
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> null if the turn isn't over or if the move is invalid </returns>
        public Move ChosenPosition(int index, Player currentPlayer, PictureBox pictureBox)
        {
            if (FirstPosition(index, currentPlayer))
                return null;
            return NextPosition(index, currentPlayer, pictureBox);
        }

        /// <summary>
        /// this function checks if the current position is the first position that the player chose
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <returns> true if it's the first position that the player chose, false if not </returns>
        private bool FirstPosition(int index, Player currentPlayer)
        {
            if (indexes[0] == -1 && game.Board.GetCell(index) == currentPlayer.Color)
            {
                indexes[0] = index;
                return true;
            }
            return false;
        }

        /// <summary>
        /// this function checks if the current position is the second position that the player chose
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> true if it's the second position that the player chose, false if not </returns>
        private bool SecondPosition(int index, Player currentPlayer, PictureBox pictureBox)
        {
            if (indexes[1] == -1)
            {
                if (game.Board.IsNeighbours(indexes[0], index))
                    indexes[1] = index;
                else
                    CancelTurn(pictureBox);
                return true;
            }
            return false;
        }

        /// <summary>
        /// this function checks if the current position is the third position that the player chose, 
        /// it adds it to the turn if it is and it's a legal choice, if not the turn is cancelled
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        private void ThirdPosition(int index, Player currentPlayer, PictureBox pictureBox)
        {
            if (indexes[2] == -1 && game.Board.IsInLine(indexes[0], indexes[1], index))
                indexes[2] = index;
            else
                CancelTurn(pictureBox);
        }

        /// <summary>
        /// this function adds the position the the player chose to the turn, if it's illegal the turn is cancelled, if it's the last position it returns the whole move
        /// </summary>
        /// <param name="index"> the chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns></returns>
        private Move NextPosition(int index, Player currentPlayer, PictureBox pictureBox)
        {
            if (currentPlayer.Color == game.Board.GetCell(index))
            {
                if (SecondPosition(index, currentPlayer, pictureBox))
                    return null;
                else
                {
                    ThirdPosition(index, currentPlayer, pictureBox);
                    return null;
                }
            }
            return LastPosition(index, currentPlayer, pictureBox);
        }

        /// <summary>
        /// this function makes a move of one marble if it's valid and reset the turn, if not the turn is cancelled
        /// </summary>
        /// <param name="index"> the index to move to </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> the move of the one marble if it's valid, if not returns null </returns>
        private Move OneMarbleSelected(int index, Player currentPlayer, PictureBox pictureBox)
        {
            Move oneMarbleMove = new Move();
            oneMarbleMove = game.MakeOneBallMove(indexes[0], index);
            return MakeSelectedMove(currentPlayer, pictureBox, oneMarbleMove);
        }

        /// <summary>
        /// this function makes a move of two marbles if it's valid and reset the turn, if not the turn is cancelled
        /// </summary>
        /// <param name="index"> the index to move to </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> the move of the two marbles if it's valid, if not returns null </returns>
        private Move TwoMarblesSelected(int index, Player currentPlayer, PictureBox pictureBox)
        {
            Move twoMarblesMove = new Move();
            twoMarblesMove = game.MakeTwoMarblesMove(indexes[0], indexes[1], index);
            return MakeSelectedMove(currentPlayer, pictureBox, twoMarblesMove);
        }

        /// <summary>
        /// this function makes a move of three marbles if it's valid and reset the turn, if not the turn is cancelled
        /// </summary>
        /// <param name="index"> the index to move to </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> the move of the three marbles if it's valid, if not returns null </returns>
        private Move ThreeMarblesSelected(int index, Player currentPlayer, PictureBox pictureBox)
        {
            Move threeMarblesMove = new Move();
            threeMarblesMove = game.MakeThreeMarblesMove(indexes[0], indexes[1], indexes[2], index);
            return MakeSelectedMove(currentPlayer, pictureBox, threeMarblesMove);
        }

        /// <summary>
        /// this function makes a move if it's valid and reset the turn, if not the turn is cancelled
        /// </summary>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <param name="selectedMove"> the selected move </param>
        /// <returns> the move if it's valid, if not returns null </returns>
        private Move MakeSelectedMove(Player currentPlayer, PictureBox pictureBox, Move selectedMove)
        {
            if (selectedMove == null)
            {
                CancelTurn(pictureBox);
                return null;
            }
            ResetIndexes();
            return selectedMove;
        }

        /// <summary>
        /// this function gets the last position that the player chose and finishes the turn,
        /// returns the move if the turn has been finished properly, if not, returns null
        /// </summary>
        /// <param name="index"> the last chosen index </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="pictureBox"> the board's picture </param>
        /// <returns> the move if it's valid, null if not </returns>
        private Move LastPosition(int index, Player currentPlayer, PictureBox pictureBox)
        {
            if (indexes[0] == -1)
                return null;
            else if (indexes[1] == -1)
                return OneMarbleSelected(index, currentPlayer, pictureBox);
            else if (indexes[2] == -1)
                return TwoMarblesSelected(index, currentPlayer, pictureBox);
            return ThreeMarblesSelected(index, currentPlayer, pictureBox);
        }

        /// <summary>
        /// this function cancels the turn, it prints a message the show to the user that the move is invalid and reset the turn
        /// </summary>
        /// <param name="pictureBox"> the board's picture </param>
        private void CancelTurn(PictureBox pictureBox)
        {
            MessageBox.Show("Invalid Move");
            pictureBox.Invalidate();
            ResetIndexes();
        }

        /// <summary>
        /// this function reset the indexes array (reset the turn)
        /// </summary>
        private void ResetIndexes()
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                indexes[i] = -1;
            }
        }

        /// <summary>
        /// indexes array properties
        /// </summary>
        public int[] Indexes
        {
            get { return indexes; }
            set { indexes = value; }
        }
    }
}
