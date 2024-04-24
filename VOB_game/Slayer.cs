using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOB_game
{
    internal class Slayer
    {
        private PictureBox picture_box;
        private bool go_up, go_down, go_left, go_right;
        private int player_HP;
        private int player_speed;
        private int ammo;
        private string direction;

        public Slayer(int hp, int speed)
        {
            player_HP = hp;
            player_speed = speed;
            ammo = 10;

            picture_box = new PictureBox();
            picture_box.SizeMode = PictureBoxSizeMode.AutoSize;
            picture_box.Image = Properties.Resources.up;
        }

        public PictureBox Get_pictureBox()
        {
            return picture_box;
        }

        public int Get_HP()
        { 
            return player_HP;
        }

        public void Reset_HP()
        {
            player_HP = 100;
        }

        public void Reset_ammo()
        {
            ammo = 10;
        }

        public void Get_hit()
        {
            player_HP -= 1;
        }

        public void Set_position(int x, int y)
        {
            picture_box.Left = x;
            picture_box.Top = y;
        }

        public string Get_direction()
        {
            return direction;
        }

        public void Set_direction(string direction) // change picture according to direction
        {
            this.direction = direction;
            switch (direction)
            {
                case "up":
                    picture_box.Image = Properties.Resources.up;
                    break;
                case "down":
                    picture_box.Image = Properties.Resources.down;
                    break;
                case "left":
                    picture_box.Image = Properties.Resources.left;
                    break;
                case "right":
                    picture_box.Image = Properties.Resources.right;
                    break;
            }
        }

        public void Handle_key_down(Keys key) // press key and set correct dir
        {
            switch (key)
            {
                case Keys.Left:
                    go_left = true;
                    Set_direction("left");
                    break;
                case Keys.Right:
                    go_right = true;
                    Set_direction("right");
                    break;
                case Keys.Up:
                    go_up = true;
                    Set_direction("up");
                    break;
                case Keys.Down:
                    go_down = true;
                    Set_direction("down");
                    break;
            }
        }

        public void Handle_key_up(Keys key) // release key -> stop move
        {
            switch (key)
            {
                case Keys.Left:
                    go_left = false;
                    break;
                case Keys.Right:
                    go_right = false;
                    break;
                case Keys.Up:
                    go_up = false;
                    break;
                case Keys.Down:
                    go_down = false;
                    break;
            }
        }

        public void Move() // move slayer
        {
            if (go_left && picture_box.Left > 0)
            {
                picture_box.Left -= player_speed;
            }

            if (go_right && picture_box.Left < 830)
            {
                picture_box.Left += player_speed;
            }

            if (go_up && picture_box.Top > 60)
            {
                picture_box.Top -= player_speed;
            }

            if (go_down && picture_box.Top < 570)
            {
                picture_box.Top += player_speed;
            }
        }

        public int Get_ammo()
        {
            return ammo;
        }

        public void Decrease_ammo()
        {
            ammo--;
        }

        public void Add_ammo()
        {
            ammo += 10;
        }

        public void Shoot(string direction, Form form) // shoot method
        {
            // create a new bullet and place it next to slayer
            Bullet shoot = new Bullet();
            shoot.Set_direction(direction);
            shoot.Set_bullet_pos(picture_box.Left + (picture_box.Width / 2), picture_box.Top + (picture_box.Height / 2));
            shoot.Create_bullet(form);
        }
    }
}

