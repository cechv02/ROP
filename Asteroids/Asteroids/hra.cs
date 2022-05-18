using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class formAsteroids : Form
    {

        int numberofa = 30;  //počet asteroidů
        int direction = 0;
        int acceleration = 0;
        int aspeed = 8;
        int heartindex = 9;        
        int MissileDirection = 1;
        bool fire = false;
        int score = 0;
        int hp = 3;
        double degrees;
        int posx;
        int posy;
        int c, b;
        int keyormouse;
        int acc = 0;

        PictureBox[] pAsteroid = new PictureBox[0];
        PictureBox Heart = new PictureBox();
        PictureBox pSpaceship = new PictureBox();
        PictureBox Missile = new PictureBox();

        public formAsteroids(int gameplay) //0 - keyboard, 1 - mouse | nastavení herního typu
        {
            InitializeComponent();
            keyormouse = gameplay;
            KeyDown += new KeyEventHandler(SpaceshipMove_KeyDown);
            timerRotation.Start();
            
        }

        private void formAsteroids_Load(object sender, EventArgs e) //nastavení hrací plochy
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            label1.Text = "Score: " + score.ToString();

            button1.Visible = false;
            Heart.Image = imageList1.Images[heartindex];
            Heart.Size = new Size((int)(this.Size.Width * .05), (int)(this.Size.Height * .05)); //width,height
            Heart.SizeMode = PictureBoxSizeMode.StretchImage;
            Heart.Left = (int)(this.Size.Width * .94);
            Heart.Top = this.Size.Height - (int)(this.Size.Height * .99);
            Controls.Add(Heart);

            for (int i = 0; i < numberofa; i++) //vytvoření asteroidů na začátku hry
            {
                SpawnAsteroids(i);
            }

            MoveAsteroids();
            SpawnSpaceship();
        }

        Random rand = new Random();
        int randw, randh;
        List<int> oneortwo = new List<int>();
        List<int> oneortwo2 = new List<int>();
        List<int> oneortwo3 = new List<int>();
        //
        //ASTEROIDS
        //
        void SpawnAsteroids(int i) //tvorba asteroidů s náhodnou pozicí
        {
            Array.Resize<PictureBox>(ref pAsteroid, numberofa);
            pAsteroid[i] = new PictureBox();
            pAsteroid[i].Image = imageList1.Images[8];
            pAsteroid[i].Size = new Size(50, 50);
            pAsteroid[i].SizeMode = PictureBoxSizeMode.StretchImage;

            oneortwo.Add(rand.Next(0, 2));
            oneortwo2.Add(rand.Next(0, 2));
            oneortwo3.Add(rand.Next(0, 2));

            if (oneortwo[i] == 0)
            {
                if (oneortwo2[i] == 0)
                {
                    randw = 0;
                    randh = rand.Next(0, this.Size.Height);
                }
                else
                {
                    randw = this.Size.Width;
                    randh = rand.Next(0, this.Size.Height);
                }
            }

            else
            {
                if (oneortwo2[i] == 0)
                {
                    randh = 0;
                    randw = rand.Next(0, this.Size.Width);
                }
                else
                {
                    randh = this.Size.Height;
                    randw = rand.Next(0, this.Size.Width);
                }
            }
            pAsteroid[i].Top = randh;
            pAsteroid[i].Left = randw;
            Controls.Add(pAsteroid[i]);
        }

        private void timerAsteroids_Tick(object sender, EventArgs e) //pohyb asteroidů, kontrola nárazu asteroidu a loďe
        {
            for (int i = 0; i < numberofa; i++)
            {
                switch (oneortwo[i], oneortwo2[i])
                {
                    case (0, 0):
                        {
                            if (pAsteroid[i].Left > ClientSize.Width + 50 || pAsteroid[i].Top > ClientSize.Height + 50)
                            {
                                SpawnAsteroids(i);
                            }
                            else
                            {
                                if (oneortwo3[i] == 0)
                                {
                                    pAsteroid[i].Top += aspeed;
                                    pAsteroid[i].Left += aspeed;
                                }
                                else
                                {
                                    pAsteroid[i].Top -= aspeed;
                                    pAsteroid[i].Left += aspeed;
                                }
                            }
                            break;
                        }


                    case (0, 1):
                        {
                            if (pAsteroid[i].Left < -50 || pAsteroid[i].Top > ClientSize.Height + 50)
                            {
                                SpawnAsteroids(i);
                            }
                            else
                            {
                                if (oneortwo3[i] == 0)
                                {
                                    pAsteroid[i].Top += aspeed;
                                    pAsteroid[i].Left -= aspeed;
                                }
                                else
                                {
                                    pAsteroid[i].Top -= aspeed;
                                    pAsteroid[i].Left -= aspeed;
                                }
                            }
                            break;
                        }



                    case (1, 0):
                        {
                            if (pAsteroid[i].Top > ClientSize.Height + 50 || pAsteroid[i].Left < -50)
                            {
                                SpawnAsteroids(i);
                            }
                            else
                            {
                                if (oneortwo3[i] == 0)
                                {
                                    pAsteroid[i].Top += 10;
                                    pAsteroid[i].Left -= 10;
                                }
                                else
                                {
                                    pAsteroid[i].Top += 10;
                                    pAsteroid[i].Left += 10;
                                }
                            }
                            break;
                        }
                    case (1, 1):
                        {
                            if (pAsteroid[i].Top < -50 || pAsteroid[i].Left > ClientSize.Width + 50)
                            {
                                SpawnAsteroids(i);
                            }
                            else
                            {
                                if (oneortwo3[i] == 0)
                                {
                                    pAsteroid[i].Top -= aspeed;
                                    pAsteroid[i].Left -= aspeed;
                                }
                                else
                                {
                                    pAsteroid[i].Top -= aspeed;
                                    pAsteroid[i].Left += aspeed;
                                }
                            }
                            break;
                        }
                }
            }



            for (int i = 0; i < numberofa; i++)
            {
                if (pAsteroid[i].Bounds.IntersectsWith(pSpaceship.Bounds) && pAsteroid[i].Visible == true && hp!=0)
                {
                    hp--;
                    if (hp >= 0)
                    {
                        pAsteroid[i].Visible = false;
                        Heart.Image = imageList1.Images[heartindex + 1];
                        heartindex++;
                        if (hp == 0)
                        {
                            button1.Visible = true;
                            pSpaceship.Visible = false;
                            Missile.Visible = false;
                            
                            timerMissile.Dispose();
                            timerRotation.Dispose();
                            timerSpaceship.Dispose();

                            int buttonwidth = (int)(this.Size.Width / 7.5);
                            int buttonheight = (int)(this.Size.Height / 5);
                            button1.Size = new Size(buttonwidth, buttonheight);
                            button1.Left = this.Width / 2 - button1.Width / 2;
                            button1.Top = this.Height / 2 - button1.Height / 2;
                            button1.Text = "YOU DIED" + '\r' + "PRESS ENTER TO CONTINUE";
                        }
                    }
                }
            }
        }

    private void button1_Click(object sender, EventArgs e)
        {
            finalscreen screen = new finalscreen(score);
            screen.Show();
            this.Hide();
        }

        void MoveAsteroids()
        {
            timerAsteroids.Start();
        }
        //
        //SPACESHIP
        //
        void SpawnSpaceship() //vytvoření loďe
        {
            pSpaceship.Image = imageList1.Images[0];
            pSpaceship.Size = new Size(60, 60);
            pSpaceship.SizeMode = PictureBoxSizeMode.StretchImage;
            pSpaceship.Left = this.Size.Width / 2 - pSpaceship.Width;
            pSpaceship.Top = this.Size.Height / 2 - pSpaceship.Height;
            Controls.Add(pSpaceship);
        }

        void SpaceshipMove_KeyDown(object sender, KeyEventArgs e) //ovládání pomocí klávesnice
        {
            this.Focus();
            if (keyormouse == 0)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        {
                            direction--;
                            if (direction == -1)
                            {
                                direction = 7;
                            }
                            pSpaceship.Image = imageList1.Images[direction];
                            break;
                        }

                    case Keys.D:
                        {
                            direction++;
                            if (direction == 8)
                            {
                                direction = 0;
                            }
                            pSpaceship.Image = imageList1.Images[direction];
                            break;
                        }

                    case Keys.W:
                        {
                            if (acc == 0)
                            {
                                acc = 1;
                                timerSpaceship.Start();

                            }
                            else
                            {
                                acc = 0;
                            }
                            break;
                        }
                    case Keys.Space:
                        {
                            timerMissile.Interval = 1;
                            timerMissile.Start();
                            break;
                        }

                    /*case Keys.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }*/
                }

            }
            /*else //servisní vypnutí
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }
            }*/
            
        }

        
        private void timerRotation_Tick(object sender, EventArgs e) //rotace pomocí kurzoru
        {
            if (keyormouse == 0) timerRotation.Dispose();
            posx = Cursor.Position.X;   //width, c
            posy = Cursor.Position.Y;   //height, b
            double beta;
            c = (posy - pSpaceship.Top - pSpaceship.Height / 2); 
            b = (posx - pSpaceship.Left - pSpaceship.Width / 2); 

            if (c == 0 && posy <= pSpaceship.Top + pSpaceship.Height / 2) 
            {
                c = -1;
            }
            else if (c == 0 && posy >= pSpaceship.Top + pSpaceship.Height / 2)
            {
                c = 1;
            }

            beta = (double)b / (double)c;
            beta = Math.Atan(beta);
            degrees = (180 / Math.PI) * beta;   //výpočet stupňů pomocí polohy kurzoru
            
            if (posy <= pSpaceship.Top + pSpaceship.Height/2) 
            {
                switch (degrees) //horní polovina loďe
                {
                    case double n when (n < 22.5 && n > -22.5):
                        direction = 0;
                        break;

                    case double n when (n < -22.5 && n > -67.5):
                        direction = 1;
                        break;

                    case double n when (n < -67.5 && n >= -90):
                        direction = 2;
                        break;

                    case double n when (n > 67.5 && n <= 90):
                        direction = 6;
                        break;

                    case double n when (n > 22.5 && n < 67.5):
                        direction = 7;
                        break;
                }                
            }
            else
            {
                switch (degrees) //dolní polovina loďe
                {
                    case double n when (n < 22.5 && n > -22.5):
                        direction = 4;
                        break;

                    case double n when (n < -22.5 && n > -67.5):
                        direction = 5;
                        break;

                    case double n when (n < -67.5 && n > -90):
                        direction = 6;
                        break;

                    case double n when (n > 67.5 && n < 90):
                        direction = 2;
                        break;

                    case double n when (n > 22.5 && n < 67.5):
                        direction = 3;
                        break;
                }
            }
            pSpaceship.Image = imageList1.Images[direction];
        }
        private void formAsteroids_MouseClick(object sender, MouseEventArgs e) //pohyb a střelba myší
        {
            if( e.Button == MouseButtons.Right)
            {
                if (acc == 0)
                {
                    acc = 1;
                    timerSpaceship.Start();

                }
                else
                {
                    acc = 0;
                }
            }
            else
            {                
                timerMissile.Interval = 1;
                timerMissile.Start();
            }
        }

        private void timerSpaceship_Tick(object sender, EventArgs e) //pohyb loďi a pohyb skrz strany obrazovky
        {
            if (acceleration <= 16 && acc == 1) 
            {
                acceleration = acceleration + 2;
            }
            else if(acc==0 && acceleration>=1)
            {
                acceleration--;             
            }
            switch (direction)
            {
                case 0:
                    if (pSpaceship.Bottom >= 0)
                        pSpaceship.Top -= acceleration;
                    else
                        pSpaceship.Top = this.ClientSize.Height + 50;
                    break;

                case 1:
                    if (pSpaceship.Bottom >= 0 && pSpaceship.Right <= this.ClientSize.Width)
                    {
                        pSpaceship.Top -= acceleration;
                        pSpaceship.Left += acceleration;
                    }

                    else
                    {
                        pSpaceship.Left = -50;
                        pSpaceship.Top = this.ClientSize.Height + 50;
                    }
                    break;

                case 2:
                    if (pSpaceship.Right <= this.ClientSize.Width)
                        pSpaceship.Left += acceleration;
                    else
                        pSpaceship.Left = -50;
                    break;
                case 3:
                    if (pSpaceship.Bottom <= this.ClientSize.Height && pSpaceship.Right <= this.ClientSize.Width)
                    {
                        pSpaceship.Top += acceleration;
                        pSpaceship.Left += acceleration;
                    }
                    else
                    {
                        pSpaceship.Left = -50;
                        pSpaceship.Top = -50;
                    }
                    break;
                case 4:
                    if (pSpaceship.Top <= this.ClientSize.Height)
                        pSpaceship.Top += acceleration;
                    else
                        pSpaceship.Top = -50;
                    break;
                case 5:
                    if (pSpaceship.Bottom <= this.ClientSize.Height && pSpaceship.Left >= 0)
                    {
                        pSpaceship.Top += acceleration;
                        pSpaceship.Left -= acceleration;
                    }

                    else
                    {
                        pSpaceship.Left = this.ClientSize.Width + 50;
                        pSpaceship.Top = -50;
                    }
                    break;
                case 6:
                    if (pSpaceship.Top >= 0 && pSpaceship.Left >= 0)
                        pSpaceship.Left -= acceleration;
                    else
                        pSpaceship.Left = this.ClientSize.Width + 50;
                    break;
                case 7:
                    if (pSpaceship.Top >= 0 && pSpaceship.Left >= 0)
                    {
                        pSpaceship.Top -= acceleration;
                        pSpaceship.Left -= acceleration;
                    }

                    else
                    {
                        pSpaceship.Left = this.ClientSize.Width + 50;
                        pSpaceship.Top = this.ClientSize.Height + 50;
                    }
                    break;
            }
        }

        //
        //MISSILE
        //

        private void timerMissile_Tick(object sender, EventArgs e) //tvorba rakety
        {
            if (!fire && hp != 0) 
            {
                Missile.BackColor = Color.Orange;
                MissileStartPosition();
                Missile.Size = new Size(6, 6);
                Controls.Add(Missile);
                fire = true;
            }
            MissileMove();
            HitTest();
        }
        void MissileStartPosition() //počátešní pozice rakety
        {

            if (!fire)
            {
                MissileDirection = direction;
            }
            switch (MissileDirection)
            {
                case 0:
                    Missile.Top = pSpaceship.Top;
                    Missile.Left = pSpaceship.Left + (pSpaceship.Width / 2 - pSpaceship.Width / 20);
                    break;
                case 1:
                    Missile.Top = pSpaceship.Top;
                    Missile.Left = pSpaceship.Left + pSpaceship.Width;
                    break;
                case 2:
                    Missile.Top = pSpaceship.Top + (pSpaceship.Width / 2 - pSpaceship.Width / 20);
                    Missile.Left = pSpaceship.Left + (pSpaceship.Width);
                    break;
                case 3:
                    Missile.Top = pSpaceship.Top + pSpaceship.Width;
                    Missile.Left = pSpaceship.Left + pSpaceship.Width;
                    break;
                case 4:
                    Missile.Top = pSpaceship.Top + pSpaceship.Width;
                    Missile.Left = pSpaceship.Left + (pSpaceship.Width / 2 - pSpaceship.Width / 20);
                    break;
                case 5:
                    Missile.Top = pSpaceship.Top + pSpaceship.Width;
                    Missile.Left = pSpaceship.Left;
                    break;
                case 6:
                    Missile.Top = pSpaceship.Top + (pSpaceship.Width / 2 - pSpaceship.Width / 15);
                    Missile.Left = pSpaceship.Left;
                    break;
                case 7:
                    Missile.Top = pSpaceship.Top;
                    Missile.Left = pSpaceship.Left;
                    break;
            }
        }

        private void DestroyMissile() //zničení rakety pokud mimo hrací pole
        {
            fire = false;
            timerMissile.Enabled = false;
            Controls.Remove(Missile);
        }

        private void MissileMove() //pohyb rakety
        {
            int speed = 20;
            switch (MissileDirection)
            {
                case 0:
                    if (Missile.Bottom >= 0)
                    {
                        Missile.Top -= speed;
                    }
                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 1:
                    if (Missile.Bottom >= 0 && Missile.Right <= this.ClientSize.Width)
                    {
                        Missile.Top -= speed;
                        Missile.Left += speed;
                    }
                    else
                    {
                        DestroyMissile();
                    }
                    break;

                case 2:
                    if (Missile.Right <= this.ClientSize.Width)
                        Missile.Left += speed;
                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 3:
                    if (Missile.Bottom <= this.ClientSize.Height && Missile.Right <= this.ClientSize.Width)
                    {
                        Missile.Top += speed;
                        Missile.Left += speed;
                    }

                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 4:
                    if (Missile.Top <= this.ClientSize.Height)
                        Missile.Top += speed;
                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 5:
                    if (Missile.Bottom <= this.ClientSize.Height && Missile.Left >= 0)
                    {
                        Missile.Top += speed;
                        Missile.Left -= speed;
                    }
                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 6:
                    if (Missile.Top >= 0 && Missile.Left >= 0)
                        Missile.Left -= speed;
                    else
                    {
                        DestroyMissile();
                    }
                    break;
                case 7:
                    if (Missile.Top >= 0 && Missile.Left >= 0)
                    {
                        Missile.Top -= speed;
                        Missile.Left -= speed;
                    }
                    else
                    {
                        DestroyMissile();
                    }
                    break;
            }
        }

        private void HitTest() //testovaní zásahu rakety a asteroidu
        {
            if (fire)
            {
                for (int i = 0; i < numberofa; i++)
                {
                    if (Missile.Bounds.IntersectsWith(pAsteroid[i].Bounds) && pAsteroid[i].Visible == true)
                    {
                        pAsteroid[i].Visible = false;
                        fire = false;
                        timerMissile.Enabled = false;
                        Controls.Remove(Missile);
                        score = score + 10;
                        label1.Text = "Score: " + score.ToString();
                    }
                }
            }
        }
    }
}
