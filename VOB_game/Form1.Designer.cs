namespace VOB_game
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label_ammo = new System.Windows.Forms.Label();
            this.label_kills = new System.Windows.Forms.Label();
            this.label_hp = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label_ammo
            // 
            this.label_ammo.AutoSize = true;
            this.label_ammo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_ammo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_ammo.Location = new System.Drawing.Point(13, 13);
            this.label_ammo.Name = "label_ammo";
            this.label_ammo.Size = new System.Drawing.Size(83, 25);
            this.label_ammo.TabIndex = 0;
            this.label_ammo.Text = "Ammo:";
            // 
            // label_kills
            // 
            this.label_kills.AutoSize = true;
            this.label_kills.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_kills.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_kills.Location = new System.Drawing.Point(324, 13);
            this.label_kills.Name = "label_kills";
            this.label_kills.Size = new System.Drawing.Size(64, 25);
            this.label_kills.TabIndex = 1;
            this.label_kills.Text = "Kills:";
            // 
            // label_hp
            // 
            this.label_hp.AutoSize = true;
            this.label_hp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_hp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label_hp.Location = new System.Drawing.Point(613, 13);
            this.label_hp.Name = "label_hp";
            this.label_hp.Size = new System.Drawing.Size(87, 25);
            this.label_hp.TabIndex = 2;
            this.label_hp.Text = "Health:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(707, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(205, 23);
            this.progressBar1.TabIndex = 3;
            this.progressBar1.Value = 100;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.Game_engine);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.HotPink;
            this.ClientSize = new System.Drawing.Size(924, 666);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_hp);
            this.Controls.Add(this.label_kills);
            this.Controls.Add(this.label_ammo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Key_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Key_up);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ammo;
        private System.Windows.Forms.Label label_kills;
        private System.Windows.Forms.Label label_hp;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

