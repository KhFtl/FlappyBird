using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        Player bird;
        Tube tube1;
        Tube tube2;
        float gravity;
        int score;
        const int tubeSpeed = 50;
        public Form1()
        {
            InitializeComponent();
            Init();
            Invalidate(); //перемальовка форми
        }

        private void Init()
        {
            bird = new Player(50, this.Size.Height / 2);
            tube1 = new Tube(this.Size.Width, -100, true);
            tube2 = new Tube(this.Size.Width, this.Height-100);
            timer1.Start();
            gravity = 0;
            score = 0;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Rectangle rect = this.ClientRectangle;
            Image backGround = GameResource.background;
            graphics.DrawImage(backGround, rect);
            graphics.DrawImage(bird.birdImage, bird.x, bird.y, bird.size, bird.size);
            graphics.DrawImage(tube1.tubeImage, tube1.x, tube1.y, tube1.sizeX, tube1.sizeY);
            graphics.DrawImage(tube2.tubeImage, tube2.x, tube2.y, tube2.sizeX, tube2.sizeY);

            Font f = new Font("Verdana",14,FontStyle.Bold);
            graphics.DrawString($"Score: {score}", f, Brushes.Black, 0, 0);
        }
        private void CreateTube()
        {
            if (tube1.x < bird.x - 150)
            {
                score++;
                int y1, y2;
                Random rnd = new Random();
                y1 = rnd.Next(-150, -10);
                y2 = rnd.Next(this.Size.Height / 2, this.Size.Height - 50);
                tube1 = new Tube(this.Size.Width - 100, y1, true);
                tube2 = new Tube(this.Size.Width - 100, y2);
            }
        }

        private void MoveTubes()
        {
            tube1.x -= (score + tubeSpeed);
            tube2.x -= (score + tubeSpeed);
            CreateTube();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bird.y > this.Size.Height || bird.y <= 0)
            { 
                bird.isAlive = false;
                timer1.Stop();
                MessageBox.Show($"Game Over! Your score: {score}");
                Init();
            }
            if (Collide(bird, tube1) || Collide(bird, tube2))
            {
                bird.isAlive = false;
                timer1.Stop();
                MessageBox.Show($"Game Over! Your score: {score}");
                Init();
            }

            if (bird.gravityValue != 0.1f)
            { 
                bird.gravityValue += 0.005f;
            }
            gravity += bird.gravityValue;
            bird.y += gravity;
            MoveTubes();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (bird.isAlive)
            {
                if (e.KeyCode == Keys.Space)
                {
                    gravity = 0;
                    bird.gravityValue = -0.15f;
                }
                if (e.KeyCode == Keys.F1)
                {
                    gravity = 0;
                    bird.y = this.Size.Height / 2 - bird.size;
                }
            }
        }

        private bool Collide(Player bird, Tube tube)
        { 
            PointF delta = new PointF();
            delta.X = (bird.x + bird.size / 2) - (tube.x + tube.sizeX / 2);
            delta.Y = (bird.y + bird.size / 2) - (tube.y + tube.sizeY / 2);
            if (Math.Abs(delta.Y) <= bird.size / 2 + tube.sizeX / 2)
            {
                if (Math.Abs(delta.Y) <= bird.size / 2 + tube.sizeY / 2)
                {
                    return true;
                }
            }
            return false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }
    }
}
