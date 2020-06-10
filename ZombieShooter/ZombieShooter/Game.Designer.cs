namespace ZombieShooter
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblHealth = new System.Windows.Forms.Label();
            this.pbHealth = new System.Windows.Forms.ProgressBar();
            this.lblKills = new System.Windows.Forms.Label();
            this.lblMadeKills = new System.Windows.Forms.Label();
            this.lblAmmo = new System.Windows.Forms.Label();
            this.lblTotalAmmo = new System.Windows.Forms.Label();
            this.Player = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHealth
            // 
            this.lblHealth.AutoSize = true;
            this.lblHealth.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHealth.ForeColor = System.Drawing.SystemColors.Window;
            this.lblHealth.Location = new System.Drawing.Point(692, 13);
            this.lblHealth.Name = "lblHealth";
            this.lblHealth.Size = new System.Drawing.Size(64, 19);
            this.lblHealth.TabIndex = 0;
            this.lblHealth.Text = "Health:";
            // 
            // pbHealth
            // 
            this.pbHealth.Location = new System.Drawing.Point(754, 9);
            this.pbHealth.Name = "pbHealth";
            this.pbHealth.Size = new System.Drawing.Size(158, 21);
            this.pbHealth.TabIndex = 1;
            this.pbHealth.Value = 100;
            // 
            // lblKills
            // 
            this.lblKills.AutoSize = true;
            this.lblKills.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.ForeColor = System.Drawing.SystemColors.Window;
            this.lblKills.Location = new System.Drawing.Point(369, 13);
            this.lblKills.Name = "lblKills";
            this.lblKills.Size = new System.Drawing.Size(48, 19);
            this.lblKills.TabIndex = 2;
            this.lblKills.Text = "Kills:";
            // 
            // lblMadeKills
            // 
            this.lblMadeKills.AutoSize = true;
            this.lblMadeKills.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMadeKills.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMadeKills.Location = new System.Drawing.Point(416, 12);
            this.lblMadeKills.Name = "lblMadeKills";
            this.lblMadeKills.Size = new System.Drawing.Size(18, 19);
            this.lblMadeKills.TabIndex = 3;
            this.lblMadeKills.Text = "0";
            // 
            // lblAmmo
            // 
            this.lblAmmo.AutoSize = true;
            this.lblAmmo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmmo.ForeColor = System.Drawing.SystemColors.Window;
            this.lblAmmo.Location = new System.Drawing.Point(35, 13);
            this.lblAmmo.Name = "lblAmmo";
            this.lblAmmo.Size = new System.Drawing.Size(64, 19);
            this.lblAmmo.TabIndex = 4;
            this.lblAmmo.Text = "Ammo:";
            // 
            // lblTotalAmmo
            // 
            this.lblTotalAmmo.AutoSize = true;
            this.lblTotalAmmo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmmo.ForeColor = System.Drawing.SystemColors.Window;
            this.lblTotalAmmo.Location = new System.Drawing.Point(99, 13);
            this.lblTotalAmmo.Name = "lblTotalAmmo";
            this.lblTotalAmmo.Size = new System.Drawing.Size(18, 19);
            this.lblTotalAmmo.TabIndex = 5;
            this.lblTotalAmmo.Text = "0";
            // 
            // Player
            // 
            this.Player.Image = global::ZombieShooter.Properties.Resources.up;
            this.Player.Location = new System.Drawing.Point(363, 549);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(71, 100);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Player.TabIndex = 6;
            this.Player.TabStop = false;
            // 
            // Timer
            // 
            this.Timer.Interval = 20;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(924, 661);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.lblTotalAmmo);
            this.Controls.Add(this.lblAmmo);
            this.Controls.Add(this.lblMadeKills);
            this.Controls.Add(this.lblKills);
            this.Controls.Add(this.pbHealth);
            this.Controls.Add(this.lblHealth);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Game";
            this.Text = "Zombie_Shooter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Game_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Game_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHealth;
        private System.Windows.Forms.ProgressBar pbHealth;
        private System.Windows.Forms.Label lblKills;
        private System.Windows.Forms.Label lblMadeKills;
        private System.Windows.Forms.Label lblAmmo;
        private System.Windows.Forms.Label lblTotalAmmo;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer Timer;
    }
}