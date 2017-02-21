using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Blockbusters
{
    public partial class Form1 : Form
    {
        

        public int speed_left = 4;  //Speed for ball
        public int speed_top = 4;
        public int point = 0;       //Score points   
        public static int random = 0; //Make the ball bounce more random
        public List<PictureBox> Lvl1 = new List<PictureBox>();

        public void gameStart()
        {
            ball.Top = 50;
            ball.Left = 50; 
            speed_left = 4;
            speed_top = 4;
            point = 0;
            timer1.Enabled = true;
            gameover_lbl.Visible = false;
        }



        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();                                  //Hide cursor

            this.FormBorderStyle = FormBorderStyle.None;    //Remove any border
            this.TopMost = true;                            //Bring the form to front
            this.Bounds = Screen.PrimaryScreen.Bounds;      //Make it fullscreen
            racket_left.BringToFront();


            racket.Top = Playground.Bottom - (Playground.Bottom / 10);     //Sets position for racket
            racket_left.Top = Playground.Bottom - (Playground.Bottom / 10);
            racket_right.Top = Playground.Bottom - (Playground.Bottom / 10);
            ball.Top = 10;                                                 //Sets position for ball
            ball.Left = 1000;

            Lvl1.Add(block1);
            Lvl1.Add(block2);
            Lvl1.Add(block3);
            Lvl1.Add(block4);
            Lvl1.Add(block5);
            Lvl1.Add(block6);
            Lvl1.Add(block7);
            Lvl1.Add(block8);
            Lvl1.Add(block9);
            Lvl1.Add(block10);
            Lvl1.Add(block11);
            Lvl1.Add(block12);
            Lvl1.Add(block13);
            Lvl1.Add(block14);
            Lvl1.Add(block15);
            Lvl1.Add(block16);
            Lvl1.Add(block17);
            Lvl1.Add(block18);
            Lvl1.Add(block19);
            Lvl1.Add(block20);
            Lvl1.Add(block21);
            Lvl1.Add(block22);
            Lvl1.Add(block23);
            Lvl1.Add(block24);
            Lvl1.Add(block25);
            Lvl1.Add(block26);
            Lvl1.Add(block27);
            Lvl1.Add(block28);
            Lvl1.Add(block29);
            Lvl1.Add(block30);
            Lvl1.Add(block31);
            Lvl1.Add(block32);
            Lvl1.Add(block33);
            Lvl1.Add(block34);
            Lvl1.Add(block35);
            Lvl1.Add(block36);
            Lvl1.Add(block37);
            Lvl1.Add(block38);
            Lvl1.Add(block39);
            Lvl1.Add(block40);
            Lvl1.Add(block41);
            Lvl1.Add(block42);
            Lvl1.Add(block43);
            Lvl1.Add(block44);
            Lvl1.Add(block45);
            Lvl1.Add(block46);
            Lvl1.Add(block47);
            Lvl1.Add(block48);
            Lvl1.Add(block49);
            Lvl1.Add(block50);
            Lvl1.Add(block51);
            Lvl1.Add(block52);
            Lvl1.Add(block53);
            Lvl1.Add(block54);
            Lvl1.Add(block55);
            Lvl1.Add(block56);
            Lvl1.Add(block57);
            Lvl1.Add(block58);
            Lvl1.Add(block59);
            Lvl1.Add(block60);
            Lvl1.Add(block61);
            Lvl1.Add(block62);
            Lvl1.Add(block63);
            Lvl1.Add(block64);
            Lvl1.Add(block65);
            Lvl1.Add(block66);
            Lvl1.Add(block67);
            Lvl1.Add(block68);
            Lvl1.Add(block69);
            Lvl1.Add(block70);
            Lvl1.Add(block71);
            Lvl1.Add(block72);
            Lvl1.Add(block73);
            Lvl1.Add(block74);
            Lvl1.Add(block75);
            Lvl1.Add(block76);
            Lvl1.Add(block77);
            Lvl1.Add(block78);
            Lvl1.Add(block79);
            Lvl1.Add(block80);

            //for (int i = 0; i < 16; i++)
            //{
            //    PictureBox p = new PictureBox();
            //    p.Location = new Point(10, (i + 1) * 20);
            //    p.Size = new Size(10, 10);
            //    p.BorderStyle = BorderStyle.FixedSingle;
            //    .Controls.Add(p);
            //}


            //for (int i = 0; i < Lvl1.Count(); i++)                      //All blocks
            //{
            //    if (i <= 10)
            //    {
            //        Lvl1[i].Left = (Playground.Width / 2);
            //    }
            //    else if (i >= 10)
            //    {
            //        Lvl1[i].Top = Playground.Top + (Playground.Bottom / 15);
            //    }
            //}
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);           //Set the center of the racket to the position of the cursor
            racket_left.Left = Cursor.Position.X - (racket.Width/ 2);      //Set the left and right of the racket to the position of the cursor
            racket_right.Left = Cursor.Position.X + (racket.Width /4 );

            ball.Left += speed_left;            //Move the ball
            ball.Top += speed_top;

            score_lbl.Text = ("score: " + point);
            gameover_lbl.Left = (Playground.Width / 2) - (gameover_lbl.Width / 2);      //Set position in middle
            gameover_lbl.Top = (Playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;   //Hide

            for (int i = 0; i < Lvl1.Count(); i++)                      //All blocks
            {


                if (ball.Bounds.IntersectsWith(Lvl1[i].Bounds))
                {
                    if (Lvl1[i].Visible)
                    {
                        speed_top = -speed_top;
                        speed_left += 1;
                        point++;
                        Lvl1[i].Hide();     //Make the block disapear if it gets hit
                    }
                }
            }

           
            //if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) //racket collision
            if (ball.Bounds.IntersectsWith(racket.Bounds))
            {
                if (random == 0)
                {
                    //speed_top += 1;
                    //speed_left += 1;
                    speed_left += 1;
                    speed_top = -speed_top; //Change direction
                    //point += 1;
                    random = 1;
                }
                else if (random == 1)
                {
                    //speed_top += 1;
                    //speed_left += 1;
                    speed_left -= 1;
                    speed_top = -speed_top; //Change direction
                    //point += 1;
                    random = 0;
                }
            }


            if (ball.Bounds.IntersectsWith(racket_left.Bounds) && speed_left >= 0)  //Make it bounce differently depending on where it landed on the racket
            {
                if (random == 1)
                {
                    speed_left = -speed_left;
                    random = 0;
                }
                else if (random == 0)
                {
                    speed_left = -speed_left - 1;
                    random = 1;
                }

            }

            if (ball.Bounds.IntersectsWith(racket_right.Bounds) && speed_left <= 0)  //Make it bounce differently depending on where it landed on the racket
            {
                if (random == 1)
                {
                    speed_left = -speed_left;
                    random = 0;
                }
                else if (random == 0)
                {
                    speed_left = -speed_left - 1;
                    random = 1;
                }

            }

            if (ball.Left >= Playground.Left)           //Bounce from walls
            {
                speed_left = -speed_left;
            }
            if (ball.Right <= Playground.Right)
            {
                speed_left = -speed_left;
            }
            if (ball.Top <= Playground.Top)
            {
                speed_top = -speed_top;
            }

            if (ball.Bottom >= Playground.Bottom)
            {
                timer1.Enabled = false;         //Ball is out -> stop the game
                gameover_lbl.Visible = true;
            }

            if (point == 80)
            {
                timer1.Enabled = false;         //Game is won!
                gameover_lbl.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } //Close program with ESC button
            if (e.KeyCode == Keys.F1) { gameStart(); }      //Reload game
            if (e.KeyCode == Keys.F3) { timer1.Enabled = false; }   //For debugging
                
        }

    }
}
