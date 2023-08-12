using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.View
{
    internal class GraphicConstants
    {
        public static int PIECE_RADIUS = 30;// the radius of a piece (in pixels)

        // a dictionary with the following data:
        // keys: the positions on the board structure
        // values: the positions on the screen
        public static readonly Dictionary<int, Point> BOARD_TO_SCREEN = new Dictionary<int, Point>()
        {
            { 64, new Point(205, 108) },
            { 75, new Point(270, 108) },
            { 86, new Point(335, 108) },
            { 97, new Point(400, 108) },
            { 108, new Point(465, 108) },

            { 52, new Point(175, 165) },
            { 63, new Point(240, 165) },
            { 74, new Point(305, 165) },
            { 85, new Point(370, 165) },
            { 96, new Point(435, 165) },
            { 107, new Point(500, 165) },

            { 40, new Point(140, 222) },
            { 51, new Point(205, 222) },
            { 62, new Point(270, 222) },
            { 73, new Point(335, 222) },
            { 84, new Point(400, 222) },
            { 95, new Point(465, 222) },
            { 106, new Point(530, 222) },

            { 28, new Point(110, 279) },
            { 39, new Point(175, 279) },
            { 50, new Point(240, 279) },
            { 61, new Point(305, 279) },
            { 72, new Point(370, 279) },
            { 83, new Point(435, 279) },
            { 94, new Point(500, 279) },
            { 105, new Point(565, 279) },

            { 16, new Point(75, 336) },
            { 27, new Point(140, 336) },
            { 38, new Point(205, 336) },
            { 49, new Point(270, 336) },
            { 60, new Point(335, 336) },
            { 71, new Point(400, 336) },
            { 82, new Point(465, 336) },
            { 93, new Point(530, 336) },
            { 104, new Point(595, 336) },

            { 15, new Point(110, 393) },
            { 26, new Point(175, 393) },
            { 37, new Point(240, 393) },
            { 48, new Point(305, 393) },
            { 59, new Point(370, 393) },
            { 70, new Point(435, 393) },
            { 81, new Point(500, 393) },
            { 92, new Point(565, 393) },

            { 14, new Point(140, 450) },
            { 25, new Point(205, 450) },
            { 36, new Point(270, 450) },
            { 47, new Point(335, 450) },
            { 58, new Point(400, 450) },
            { 69, new Point(465, 450) },
            { 80, new Point(530, 450) },

            { 13, new Point(175, 507) },
            { 24, new Point(240, 507) },
            { 35, new Point(305, 507) },
            { 46, new Point(370, 507) },
            { 57, new Point(435, 507) },
            { 68, new Point(500, 507) },

            { 12, new Point(205, 564) },
            { 23, new Point(270, 564) },
            { 34, new Point(335, 564) },
            { 45, new Point(400, 564) },
            { 56, new Point(465, 564) }
        };
    }
}
