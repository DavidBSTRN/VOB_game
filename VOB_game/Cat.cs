using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOB_game
{
    internal class Cat
    {
        private PictureBox picture_box;
        private int cat_speed = 1;
        public Cat() 
        {
            picture_box = new PictureBox();
            picture_box.Size = new Size(70, 70);
            picture_box.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_box.Image = Properties.Resources.cat;
        }

        public PictureBox Get_picture_box()
        {
            return picture_box;
        }

        public void Set_position(int x, int y)
        {
            picture_box.Left = x;
            picture_box.Top = y;
        }

        public void Increase_speed()
        {
            cat_speed++;
        }

        public void Reset_speed() 
        {
            cat_speed = 1;
        }

        public void Move(int x, int y) // move toward the Slayer
        {
            if (picture_box.Left > x)
            {
                picture_box.Left -= cat_speed;
            }

            if (picture_box.Left < x)
            {
                picture_box.Left += cat_speed;
            }

            if (picture_box.Top > y)
            {
                picture_box.Top -= cat_speed;
            }

            if (picture_box.Top < y)
            {
                picture_box.Top += cat_speed;
            }
        }
    }
}
