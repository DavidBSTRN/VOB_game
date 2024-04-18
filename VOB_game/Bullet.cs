using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace VOB_game
{
    internal class Bullet
    {
        // vars
        private string direction;
        private int speed = 20;
        private PictureBox bullet = new PictureBox();
        private Timer tm = new Timer(); 
        private int bulletLeft;
        private int bulletTop;

        public void Set_direction(string dir)
        {
            direction = dir;
        }

        public void Set_bullet_pos(int left, int top)
        {
            bulletLeft = left;
            bulletTop = top;
        }

        public void Create_bullet(Form form) // creating bullet and display it
        {
            bullet.BackColor = System.Drawing.Color.White;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();
            form.Controls.Add(bullet);
            tm.Interval = speed;
            tm.Tick += new EventHandler(Tm_Tick);
            tm.Start();
        }
        public void Tm_Tick(object sender, EventArgs e) // move it right direction
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bullet.Left < 15 || bullet.Left > 925 || bullet.Top < 15 || bullet.Top > 690) // remove after hit the sides
            {
                tm.Stop();
                tm.Dispose();
                bullet.Dispose();
                tm = null;
                bullet = null;
            }
        }
    }
}