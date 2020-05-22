using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11052020
{
    public partial class Form1 : Form
    {
        Timer tm = new Timer();
        Timer tm2 = new Timer();
        //using System.Media;
        SoundPlayer s = new SoundPlayer("1.wav");
        public Form1()
        {
            // SoundPlayer
            InitializeComponent();
            tm.Interval = 1000;
            tm.Tick += Tm_Tick;
            tm.Enabled = true;
            //s.Play();
            //s.Stop();
            tm2.Interval = 1000;
            tm2.Tick += Tm2_Tick;

        }



        private void Tm_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(
                       label1.Location.X + 20,
                       label1.Location.Y);

        }

        void Test()
        {

            for (int i = 0; i < 20; i++)
            {
                label1.Location = new Point(
                        label1.Location.X + 20,
                        label1.Location.Y);
                System.Threading.Thread.Sleep(2000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Test();
            int rez = 0;
            foreach (var item in groupBox2.Controls)
                if (item is CheckBox chb && chb.CheckState == CheckState.Checked)
                    rez += int.Parse(chb.Text);
            Text = "" + rez;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(
                        label1.Location.X + 20,
                        label1.Location.Y);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
        private void Tm2_Tick(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 0)
                numericUpDown1.Value -= 1;
            if (numericUpDown1.Value == 0)
            {
                tm2.Stop();
                s.Play();
                button4.Text = "Start";
                numericUpDown1.Enabled = true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "Start")
            {
                button4.Text = "Stop";
                tm2.Start();
                numericUpDown1.Enabled = false;
            }
            else
            {
                tm2.Stop();
                button4.Text = "Start";
                numericUpDown1.Enabled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Аня");
            comboBox1.Items.Remove("Аня");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //  Text = comboBox1.Text;
            // Text = comboBox1.SelectedItem?.ToString();

            //  if (comboBox1.SelectedItem is null)
            int idx = comboBox1.SelectedIndex;
            if (idx < 0)
                MessageBox.Show("not selected item");
            else
                Text = comboBox1.Items[idx].ToString();
            // Text = comboBox1.SelectedItem.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Text = comboBox1.SelectedItem?.ToString();
        }
    }
}
