using AbaloneGame.Controller;
using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbaloneGame.View
{
    internal class GraphicUtils
    {

        /// <summary>
        /// this function paints the board in his current state
        /// </summary>
        /// <param name="board"> the board </param>
        /// <param name="turn"> the current turn </param>
        /// <param name="graphics"> the graphics </param>
        public static void Paint(Board board, Turn turn, Graphics graphics)
        {
            Pen pen = new Pen(Brushes.Blue);
            pen.Width = 2.5F;
            for (int i = 0; i < board.EdgeOfBoard.Size; i++)
            {
                if (board.WhiteSet.Get(i))
                {
                    graphics.DrawImage(Properties.Resources.white_marble,
                        GraphicConstants.BOARD_TO_SCREEN[i].X,
                        GraphicConstants.BOARD_TO_SCREEN[i].Y,
                        GraphicConstants.PIECE_RADIUS * 2,
                        GraphicConstants.PIECE_RADIUS * 2
                        );
                }
                if (board.BlackSet.Get(i))
                {
                    graphics.DrawImage(Properties.Resources.black_marble,
                        GraphicConstants.BOARD_TO_SCREEN[i].X,
                        GraphicConstants.BOARD_TO_SCREEN[i].Y,
                        GraphicConstants.PIECE_RADIUS * 2,
                        GraphicConstants.PIECE_RADIUS * 2
                        );
                }
            }

            // running on all the marbles that the player chose and rounding them with a circle
            for (int j = 0; j < turn.Indexes.Length; j++)
            {
                if (turn.Indexes[j] != -1)
                {
                    graphics.DrawEllipse(pen, GraphicConstants.BOARD_TO_SCREEN[turn.Indexes[j]].X, GraphicConstants.BOARD_TO_SCREEN[turn.Indexes[j]].Y, GraphicConstants.PIECE_RADIUS * 2, GraphicConstants.PIECE_RADIUS * 2);
                }
            }
        }

        /// <summary>
        /// this function gets the selected point on the screen that the player chose and returns it's index in the board structure
        /// </summary>
        /// <param name="g"> the graphics </param>
        /// <param name="x"> the point's x </param>
        /// <param name="y"> the point's y </param>
        /// <param name="currentPlayer"> the current player </param>
        /// <param name="board"> the board </param>
        /// <returns> the index in the board structure </returns>
        public static int ChoosePiece(Graphics g, int x, int y, Player currentPlayer, Board board)
        {
            int chosenIndex = 0;
            foreach (int index in GraphicConstants.BOARD_TO_SCREEN.Keys)
            {
                if (DistanceFormula(GraphicConstants.BOARD_TO_SCREEN[index], new Point(x, y)) <= GraphicConstants.PIECE_RADIUS) // user clicked on a circle of the board
                {
                    chosenIndex = index;
                }
            }
            return chosenIndex;
        }

        /// <summary>
        /// this function calculates the distance between two points in the plain
        /// </summary>
        /// <param name="firstPoint"> the first point </param>
        /// <param name="secondPoint"> the second point </param>
        /// <returns> the distance between the points </returns>
        private static double DistanceFormula(Point firstPoint, Point secondPoint)
        {
            return Math.Sqrt(Math.Pow(firstPoint.X - secondPoint.X, 2) + Math.Pow(firstPoint.Y - secondPoint.Y, 2));
        }
    }
}
