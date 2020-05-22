using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _05052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //"Copy & Paste"
            labelInfo.UseMnemonic = false; //for &
            labelInfo.Text = "Copy & Paste";

            Label label2 = new Label();
            Controls.Add(label2);
            label2.Font = new Font("Arial", 14);
            label2.ForeColor = Color.Red;
            label2.Text = "It Step";
            label2.Location = new Point(150, 250);

            Button btNo = new Button();
            Controls.Add(btNo);
            btNo.Text = "No";
            btNo.Location = new Point(285, 162);
            btNo.Size = new Size(147, 72);
            btNo.Font = new Font("Microsoft Sans Serif", 14);
            btNo.ForeColor = Color.Red;
            btNo.UseVisualStyleBackColor = true;
            btNo.BackColor = SystemColors.Control;
            //  btNo.Click += btOk_Click;
            btNo.Click += Bt_Click;

        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start("http://ukr.net");
            // Process.Start("calc.exe");
            linkLabel1.LinkVisited = true;

        }

        private void Bt_Click(object sender, EventArgs e)
        {
            if (sender is Button kn)
                MessageBox.Show($"BUTTON {kn.Text} click ", "info",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BUTTON Ok click No", "info",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("BUTTON Ok click YES", "info",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            // MessageBox.Show("BUTTON Ok click");
            // MessageBox.Show("BUTTON Ok click","info");
            //if (MessageBox.Show("BUTTON Ok click", "info",
            //     MessageBoxButtons.YesNo, MessageBoxIcon.Information,
            //     MessageBoxDefaultButton.Button2) == DialogResult.Yes)

            //    MessageBox.Show("BUTTON Ok click YES", "info",
            //    MessageBoxButtons.OK, MessageBoxIcon.Information);
            //else
            //    MessageBox.Show("BUTTON Ok click No", "info",
            //   MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btOk_MouseMove(object sender, MouseEventArgs e)
        {
            MessageBox.Show("BUTTON Ok click No", "info",
         MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }

}
