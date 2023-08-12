using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.Model
{
    internal class Player
    {
        private int color; // the color of the player (black/white)
        private int score; // the score of the player (0-6)
        private string name; // the name of the player

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="color"> the color of the player (represented as an integer constant value) </param>
        /// <param name="name"> the name of the player </param>
        public Player(int color, string name)
        {
            this.color = color;
            score = 0;
            this.name = name;
        }

        /// <summary>
        /// this function checks if this player wins
        /// </summary>
        /// <returns> true if the player wins, false if not </returns>
        public bool IsWinner()
        {
            return score == Constants.WINNING_SCORE;
        }

        /// <summary>
        /// color properties
        /// </summary>
        public int Color
        {
            get { return color; }
            set { color = value; }
        }

        /// <summary>
        /// score properties
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// name properties
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
