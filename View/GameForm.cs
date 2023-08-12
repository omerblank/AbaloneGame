using AbaloneGame.Controller;
using AbaloneGame.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbaloneGame.View
{
    public partial class GameForm : Form
    {
        Game game; // the game
        int mode; // the game mode, for example: player vs pc

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="mode"> the game mode as an integer constant value </param>
        public GameForm(int mode)
        {
            game = new Game();
            this.mode = mode;
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            label1.Text = game.CurrentPlayer.Name + " player turn";
        }

        /// <summary>
        /// this function paints the board's state
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the paint event information </param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicUtils.Paint(game.Board, game.PlayerTurn, e.Graphics);
        }

        /// <summary>
        /// this function manages the game when a mouse click occurs
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the mouse event information (the click) </param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (mode == (int)Constants.MODE.PLAYER_VS_PLAYER)
                game.ClickInPlayerVsPlayer(e, pictureBox1);

            else if (mode == (int)Constants.MODE.PLAYER_VS_PC)
                game.ClickInPlayerVsComputer(e, pictureBox1);

            pictureBox1.Invalidate();
            whiteScoreLbl.Text = "score: " + game.WhitePlayer.Score.ToString();
            whiteProgress.Value = game.WhitePlayer.Score;
            blackScoreLbl.Text = "score: " + game.BlackPlayer.Score.ToString();
            blackProgress.Value = game.BlackPlayer.Score;
            label1.Text = game.CurrentPlayer.Name + " player turn";

            if (game.GameOver())
            {
                MessageBox.Show($"{game.GetWinner().Name} player wins!");
                this.Hide();
                new WelcomeForm().Show();
            }
        }
    }
}
