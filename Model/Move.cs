using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbaloneGame.Model
{
    internal class Move
    {
        private int attackMarbles;// player's amount of balls to move
        private int defenseMarbles;// enemy's amount of balls to push
        private int[] indexes;// indexes array.
        private bool score;// ON if the move is a scoring move
        private bool sideStep;// ON if the move is a side step move 

        ///----------------------------------------- FORWARD NO PUSHING MOVES -----------------------------------------///

        /// <summary>
        /// constructor
        /// </summary>
        public Move()
        {
            this.attackMarbles = 0;
            this.defenseMarbles = 0;
            this.indexes = new int[6];
            this.score = false;
            this.sideStep = false;
        }

        /// <summary>
        /// this function represents a move for one ball
        /// </summary>
        /// <param name="ballPos"> the position of the ball </param>
        /// <param name="to"> the position the ball moves to </param>
        public void OneBallMove(int ballPos, int to)
        {
            indexes = new int[2];
            indexes[0] = ballPos;
            indexes[1] = to;
            defenseMarbles = 0;
            attackMarbles = 1;
            score = false;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for two balls that move forward
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="to"> the destination position </param>
        public void TwoBallsForwardMove(int ball1Pos, int ball2Pos, int to)
        {
            indexes = new int[3];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = to;
            defenseMarbles = 0;
            attackMarbles = 2;
            score = false;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for three balls that move forward
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="to"> the destination position </param>
        public void ThreeBallsForwardMove(int ball1Pos, int ball2Pos, int ball3Pos, int to)
        {
            indexes = new int[4];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = to;
            defenseMarbles = 0;
            attackMarbles = 3;
            score = false;
            sideStep = false;
        }

        ///----------------------------------------- FORWARD PUSHING NO SCORING MOVES -----------------------------------------///

        /// <summary>
        /// this function represents a move for 2 balls that push 1 and don't score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="enemyBallPos"> enemy's ball position </param>
        /// <param name="to"> the destination position </param>
        public void TwoBallsPushOneMove(int ball1Pos, int ball2Pos, int enemyBallPos, int to)
        {
            indexes = new int[4];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = enemyBallPos;
            indexes[3] = to;
            defenseMarbles = 1;
            attackMarbles = 2;
            score = false;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for 3 balls that push 1 and don't score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="enemyBallPos"> enemy's ball position </param>
        /// <param name="to"> the destination position </param>
        public void ThreeBallsPushOneMove(int ball1Pos, int ball2Pos, int ball3Pos, int enemyBallPos, int to)
        {
            indexes = new int[5];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = enemyBallPos;
            indexes[4] = to;
            defenseMarbles = 1;
            attackMarbles = 3;
            score = false;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for 3 balls that push 2 and don't score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="enemyBall1Pos"> first enemy's ball position </param>
        /// <param name="enemyBall2Pos"> second enemy's ball position </param>
        /// <param name="to"> the destination position </param>
        public void ThreeBallsPushTwoMove(int ball1Pos, int ball2Pos, int ball3Pos, int enemyBall1Pos, int enemyBall2Pos, int to)
        {
            indexes = new int[6];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = enemyBall1Pos;
            indexes[4] = enemyBall2Pos;
            indexes[5] = to;
            defenseMarbles = 2;
            attackMarbles = 3;
            score = false;
            sideStep = false;
        }

        ///----------------------------------------- FORWARD PUSHING SCORING MOVES -----------------------------------------///

        /// <summary>
        /// this function represents a move for 2 balls that push 1 and score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="enemyBallPos"> enemy's ball position </param>
        public void TwoBallsPushOneMove(int ball1Pos, int ball2Pos, int enemyBallPos)
        {
            indexes = new int[3];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = enemyBallPos;
            defenseMarbles = 0;
            attackMarbles = 2;
            score = true;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for 3 balls that push 1 and score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="enemyBallPos"> enemy's ball position </param>
        public void ThreeBallsPushOneMove(int ball1Pos, int ball2Pos, int ball3Pos, int enemyBallPos)
        {
            indexes = new int[4];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = enemyBallPos;
            defenseMarbles = 0;
            attackMarbles = 3;
            score = true;
            sideStep = false;
        }

        /// <summary>
        /// this function represents a move for 3 balls that push 2 and score
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="enemyBall1Pos"> first enemy's ball position </param>
        /// <param name="enemyBall2Pos"> second enemy's ball position </param>
        public void ThreeBallsPushTwoMove(int ball1Pos, int ball2Pos, int ball3Pos, int enemyBall1Pos, int enemyBall2Pos)
        {
            indexes = new int[5];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = enemyBall1Pos;
            indexes[4] = enemyBall2Pos;
            defenseMarbles = 1;
            attackMarbles = 3;
            score = true;
            sideStep = false;
        }


        ///----------------------------------------- SIDE MOVES -----------------------------------------///


        /// <summary>
        /// this function represents a move for two balls that move to the side
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball1To"> the position that the first ball moves to </param>
        /// <param name="ball2To"> the position that the second ball moves to </param>
        public void TwoBallsSideMove(int ball1Pos, int ball2Pos, int ball1To, int ball2To)
        {
            indexes = new int[4];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball1To;
            indexes[3] = ball2To;
            defenseMarbles = 0;
            attackMarbles = 2;
            score = false;
            sideStep = true;
        }

        /// <summary>
        /// function for three balls that moves to the side
        /// </summary>
        /// <param name="ball1Pos"> first ball position </param>
        /// <param name="ball2Pos"> second ball position </param>
        /// <param name="ball3Pos"> third ball position </param>
        /// <param name="ball1To"> the position that the first ball moves to </param>
        /// <param name="ball2To"> the position that the second ball moves to </param>
        /// <param name="ball3To"> the position that the third ball moves to </param>
        public void ThreeBallsSideMove(int ball1Pos, int ball2Pos, int ball3Pos, int ball1To, int ball2To, int ball3To)
        {
            indexes = new int[6];
            indexes[0] = ball1Pos;
            indexes[1] = ball2Pos;
            indexes[2] = ball3Pos;
            indexes[3] = ball1To;
            indexes[4] = ball2To;
            indexes[5] = ball3To;
            defenseMarbles = 0;
            attackMarbles = 3;
            score = false;
            sideStep = true;
        }

        /// <summary>
        /// indexes array properties
        /// </summary>
        public int[] Indexes
        {
            get { return indexes; }
            set { indexes = value; }
        }

        /// <summary>
        /// attackMarbles properties
        /// </summary>
        public int AttackMarbles
        {
            get { return attackMarbles; }
            set { attackMarbles = value; }
        }

        /// <summary>
        /// defenseMarbles properties
        /// </summary>
        public int DefenseMarbles
        {
            get { return defenseMarbles; }
            set { defenseMarbles = value; }
        }

        /// <summary>
        /// score properties
        /// </summary>
        public bool Score
        {
            get { return score; }
            set { score = value; }
        }

        /// <summary>
        /// sideStep properties
        /// </summary>
        public bool SideStep
        {
            get { return sideStep; }
            set { sideStep = value; }
        }
    }
}
