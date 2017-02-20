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
            ball.Left = 100;



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

            //if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right) //racket collision
            if (ball.Bounds.IntersectsWith(racket.Bounds))
            {
                //speed_top += 1;
                //speed_left += 1;
                speed_top = -speed_top; //Change direction
                point += 1;
            }

            if (ball.Bounds.IntersectsWith(racket_left.Bounds) && speed_left >= 0)  //Make it bounce differently depending on where it landed on the racket
            {

                speed_left = -speed_left;

            }

            if (ball.Bounds.IntersectsWith(racket_right.Bounds) && speed_left <= 0)  //Make it bounce differently depending on where it landed on the racket
            {

                speed_left = -speed_left;

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

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); } //Close program with ESC button
            if (e.KeyCode == Keys.F1) { gameStart(); }      //Reload game
            if (e.KeyCode == Keys.F3) { timer1.Enabled = false; }   //For debugging
                
        }
    }
}
