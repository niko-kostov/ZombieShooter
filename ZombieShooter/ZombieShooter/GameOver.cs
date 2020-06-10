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
    public partial class GameOver : Form
    {
        Player player;
        public GameOver(Player player)
        {
            InitializeComponent();
            this.player = player;
            lblScore.Text = player.Points.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Game retry = new Game(player);
            retry.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            MainMenu menu = new MainMenu();
            menu.ShowDialog();
        }
    }
}
