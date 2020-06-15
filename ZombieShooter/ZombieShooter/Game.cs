using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace ZombieShooter
{
    public partial class Game : Form
    {
        WindowsMediaPlayer windowsPlayer = new WindowsMediaPlayer();
        Player igrach;
        bool goLeft, goRight, goUp, goDown;
        bool gameOver = false;
        string facing = "up";
        int playerHealth = 100;
        int speed = 10;
        int ammo = 10;
        int zombieSpeed = 3;
        Random newRnd = new Random();
        List<PictureBox> zombies = new List<PictureBox>();
        MainMenu mainMenu;
        public Game(Player igrach, MainMenu mm)
        {
            this.igrach = igrach;
            this.mainMenu = mm;
            InitializeComponent();
            //windowsPlayer = new WindowsMediaPlayer();
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + @"/Soundtrack/MainGameSoundtrack.mp3";
            windowsPlayer.URL = path;
            windowsPlayer.settings.volume = 15;
            windowsPlayer.controls.play();
            pbHealth.Value = 100;
            igrach.Points = 0;
            Timer.Start();
            Initial_Spawn();
        }

        private void Initial_Spawn ()
        {
            for (int i = 0; i < 3; i++)
                MakeZombies();
        }

        private void Game_KeyDown(object sender, KeyEventArgs e) // dokolku se pritisne kopce da doznaeme na koja strana treba da odime
        {
            if (gameOver == true)
            {
                return;
            }

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
            if (gameOver == true)
            {
                return;
            }

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

            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo == 1)
                {
                    dropAmmo();
                }
                
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
                Player.Image = Properties.Resources.dead;
                GameOver gg = new GameOver(igrach, mainMenu);
                gg.Show();
                
                mainMenu.Hide();
                this.Close();
                Timer.Stop();
            }
            if (playerHealth < 40 && !pbHealth.IsDisposed)
            {
                pbHealth.SetState(2);
            }

            lblMadeKills.Text = igrach.Points.ToString();
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

            foreach (Control x in this.Controls) // sobiranje na ammo, dvizenje na zombies i presmetuvanje udari, i dodavanje health
            {
                foreach (Control j in Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "health" && j.Bounds.IntersectsWith(Player.Bounds))
                    {
                        if (pbHealth.Value > 80)
                        {
                            pbHealth.Value = 100;
                            playerHealth = 100;                            
                        }
                        else
                        {                            
                            playerHealth += 20;
                            pbHealth.Value = playerHealth;
                            if (pbHealth.Value > 40)
                            {
                                pbHealth.SetState(1);
                            }
                            else
                            {
                                pbHealth.SetState(1);
                                pbHealth.SetState(2);
                            }

                            //label1.Text = playerHealth.ToString();
                        }
                        this.Controls.Remove(j);
                        j.Dispose();
                    }
                }
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += 5;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "zombie")
                {
                    if (x.Left > Player.Left)
                    {
                        x.Left -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zleft;
                    }

                    if (x.Left < Player.Left)
                    {
                        x.Left += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zright;
                    }

                    if (x.Top < Player.Top)
                    {
                        x.Top += zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zdown;
                    }

                    if (x.Top > Player.Top)
                    {
                        x.Top -= zombieSpeed;
                        ((PictureBox)x).Image = Properties.Resources.zup;
                    }

                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 2;
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "zombie")
                    {
                        if (j.Bounds.IntersectsWith(x.Bounds))
                        {
                            igrach.IncreasePoints();
                            if (igrach.Points % 10 == 0 && igrach.Points != 0)
                            {
                                dropHealth();
                            }
                            this.Controls.Remove(x);
                            x.Dispose();
                            this.Controls.Remove(j);
                            j.Dispose();
                            MakeZombies();
                        }
                    }
                    
                }
                
            }
            

        }
        public void dropHealth()
        {
            PictureBox healthIcon = new PictureBox();
            healthIcon.Tag = "health";
            healthIcon.Image = Properties.Resources.healthIcon;
            healthIcon.Left = newRnd.Next(10, this.ClientSize.Width - healthIcon.Width);
            healthIcon.Top = newRnd.Next(10, this.ClientSize.Height - healthIcon.Height);
            healthIcon.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(healthIcon);
            Player.BringToFront();
        }
        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            windowsPlayer.controls.stop();
            mainMenu.Hide();
        }

        public void MakeZombies()
        {
            PictureBox zombie = new PictureBox();
            zombie.Tag = "zombie";
            zombie.Image = Properties.Resources.zdown;
            zombie.Left = newRnd.Next(0, 900);
            zombie.Top = newRnd.Next(0, 800);
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // fit to picture
            this.Controls.Add(zombie);
            Player.BringToFront();
        }

        private void dropAmmo() // random pozicija za spawn na ammo 
        {
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo_Image;
            ammo.SizeMode = PictureBoxSizeMode.AutoSize;
            ammo.Left = newRnd.Next(10, this.ClientSize.Width - ammo.Width);
            ammo.Top = newRnd.Next(10, this.ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";

            this.Controls.Add(ammo);
            Player.BringToFront();
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