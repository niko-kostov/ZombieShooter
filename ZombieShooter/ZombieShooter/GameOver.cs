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
    public partial class GameOver : Form
    {
        Player player;
        MainMenu mainMenu;
        WindowsMediaPlayer windowsPlayer = new WindowsMediaPlayer();
        public GameOver(Player player, MainMenu mm)
        {
            InitializeComponent();
            this.player = player;
            this.mainMenu = mm;
            lblScore.Text = player.Points.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            Game retry = new Game(player, mainMenu);
            mainMenu.Hide();
            retry.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
            mainMenu.players.Add(player);
            mainMenu.Show();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/Soundtrack/MainMenuSoundtrack.mp3";
            windowsPlayer.URL = path;
            windowsPlayer.controls.play();
            
        }
    }
}
