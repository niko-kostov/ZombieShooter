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
    public partial class Game : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        int kills = 0;
        Random newRnd = new Random();
        List<PictureBox> zombies = new List<PictureBox>();

        private void Game_KeyDown(object sender, KeyEventArgs e) // dokolku se pritisne kopce da doznaeme na koja strana treba da odime
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                Player.Image = Properties.Resources.left;
            }
            
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                Player.Image = Properties.Resources.right;
            }

            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
                Player.Image = Properties.Resources.up;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
                Player.Image = Properties.Resources.down;
            }

        }

        private void Game_KeyUp(object sender, KeyEventArgs e) // dokolku se otpusti kopceto da se prekine so dvizenje
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }

            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }

            if (e.KeyCode == Keys.Space)
            {
                ShootBullet(facing);
            }

        }

        private void Timer_Tick(object sender, EventArgs e) // na sekoja sekunda od timerot da se pravi update na ammo, pozicija i sl.
        {
            if (playerHealth > 1)
            {
                pbHealth.Value = playerHealth;
            }
            else
            {
                gameOver = true;
            }
            lblMadeKills.Text = kills.ToString();
            lblTotalAmmo.Text = ammo.ToString();

            if (goLeft == true && Player.Left > 0)
            {
                Player.Left -= speed;
            }
            if (goRight == true && Player.Left + Player.Width < this.ClientSize.Width - 15)
            {
                Player.Left += speed;
            }
            if (goUp == true && Player.Top > 45)
            {
                Player.Top -= speed;
            }
            if (goDown == true && Player.Top + Player.Height < this.ClientSize.Height - 15)
            {
                Player.Top += speed;
            }
        }
        
        public Game(string playername)
        {
            InitializeComponent();
            Timer.Start();
        }

        public void MakeZombies()
        {

        }

        public void ShootBullet(string direction)
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = Player.Left + (Player.Width / 2); // da pocne kursumot otprilika na pola covek
            shootBullet.bulletTop = Player.Top + (Player.Height / 2);
            shootBullet.makeBullet(this);

        }
    }
}