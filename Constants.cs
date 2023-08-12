using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame
{
    internal class Constants
    {
        public static int BOARD_SIZE = 121;
        public static int WINNING_SCORE = 6;  
        public static int EAST = 11;
        public static int WEST = -11;
        public static int SOUTH_EAST = -1;
        public static int SOUTH_WEST = -12;
        public static int NORTH_EAST = 12;
        public static int NORTH_WEST = 1;
        public static List<int> DIRECTIONS = new List<int>
        {
            {EAST}, {WEST}, {SOUTH_EAST}, {SOUTH_WEST}, {NORTH_EAST}, {NORTH_WEST}
        };
        public static int EMPTY_CELL = 0;
        public static int OUT_OF_BOARD = 110;
        public static int WHITE_MARBLE = 1;
        public static int BLACK_MARBLE = -1;
        public enum MODE
        {
            PLAYER_VS_PLAYER,
            PLAYER_VS_PC
        }
    }
}
