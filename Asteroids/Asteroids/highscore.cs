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
    public partial class highscore : Form
    {
        public highscore()
        {
            InitializeComponent();
            this.Focus();
        }

        private void highscore_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            int textwidth = this.Size.Width / 3;
            int textheight = (int)(this.Size.Height / 1.25);
            textBox1.Size = new Size(textwidth, textheight);
            textBox1.Left = this.Size.Width / 2 - textBox1.Width / 2;
            textBox1.Top = this.Size.Height / 2 - textBox1.Height / 2;           
            label1.Text = "Leaderboard";
            label1.Left = this.Size.Width / 2 - label1.Width / 2;
            List<int> score = new List<int>();
            try
            {
                string lines = File.ReadAllText("scorelog.txt");
                lines = lines.Replace("\n", " ").Replace("\r", "");
                string[] array = lines.Split(' ');

                for (int i = 1; i < array.Length; i += 2)
                {
                    score.Add(Convert.ToInt32(array[i]));
                }
                score.Sort();
                score.Reverse();

                foreach (int a in score)
                {
                    int index = Array.IndexOf(array, a.ToString());
                    string name = array[index - 1];
                    textBox1.Text += name + " " + a.ToString() + "\r\n";
                    array = array.Where((val, idx) => idx != index).ToArray();
                }
                label1.Focus();
            }
            catch { MessageBox.Show("neexistuje soubor scorelog.txt"); }                   
        }

        private void highscore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Environment.Exit(0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menu backtomenu = new menu();
            backtomenu.Show();
            this.Hide();
        }
    } 
}

