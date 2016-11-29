using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace animation_formative
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush GrassBrush = new SolidBrush(Color.DarkGreen);
            Pen drawPen = new Pen(Color.Red, 5);
            startButton.Hide();
            SolidBrush drawBrush = new SolidBrush(Color.Blue);

            SoundPlayer player = new SoundPlayer(Properties.Resources.rocket);
            player.Play();

            for (int i = 0; i < 400; i = i + 6)
            {
                //first plane goes by
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                g.DrawLine(drawPen, 400 - i, 28, 400 - i, 43);
                g.DrawLine(drawPen, 400 - i, 40, 370 - i, 40);
                g.DrawLine(drawPen, 370 - i, 40, 400 - i, 30);

                Thread.Sleep(20);
            }

            // Canon coming out
            for (int i = 0; i < 210; i = i + 8)
            {
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                SolidBrush CanonBrush = new SolidBrush(Color.Gray);
                g.FillRectangle(CanonBrush, 405 - i, 275, 10, 10);
                g.FillRectangle(CanonBrush, 409 - i, 273, 2, 2);

                Thread.Sleep(20);
            }
            int x = 210;
            int y = 273;

            while (y > 100)
            {
                //Firework goes up
                //sound
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                SolidBrush CanonBrush = new SolidBrush(Color.Gray);
                g.FillRectangle(CanonBrush, 206, 275, 10, 10); 
                g.FillRectangle(CanonBrush, 210, 273, 2, 2);
                g.FillEllipse(drawBrush, x, y, 2, 2);
                Thread.Sleep(5);
                y--;

            }
            player.Stop();
            SoundPlayer rocket = new SoundPlayer(Properties.Resources.firework);
            rocket.Play();

            int pixels = 1;
            int c = 100;
            while (pixels < 255)
            {
                //firework goes off
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                SolidBrush CanonBrush = new SolidBrush(Color.Gray);
                g.FillRectangle(CanonBrush, 206, 275, 10, 10);
                g.FillRectangle(CanonBrush, 210, 273, 2, 2);
                SolidBrush firework = new SolidBrush(Color.FromArgb(0, 0, 255 - pixels));
                g.FillEllipse(firework, x - pixels / 2, c - pixels / 2, 10 + pixels, 10 + pixels);


                Thread.Sleep(5);
                pixels++;
            }

            for (int i = 0; i < 144; i += 8)
            {
                //swerve plane
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                g.DrawLine(drawPen, 400 - i, 28, 400 - i, 43);
                g.DrawLine(drawPen, 400 - i, 40, 370 - i, 40);
                g.DrawLine(drawPen, 370 - i, 40, 400 - i, 30);

                g.DrawLine(drawPen, 0 + i, 28, 0 + i, 43);
                g.DrawLine(drawPen, 0 + i, 40, 30 + i, 40);
                g.DrawLine(drawPen, 30 + i, 40, 0 + i, 30);

                Thread.Sleep(10);
            }

            for (int i = 0; i < 270; i += 8)
            {
                //swerving of plane
                g.Clear(Color.Black);
                g.FillRectangle(GrassBrush, 0, 285, 600, 20);
                g.DrawLine(drawPen, 256 - i , 28 + i/2, 256 - i , 43 + i/2);
                g.DrawLine(drawPen, 256 - i , 40 + i/2, 226 - i, 40 + i/2);
                g.DrawLine(drawPen, 226 - i , 40 + i/2, 256 - i, 30 + i/2);

                g.DrawLine(drawPen, 170 + i , 28 - i, 170 + i, 43 - i);
                g.DrawLine(drawPen, 170 + i , 40 - i, 200 + i, 40 - i);
                g.DrawLine(drawPen, 200 + i , 40 - i, 170 + i, 30 - i);

                Thread.Sleep(10);
            }


            {
                Thread.Sleep(10);
                //End title
                drawBrush.Color = Color.DarkRed;
                Font drawText = new Font("Ariel", 8, FontStyle.Italic);
                g.DrawString(" Thank you for coming to see the show", drawText, drawBrush, 100, 100);
            }


        }
    }
}
