using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbaloneGame.View
{
    public partial class WelcomeForm : Form
    {
        /// <summary>
        /// constructor
        /// </summary>
        public WelcomeForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// this function opens the game form in player vs pc mode and hides this form
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the event's information </param>
        private void button2_Click(object sender, EventArgs e)
        {
            OpenGameFormInMode((int)Constants.MODE.PLAYER_VS_PC);
        }

        /// <summary>
        /// this function opens the game form in player vs player mode and hides this form
        /// </summary>
        /// <param name="sender"> the sender </param>
        /// <param name="e"> the event's information </param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenGameFormInMode((int)Constants.MODE.PLAYER_VS_PLAYER);
        }

        /// <summary>
        /// this function opens the game form in a specific mode and hides this form
        /// </summary>
        /// <param name="mode"> the mode </param>
        private void OpenGameFormInMode(int mode)
        {
            GameForm gameForm = new GameForm(mode);
            this.Hide();
            gameForm.Show();
        }
    }
}
