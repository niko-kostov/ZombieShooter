using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ZombieShooter
{
    public partial class MainMenu : Form
    {
        WindowsMediaPlayer windowsPlayer = new WindowsMediaPlayer();
        public Player newPlayer;
        public List<Player> players = new List<Player>();
        public MainMenu()
        {
            InitializeComponent();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/Soundtrack/MainMenuSoundtrack.mp3";
            windowsPlayer.URL = path;
            windowsPlayer.controls.play();
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
            if (players.Count > 5)
            {
                players.RemoveRange(5, players.Count);
            }
            Scoreboard scoreboard = new Scoreboard(players);
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
            newPlayer = new Player(txtPlayer.Text);
            Game newGame = new Game(newPlayer);
            this.Hide();

            windowsPlayer.controls.stop();
            newGame.ShowDialog();
            windowsPlayer.controls.play();
            
            this.Show();
        }
    }
}
