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
    public partial class Scoreboard : Form
    {
        //List<Player> players = new List<Player>();
        public Scoreboard(List<Player> players)
        {
            InitializeComponent();
            players = players.OrderByDescending(x => x.Points).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(Player p in players)
            {
                sb.Append(p.Name + " " + p.Points.ToString() + "\n");
            }
            lblTopPlayers.Text = sb.ToString();
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
