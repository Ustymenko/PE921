using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _18052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //  Text = hScrollBar1.Value.ToString();
            // Text = "" + this.ClientSize.Height;
           int dx= pictureBox1.Image.Width - pictureBox1.Width;
            if (dx > 0)
            {
                hScrollBar1.Show();
                hScrollBar1.Maximum = dx > 0 ? dx : 0;
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    g.DrawImage(pictureBox1.Image,
                        pictureBox1.Bounds,
                        new Rectangle(hScrollBar1.Value, 0, pictureBox1.Width, pictureBox1.Height),
                        GraphicsUnit.Pixel);
                };
            }
            else 
                hScrollBar1.Hide();
            pictureBox1.Update();
            


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            int dx = pictureBox1.Image.Width - pictureBox1.Width;
            if (dx > 0)
            {
                hScrollBar1.Show();
        }
            else
                hScrollBar1.Hide();
            pictureBox1.Update();
        }
        int i = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string[] files= Directory.GetFiles("img");
            i = i >=files.Count() ? 0 : i;
            pictureBox1.Image = Image.FromFile(files[i++]);
            pictureBox1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  progressBar1.Value+=20;
            myProgressBar1.PerformStep();
          //  progressBar1.PerformStep();
            label1.Text = $"{100.0*progressBar1.Value/ progressBar1.Maximum,6:F2} %";
        }

       
    }
}
