using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Asteroids
{
    public partial class finalscreen : Form
    {
        int savescore;
        public finalscreen(int score)
        {           
            InitializeComponent();
            label1.Text = "Your score is " + score.ToString();
            savescore = score;
        }
        private void finalscreen_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            int spaceh = this.Size.Width / 40;
            int spacew = this.Size.Height / 15;
            
            label2.Left = this.Size.Width / 2 - label2.Width / 2;
            label2.Top = (int)(this.Size.Height / 2) - label2.Height / 2 - spaceh;
            label1.Left = this.Size.Width / 2 - label1.Width / 2;
            label1.Top = label2.Top - label2.Height - spaceh;
            textBox1.Left = this.Size.Width / 2 - textBox1.Width / 2;
            textBox1.Top = label2.Top  + spaceh;
            button1.Left = this.Size.Width / 2 - button1.Width / 2 - spacew;
            button1.Top = textBox1.Top + spaceh;
            button2.Left = this.Size.Width / 2 - button2.Width / 2 + spacew;
            button2.Top = textBox1.Top + spaceh;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu backtomenu = new menu();
            backtomenu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                string fileName = @"scorelog.txt";

                using (FileStream fs = new FileStream(fileName, FileMode.Append, FileAccess.Write))
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine(textBox1.Text + " " + savescore);
                }              
            }
            highscore high = new highscore();
            high.Show();
            this.Hide();
        }
    }
}
