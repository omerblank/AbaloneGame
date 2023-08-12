using AbaloneGame.Controller;
using AbaloneGame.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.AI
{
    internal class AIManager
    {
        private Game game;// information about the game

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="game"> information about the game </param>
        public AIManager(Game game)
        {
            this.game = game;
        }

        /// <summary>
        /// this function evaluates the board state score
        /// </summary>
        /// <param name="board"> the board </param>
        /// <returns> the evaluated score of the board's state </returns>
        private int Evaluate(Board board)
        {
            int evaluation = 0;
            evaluation += AIUtils.MarblesAmountHeuristic(board, game.WhitePlayer) - AIUtils.MarblesAmountHeuristic(board, game.BlackPlayer);
            evaluation += AIUtils.GravityCenterHeuristic(board, game.WhitePlayer) - AIUtils.GravityCenterHeuristic(board, game.BlackPlayer);
            evaluation += AIUtils.KeepPackedHeuristic(board, game.WhitePlayer) - AIUtils.KeepPackedHeuristic(board, game.BlackPlayer);
            evaluation += AIUtils.MarblesSequenceHeuristic(board, game.WhitePlayer) - AIUtils.MarblesSequenceHeuristic(board, game.BlackPlayer);
            evaluation += AIUtils.EnemyLovesTheEdges(board, game.WhitePlayer) - AIUtils.EnemyLovesTheEdges(board, game.BlackPlayer);
            evaluation += AIUtils.LetsTrapThem(board, game.WhitePlayer) - AIUtils.LetsTrapThem(board, game.BlackPlayer);
            return evaluation;
        }

        /// <summary>
        /// this function gets the best move from the AI's moves list
        /// </summary>
        /// <returns></returns>
        private Move GetBestMove()
        {
            Move bestMove = new Move();
            int bestMoveMark = int.MinValue, currentMoveMark = 0;
            List<Move> allMoves = AIUtils.GetAllMoves(game, game.WhitePlayer);
            foreach (Move move in allMoves)
            {
                if (AIUtils.WinningMove(move, game.WhitePlayer))
                    return move;
                currentMoveMark = Evaluate(AIUtils.MakeTemporaryMove(game, move)) + AIUtils.KillingMove(move);
                if (currentMoveMark > bestMoveMark)
                {
                    bestMoveMark = currentMoveMark;
                    bestMove = move;
                }
            }
            return bestMove;
        }

        /// <summary>
        /// this function plays the AI turn
        /// </summary>
        public void PlayAIMove()
        {
            game.PlayTurn(GetBestMove());
        }
    }
}
