using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.AI
{
    internal class AIConstants
    {
        // a list the represents the circles in the board -> the more the circle is close to the edges, the more it's bigger
        public static readonly List<int>[] BOARD_CIRCLES = new List<int>[]
        {
            new List<int> {60},// most inner circle
            new List<int> {61, 72, 71, 59, 48, 49},                                                                             
            new List<int> {62, 73, 84, 83, 82, 70, 58, 47, 36, 37, 38, 50},                                                     
            new List<int> {63, 74, 85, 96, 95, 94, 93, 81, 69, 57, 46, 35, 24, 25, 26, 27, 39, 51},                             
            new List<int> {64, 75, 86, 97, 108, 107, 106, 103, 104, 92, 80, 68, 56, 45, 34, 23, 12, 13, 14, 15, 16, 28, 40, 52} // most outer circle
        };
        public static int GRAVITY_CENTER_MARK = 50;// a mark to multiply gravity center heuristic with
        public static int MARBLES_SEQUENCE_MARK = 20;// a mark to multiply marbles sequence heuristic with
        public static int KEEP_PACKED_MARK = 50;// a mark to multiply keep packed heuristic with
        public static int MARBLES_AMOUNT_MARK = 100;// a mark to multiply marbles amount heuristic with
        public static int SCORING_MARK = 10000;// a mark to multiply a scoring move heuristic with
        public static int ENEMY_LOVES_THE_EDGES_MARK = 10; // a mark to multiply enemy loves the edegs heuristic with
        public static int LETS_TRAP_THEM_MARK = 20; // a mark to multiply enemy loves the edegs heuristic with
    }
}
