using AbaloneGame.Controller;
using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.AI
{
    internal static class AIUtils
    {


        //--------------------------------------------------------------------MOVES--------------------------------------------------------------------//


        /// <summary>
        /// this function search for all the optional moves for a player
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="player"> information about the player </param>
        /// <returns> a list with all the optional moves for the player </returns>
        public static List<Move> GetAllMoves(Game game, Player player)
        {
            List<Move> moves = new List<Move>();
            AddAllOneMarbleMoves(game, moves, player);
            AddAllTwoMarbleMoves(game, moves, player);
            AddAllThreeMarbleMoves(game, moves, player);
            return moves;
        }

        /// <summary>
        /// this function makes a temporary move on a cloned board
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="move"> the temporary move </param>
        /// <returns> the cloned board after the temporary move </returns>
        public static Board MakeTemporaryMove(Game game, Move move)
        {
            Board tempBoard = game.Board.CloneBoard();
            tempBoard.UpdateBoard(move);
            return tempBoard;
        }

        /// <summary>
        /// this function adds all the optional one marble moves in the current state
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="board"> information about the board </param>
        /// <param name="moves"> the moves list </param>
        /// <param name="currentPlayer"> the current player </param>
        private static void AddAllOneMarbleMoves(Game game, List<Move> moves, Player currentPlayer)
        {
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (game.Board.GetCell(i) == currentPlayer.Color)
                {
                    AddOptionalOneMarbleMoves(game, i, moves);
                }
            }
        }

        /// <summary>
        /// this function adds all the optional two marbles moves in the current state
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="board"> information about the board </param>
        /// <param name="moves"> the moves list </param>
        /// <param name="currentPlayer"> the current player </param>
        private static void AddAllTwoMarbleMoves(Game game, List<Move> moves, Player currentPlayer)
        {
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (game.Board.GetCell(i) == currentPlayer.Color)
                {
                    int[] neighbours = game.Board.GetNeighbors(i);
                    for (int j = 0; j < neighbours.Length; j++)
                    {
                        if (neighbours[j] != Constants.OUT_OF_BOARD && game.Board.GetCell(neighbours[j]) == currentPlayer.Color)
                        {
                            AddOptionalTwoMarblesMoves(game, i, neighbours[j], moves);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// this function adds all the optional three marbles moves in the current state
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="board"> information about the board </param>
        /// <param name="moves"> the moves list </param>
        /// <param name="currentPlayer"> the current player </param>
        private static void AddAllThreeMarbleMoves(Game game, List<Move> moves, Player currentPlayer)
        {
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (game.Board.GetCell(i) == currentPlayer.Color)
                {
                    int[] neighbours = game.Board.GetNeighbors(i);
                    for (int j = 0; j < neighbours.Length; j++)
                    {
                        if (neighbours[j] != Constants.OUT_OF_BOARD && game.Board.GetCell(neighbours[j]) == currentPlayer.Color)
                        {
                            int[] farNeighbours = game.Board.GetNeighbors(neighbours[j]);
                            for (int k = 0; k < farNeighbours.Length; k++)
                            {
                                if (farNeighbours[k] != Constants.OUT_OF_BOARD && farNeighbours[k] != i && game.Board.GetCell(farNeighbours[k]) == currentPlayer.Color)
                                {
                                    AddOptionalThreeMarblesMoves(game, i, neighbours[j], farNeighbours[k], moves);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// this function gets a marble indexe and adds all the valid moves this marble can make to the moves list 
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="marbleIndex"> the marble's index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddOptionalOneMarbleMoves(Game game, int marbleIndex, List<Move> moves)
        {
            Move oneMarbleMove = new Move();
            int[] neighbours = game.Board.GetNeighbors(marbleIndex);
            for (int i = 0; i < neighbours.Length; i++)
            {
                if (game.Board.IsInBoard(neighbours[i]))
                    AddOneMarbleMoveIfValid(game, marbleIndex, neighbours[i], moves);
            }
        }

        /// <summary>
        /// this function gets two marbles indexes and adds all the valid moves those marbles can make to the moves list 
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="firstMarbleIndex"> the first marble index </param>
        /// <param name="secondMarbleIndex"> the second marble index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddOptionalTwoMarblesMoves(Game game, int firstMarbleIndex, int secondMarbleIndex, List<Move> moves)
        {
            Move twoMarblesMove = new Move();
            int[] secondMarbleNeighbours = game.Board.GetNeighbors(secondMarbleIndex);
            int direction = secondMarbleIndex - firstMarbleIndex;
            // check if able to make a forward move
            AddTwoMarblesMoveIfValid(game, firstMarbleIndex, secondMarbleIndex, secondMarbleIndex + direction, moves);
            AddTwoMarblesMoveIfValid(game, secondMarbleIndex, firstMarbleIndex, firstMarbleIndex - direction, moves);
            // check if able to make a side move
            for (int i = 0; i < secondMarbleNeighbours.Length; i++)
            {
                if (game.Board.IsInBoard(secondMarbleNeighbours[i]) && game.Board.GetCell(secondMarbleNeighbours[i]) == Constants.EMPTY_CELL && game.Board.GetCell(secondMarbleNeighbours[i]) == Constants.EMPTY_CELL)
                    AddTwoMarblesMoveIfValid(game, firstMarbleIndex, secondMarbleIndex, secondMarbleNeighbours[i], moves);
            }
        }

        /// <summary>
        /// this function gets three marbles indexes and adds all the valid moves those marbles can make to the moves list 
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="firstMarbleIndex"> the first marble index </param>
        /// <param name="secondMarbleIndex"> the second marble index </param>
        /// <param name="thirdMarbleIndex"> the third marble index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddOptionalThreeMarblesMoves(Game game, int firstMarbleIndex, int secondMarbleIndex, int thirdMarbleIndex, List<Move> moves)
        {
            int[] thirdMarbleNeighbours = game.Board.GetNeighbors(thirdMarbleIndex);
            int direction = secondMarbleIndex - firstMarbleIndex;
            // check if able to make a forward move
            AddThreeMarblesMoveIfValid(game, firstMarbleIndex, secondMarbleIndex, thirdMarbleIndex, thirdMarbleIndex + direction, moves);
            AddThreeMarblesMoveIfValid(game, firstMarbleIndex, secondMarbleIndex, thirdMarbleIndex, firstMarbleIndex - direction, moves);
            // check if able to make a side move
            for (int i = 0; i < thirdMarbleNeighbours.Length; i++)
            {
                if (game.Board.IsInBoard(thirdMarbleNeighbours[i]))
                    AddThreeMarblesMoveIfValid(game, firstMarbleIndex, secondMarbleIndex, thirdMarbleIndex, thirdMarbleNeighbours[i], moves);
            }
        }

        /// <summary>
        /// this function adds a one marble move to the moves list if it's valid
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="marbleIndex"> the marble index </param>
        /// <param name="to"> the destination index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddOneMarbleMoveIfValid(Game game, int marbleIndex, int to, List<Move> moves)
        {
            Move oneMarbleMove = new Move();
            oneMarbleMove = game.MakeOneBallMove(marbleIndex, to);
            if (oneMarbleMove != null)
                moves.Add(oneMarbleMove);
        }

        /// <summary>
        /// this function adds a two marbles move to the moves list if it's valid
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="firstMarbleIndex"> the first marble index </param>
        /// <param name="secondMarbleIndex"> the second marble index </param>
        /// <param name="to"> the detination index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddTwoMarblesMoveIfValid(Game game, int firstMarbleIndex, int secondMarbleIndex, int to, List<Move> moves)
        {
            Move twoMarblesMove = new Move();
            twoMarblesMove = game.MakeTwoMarblesMove(firstMarbleIndex, secondMarbleIndex, to);
            if (twoMarblesMove != null)
                moves.Add(twoMarblesMove);
        }

        /// <summary>
        /// this function adds a three marbles move to the moves list if it's valid
        /// </summary>
        /// <param name="game"> information about the game </param>
        /// <param name="firstMarbleIndex"> the first marble index </param>
        /// <param name="secondMarbleIndex"> the second marble index </param>
        /// <param name="thirdMarbleIndex"> the third marble index </param>
        /// <param name="to"> the destination index </param>
        /// <param name="moves"> the moves list </param>
        private static void AddThreeMarblesMoveIfValid(Game game, int firstMarbleIndex, int secondMarbleIndex, int thirdMarbleIndex, int to, List<Move> moves)
        {
            Move threeMarblesMove = new Move();
            threeMarblesMove = game.MakeThreeMarblesMove(firstMarbleIndex, secondMarbleIndex, thirdMarbleIndex, to);
            if (threeMarblesMove != null)
                moves.Add(threeMarblesMove);
        }


        //--------------------------------------------------------------------Heuristics--------------------------------------------------------------------//


        // util function for KeepPackedHeuristic, it checks how many of the given piece neighbours are the same as the player's color and adds it to the result, and how many are different and subs it from the result.
        private static int NeighborsCounterValue(int color, int[] neighbors, Board board)
        {
            int count = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                if (board.GetCell(neighbors[i]) == color)
                    count++;
                else if (board.GetCell(neighbors[i]) == -color)
                    count--;
            }
            return count;
        }

        // util function for ThreeInARowHeuristic, it checks the Sequence of marbles in a specific index
        // returns 2 if it's a 3 marbles sequence, 1 if it's a 2 marble sequence and 0 if there's no sequence.
        private static int CheckSequence(Board board, int bitIndex, int direction, Player player)
        {
            if (board.GetCell(bitIndex + direction) == Constants.OUT_OF_BOARD)
                return OutOfBoardInDirectionSequnce(board, bitIndex, direction, player);
            else if (board.GetCell(bitIndex - direction) == Constants.OUT_OF_BOARD)
                return OutOfBoardInDirectionSequnce(board, bitIndex, -direction, player);
            else
                return InsideBoardInDirectionSequence(board, bitIndex, direction, player);
        }

        /// <summary>
        /// this function checks the sequence of marbles in a given direction that if we go in its way we go out of board
        /// </summary>
        /// <param name="board"> the game board </param>
        /// <param name="bitIndex"> the index in the board </param>
        /// <param name="direction"> the direction we go in </param>
        /// <param name="player"> the current player </param>
        /// <returns> the mark for the sequence (2 for 3 marbles sequnce, 1 for 2 marbles sequence and 0 for 1 marble) </returns>
        private static int OutOfBoardInDirectionSequnce(Board board, int bitIndex, int direction, Player player)
        {
            if (board.GetCell(bitIndex - direction) == player.Color && board.GetCell(bitIndex - direction * 2) == player.Color && board.GetCell(bitIndex - direction * 3) != -player.Color)
                return 2;
            else if (board.GetCell(bitIndex - direction) == player.Color && board.GetCell(bitIndex - direction * 2) != -player.Color)
                return 1;
            return 0;
        }

        /// <summary>
        /// this function checks the sequence of marbles in a given direction
        /// </summary>
        /// <param name="board"> the game board </param>
        /// <param name="bitIndex"> the index in the board </param>
        /// <param name="direction"> the direction we go in </param>
        /// <param name="player"> the current player </param>
        /// <returns> the mark for the sequence (2 for 3 marbles sequnce, 1 for 2 marbles sequence and 0 for 1 marble) </returns>
        private static int InsideBoardInDirectionSequence(Board board, int bitIndex, int direction, Player player)
        {
            if (board.GetCell(bitIndex + direction) == player.Color && board.GetCell(bitIndex - direction) == player.Color && board.GetCell(bitIndex + direction * 2) != -player.Color && board.GetCell(bitIndex - direction * 2) != -player.Color)
                return 2;
            else if ((board.GetCell(bitIndex + direction) == player.Color && board.GetCell(bitIndex + direction * 2) != -player.Color && board.GetCell(bitIndex - direction) != -player.Color) || (board.GetCell(bitIndex - direction) == player.Color && board.GetCell(bitIndex - direction * 2) != -player.Color && board.GetCell(bitIndex + direction) != -player.Color))
                return 1;
            return 0;
        }

        // util function for ThreeInARowHeuristic, it checks the Horizontal Sequence of marbles in a specific index
        private static int CheckHorizontalSequence(Board board, int index, Player player)
        {
            return CheckSequence(board, index, Constants.EAST, player);
        }

        // util function for ThreeInARowHeuristic, it checks the Left Diagonal Sequence of marbles in a specific index
        private static int CheckLeftDiagonalSequence(Board board, int index, Player player)
        {
            return CheckSequence(board, index, Constants.SOUTH_EAST, player);
        }

        // util function for ThreeInARowHeuristic, it checks the Right Diagonal Sequence of marbles in a specific index
        private static int CheckRightDiagonalSequence(Board board, int index, Player player)
        {
            return CheckSequence(board, index, Constants.NORTH_EAST, player);
        }

        // util function for ThreeInARowHeuristic, it checks all the sequences of marbles in a specific index
        private static int CheckAllSequences(Board board, int index, Player player)
        {
            return CheckHorizontalSequence(board, index, player) + CheckLeftDiagonalSequence(board, index, player) + CheckRightDiagonalSequence(board, index, player);
        }

        /// <summary>
        /// this function checks if a marble is trapped in the edge of the board
        /// </summary>
        /// <param name="color"> the color of the marble </param>
        /// <param name="marbleNeighbours"> the neighbours of the marble </param>
        /// <returns> true if the marble is trapped, false if not </returns>
        private static bool IsTrapped(int color, int[] marbleNeighbours)
        {
            for (int i = 0; i < marbleNeighbours.Length; i++)
            {
                if (marbleNeighbours[i] != Constants.OUT_OF_BOARD && marbleNeighbours[i] != -color)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// this function checks whether the player's balls are close to the center of the board,
        /// The closer they are, the higher the mark will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int GravityCenterHeuristic(Board board, Player player)
        {
            int mark = 0;
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (board.GetCell(i) == player.Color)
                {
                    for (int j = 0; j < AIConstants.BOARD_CIRCLES.Length; j++)
                    {
                        if (AIConstants.BOARD_CIRCLES[j].Contains(i))
                            mark += (AIConstants.BOARD_CIRCLES.Length - j);
                    }
                }
            }
            return mark * AIConstants.GRAVITY_CENTER_MARK;
        }

        /// <summary>
        /// this function checks how many three marble (AND NOT MORE) or two marble sequences the player has,
        /// the more sequences of threes there are, the higher the score will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int MarblesSequenceHeuristic(Board board, Player player)
        {
            int mark = 0;
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (board.GetCell(i) == player.Color)
                {
                    mark += CheckAllSequences(board, i, player);
                }
            }
            return mark * AIConstants.MARBLES_SEQUENCE_MARK;
        }

        /// <summary>
        /// this function checks the position of the player's marbles on the board, 
        /// the closer and denser they are, the higher the score will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int KeepPackedHeuristic(Board board, Player player)
        {
            int mark = 0;
            int[] neighbors;
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (board.GetCell(i) == player.Color)
                {
                    neighbors = board.GetNeighbors(i);
                    mark += NeighborsCounterValue(player.Color, neighbors, board);
                }
            }
            return mark * AIConstants.KEEP_PACKED_MARK;
        }

        /// <summary>
        /// this function checks how many marbles each player has,
        /// The greater the difference between the player's marbles and the opponent's marbles in favor of the player, the higher the score will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int MarblesAmountHeuristic(Board board, Player player)
        {
            int mark = 0;
            for (int i = 0; i < Constants.BOARD_SIZE; i++)
            {
                if (board.GetCell(i) == player.Color)
                    mark++;
                else if (board.GetCell(i) == -player.Color)
                    mark--;
            }
            return mark * AIConstants.MARBLES_AMOUNT_MARK;
        }

        /// <summary>
        /// this function checks if the enemy player has marbles in the edges of the board,
        /// the greater the marbles of enemy in the edges of the board, the higher the score will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int EnemyLovesTheEdges(Board board, Player player)
        {
            int mark = 0;
            foreach(int index in AIConstants.BOARD_CIRCLES[4])
            { 
                if (board.GetCell(index) == -player.Color)
                    mark++;
            }
            return mark * AIConstants.ENEMY_LOVES_THE_EDGES_MARK;
        }

        /// <summary>
        /// this function checks if the current player trapped the enemy in the edge,
        /// the greater the trapped enemy's balls, the higher the score will be
        /// </summary>
        /// <param name="board"> information about the board </param>
        /// <param name="player"> information about the player </param>
        /// <returns> the calculated mark </returns>
        public static int LetsTrapThem(Board board, Player player)
        {
            int mark = 0;
            foreach (int index in AIConstants.BOARD_CIRCLES[4])
            {
                if (board.GetCell(index) == -player.Color && IsTrapped(-player.Color, board.GetNeighbors(index)))
                    mark++;
            }
            return mark * AIConstants.LETS_TRAP_THEM_MARK;
        }

        /// <summary>
        /// this function checks if a move is a scoring move
        /// </summary>
        /// <param name="move"> the move </param>
        /// <param name="player"> the player that makes this move </param>
        /// <returns> a mark for scoring move, or 0 if it's not a scoring move </returns>
        public static int KillingMove(Move move)
        {
            if (move.Score)
                return AIConstants.SCORING_MARK;
            return 0;
        }

        /// <summary>
        /// this function checks if a move is the winning move
        /// </summary>
        /// <param name="move"> the move </param>
        /// <param name="player"> the player that makes this move </param>
        /// <returns> true if the move is the winning move, false if not </returns>
        public static bool WinningMove(Move move, Player player)
        {
            if (move.Score && player.Score == Constants.WINNING_SCORE - 1)
                return true;
            return false;
        }
    }
}
