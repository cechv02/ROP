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
    public partial class menu : Form
    {
        public menu()
        {           
            InitializeComponent();
            
        }
        private void menu_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            button4.Visible = false;
            button5.Visible = false;
            int buttonwidth = this.Size.Width / 6;
            int buttonheight = this.Size.Height / 6;
            button1.Size = new Size(buttonwidth, buttonheight);
            button2.Size = new Size(buttonwidth, buttonheight);
            button3.Size = new Size(buttonwidth, buttonheight);
            button4.Size = new Size(buttonwidth, buttonheight);
            button5.Size = new Size(buttonwidth, buttonheight);
            int middle = this.Size.Width / 2 - buttonwidth / 2;
            button1.Left = middle;
            button1.Top = (int)(this.Size.Height / 5.5);
            button2.Left = middle;
            button2.Top = this.Size.Height / 2 - buttonheight / 2;
            button3.Left = middle;
            button3.Top = (int)(this.Size.Height / 1.5);
            button4.Left = middle;
            button4.Top = this.Size.Height / 2 - buttonheight / 2 - buttonheight / 2;
            button5.Left = middle;
            button5.Top = this.Size.Height / 2 + buttonheight/2- buttonheight / 2; ;
        }

        private void button1_Click(object sender, EventArgs e) //start
        {
            button4.Visible = true;
            button5.Visible = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;

            /*finalscreen final = new finalscreen(10);
            final.Show();
            this.Hide();*/
        }

        private void button2_Click(object sender, EventArgs e) //highscore
        {
            highscore high = new highscore();
            high.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e) //exit
        {
            Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formAsteroids hra = new formAsteroids(0);
            hra.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formAsteroids hra = new formAsteroids(1);
            hra.Show();
            this.Hide();
        }
    }

}
