using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VOB_game
{
    public partial class Form1 : Form
    {
        private Slayer slayer;
        private Cat cat_1;
        private Cat cat_2;
        private Cat cat_3;
        private bool game_over = false;
        private int score = 0;
        private int score_speed = 10;
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            // init salyer
            slayer = new Slayer(100, 10);
            slayer.Set_position(400, 300);
            slayer.Set_direction("up");
            Controls.Add(slayer.Get_pictureBox());
            slayer.Get_pictureBox().BringToFront();
            // init cats
            cat_1 = new Cat();
            cat_1.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));
            Controls.Add(cat_1.Get_picture_box());
            cat_1.Get_picture_box().BringToFront();
            cat_1.Get_picture_box().Tag = "cat1";

            cat_2 = new Cat();
            cat_2.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));
            Controls.Add(cat_2.Get_picture_box());
            cat_2.Get_picture_box().BringToFront();
            cat_2.Get_picture_box().Tag = "cat2";

            cat_3 = new Cat();
            cat_3.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));
            Controls.Add(cat_3.Get_picture_box());
            cat_3.Get_picture_box().BringToFront();
            cat_3.Get_picture_box().Tag = "cat3";
        }

        private void Key_down(object sender, KeyEventArgs e)
        {
            if (game_over)
            {
                return;
            }

            slayer.Handle_key_down(e.KeyCode);
        }

        private void Key_up(object sender, KeyEventArgs e)
        {
            if (game_over)
            {
                if (e.KeyCode == Keys.Space)
                {
                    RestartGame();
                }
                return;
            }

            if (e.KeyCode == Keys.Space && slayer.Get_ammo() > 0) // shoot after release space and have ammo
            {
                slayer.Shoot(slayer.Get_direction(), this); 
                slayer.Decrease_ammo();
                if (slayer.Get_ammo() < 1)
                {
                    New_ammo(); // ammo function
                }
            }

            slayer.Handle_key_up(e.KeyCode);
        }

        private void RestartGame()
        {
            score = 0;
            score_speed = 10;
            game_over = false;

            slayer.Reset_HP();
            slayer.Reset_ammo();
            slayer.Set_position(400, 300);
            slayer.Set_direction("up");
            slayer.Get_pictureBox().BringToFront();
                                                                         
            cat_1.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));
            cat_2.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));
            cat_3.Set_position(rnd.Next(200, 800), rnd.Next(100, 600));

            cat_1.Reset_speed();
            cat_2.Reset_speed();
            cat_3.Reset_speed();

            timer1.Start();
        }

        private void New_ammo() // generate new ammo image and place it
        {
            // image
            PictureBox ammo = new PictureBox();
            ammo.Image = Properties.Resources.ammo;
            ammo.Size = new Size(50, 50);
            ammo.SizeMode = PictureBoxSizeMode.StretchImage;
            ammo.Tag = "ammo";
            // set location
            ammo.Left = rnd.Next(10, 890);
            ammo.Top = rnd.Next(50, 600);
            this.Controls.Add(ammo);

            ammo.BringToFront();
            slayer.Get_pictureBox().BringToFront();
        }

        private void Game_engine(object sender, EventArgs e)
        {
            // labels
            label_ammo.Text = "Ammo: " + slayer.Get_ammo();
            label_kills.Text = "Kills: " + score;

            // HP and death
            if (slayer.Get_HP() > 1)
            {
                progressBar1.Value = Convert.ToInt32(slayer.Get_HP());
            }
            else
            {
                slayer.Get_pictureBox().Image = Properties.Resources.dead;
                timer1.Stop();
                game_over = true;
            }

            // moving player
            slayer.Move();

            // increase cats movement
            if (score == score_speed)
            {
                cat_1.Increase_speed();
                cat_2.Increase_speed();
                cat_3.Increase_speed();
                score_speed += 10;
            }

            // search forr all controls
            foreach (Control x in this.Controls)
            {
                // coleecting ammo
                if (x is PictureBox && x.Tag == "ammo")
                {
                    // hiting ammo
                    if (((PictureBox)x).Bounds.IntersectsWith(slayer.Get_pictureBox().Bounds))
                    {
                        // remove ammo image and add ammo
                        this.Controls.Remove(((PictureBox)x));
                        ((PictureBox)x).Dispose();
                        slayer.Add_ammo();
                    }
                }
                // get chased and hit by cats
                if (x is PictureBox && x.Tag == "cat1")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(slayer.Get_pictureBox().Bounds)) // get hit and get dmg
                    {
                        slayer.Get_hit();
                    }
                    // move cat
                    cat_1.Move(slayer.Get_pictureBox().Left, slayer.Get_pictureBox().Top);
                }

                if (x is PictureBox && x.Tag == "cat2")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(slayer.Get_pictureBox().Bounds)) // get hit and get dmg
                    {
                        slayer.Get_hit();
                    }
                    // move cat
                    cat_2.Move(slayer.Get_pictureBox().Left, slayer.Get_pictureBox().Top);
                }

                if (x is PictureBox && x.Tag == "cat3")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(slayer.Get_pictureBox().Bounds)) // get hit and get dmg
                    {
                        slayer.Get_hit();
                    }
                    // move cat
                    cat_3.Move(slayer.Get_pictureBox().Left, slayer.Get_pictureBox().Top);
                }

                // for bullet hiting the cat
                foreach (Control j in this.Controls)
                {
                    if ((j is PictureBox &&  j.Tag == "bullet") && (x is PictureBox && x.Tag == "cat1"))
                    {
                        if (j.Bounds.IntersectsWith(x.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            j.Dispose();
                            cat_1.Set_position(rnd.Next(0, 800), rnd.Next(0, 600));
                        }
                    }

                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "cat2"))
                    {
                        if (j.Bounds.IntersectsWith(x.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            j.Dispose();
                            cat_2.Set_position(rnd.Next(0, 800), rnd.Next(0, 600));
                        }
                    }

                    if ((j is PictureBox && j.Tag == "bullet") && (x is PictureBox && x.Tag == "cat3"))
                    {
                        if (j.Bounds.IntersectsWith(x.Bounds))
                        {
                            score++;
                            this.Controls.Remove(j);
                            j.Dispose();
                            cat_3.Set_position(rnd.Next(0, 800), rnd.Next(0, 600));
                        }
                    }
                }
            }
        }
    }
}
