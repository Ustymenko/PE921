using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _28052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //listView1.Items.Add("Аня");
            ListViewItem anna = listView1.Items.Add("Іщук");
            anna.SubItems.Add("Ання");
            anna.SubItems.Add("95");
            anna.SubItems.Add("12");
            anna.ImageIndex = 3;

            // listView1.Items.Add(anna); errror

            // anna.Group = listView1.Groups[1];

            // string namegr = "PE921";
            //  anna.Group =listView1.Groups.OfType<ListViewGroup>().Where(g => g.Header == namegr).FirstOrDefault();

            ListViewGroup newgr = new ListViewGroup("TA112");
            listView1.Groups.Add(newgr);
            anna.Group = newgr;

        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //listView1.Items.RemoveAt(0);
            // listView1.Items.Clear();
            //if (listView1.SelectedIndices.Count>0)
            //    listView1.Items.RemoveAt(listView1.SelectedIndices[0]);

            listView1.SelectedItems.OfType<ListViewItem>().ToList().ForEach(listView1.Items.Remove);

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                listView1.SelectedItems[0].SubItems[0].Text = "1";
                listView1.SelectedItems[0].SubItems[1].Text = "2";
                listView1.SelectedItems[0].SubItems[2].Text = "3";
                listView1.SelectedItems[0].SubItems[3].Text = "4";
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int dx = 10;
            if (!checkBox1.Checked)
            {
                if (panel2.Width >= 5) panel2.Width -= dx;
                if (panel2.Width < 5)
                {
                    timer1.Stop();
                    panel2.Hide();
                }
            }
            else
            {
                panel2.Show();
                if (panel2.Width < 120) panel2.Width += dx;
                if (panel2.Width >= 120)
                    timer1.Stop();
            }




        }
    }
}
