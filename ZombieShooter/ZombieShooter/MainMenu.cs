using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZombieShooter
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void pbQuit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to quit the game?", "Quit game",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void pbScoreboard_Click(object sender, EventArgs e)
        {
            Scoreboard scoreboard = new Scoreboard();
            this.Hide();     //go prikriva glavnoto meni koga se otvara scoreboard
            scoreboard.ShowDialog();
            this.Show();
        }

        private void pbPlaygame_Click(object sender, EventArgs e)
        {
            if(txtPlayer.Text == null || txtPlayer.Text == "")
            {
                return;
            }
            Game newGame = new Game(txtPlayer.Text);
            this.Hide();
            newGame.ShowDialog();
            this.Show();
        }
    }
}
