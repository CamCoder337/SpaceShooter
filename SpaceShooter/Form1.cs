namespace SpaceShooter
{
    public partial class Form1 : Form

    {
        PictureBox[] stars;
        int bgSpeed;
        Random rnd;
        int playerSpeed = 6;

        PictureBox[] munitions;
        int Munitionspeed;

        public Form1()
        {

            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgSpeed = 4;
            stars = new PictureBox[25];
            rnd = new Random();

            Munitionspeed = 25;
            munitions = new PictureBox[3];

            //Load images
            Image munition = Image.FromFile("munition.png");
            for(int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(8,8);
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]);
            }


            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].BorderStyle = BorderStyle.None;
                stars[i].Location = new Point(rnd.Next(20, 580), rnd.Next(-10, 400));

                if (i % 2 == 1)
                {
                    stars[i].Size = new Size(2, 2);
                    stars[i].BackColor = Color.Wheat;

                }
                else
                {
                    stars[i].Size = new Size(3, 3);
                    stars[i].BackColor = Color.DarkGray;

                }

                this.Controls.Add(stars[i]);
            }
        }

        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length / 2; i++)
            {
                stars[i].Top += bgSpeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += bgSpeed - 2;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10)
            {
                Player.Left -= playerSpeed;
            }

        }
        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left + playerSpeed < 530)
            {
                Player.Left += playerSpeed;
            }

        }

        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 400)
            {
                Player.Top += playerSpeed;
            }

        }


        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10)
            {
                Player.Top -= playerSpeed;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                RightMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                LeftMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Up)
            {
                UpMoveTimer.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                DownMoveTimer.Start();
            }
            if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.Space))
            {
                for(int i=0; i < munitions.Length; i++)
                {
                    munitions[i].Visible = true;
                }
            }

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            DownMoveTimer.Stop();
            LeftMoveTimer.Stop();
            UpMoveTimer.Stop();
            RightMoveTimer.Stop();
            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i].Visible = false;
            }

        }

        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < munitions.Length; i++)
            {
                if (munitions[i].Top > 10)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= Munitionspeed;
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 20, Player.Location.Y - i * 30);

                }
            }
        }
    }
}
