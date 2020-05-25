using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _25052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text = "Save";
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blueToolStripMenuItem.Checked)
                BackColor = Color.Blue;
            else
                BackColor = SystemColors.Control;

        }

        private void uaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (menuStrip1.Visible) {

                menuStrip1.Hide();
                menuStrip3.Show();
            }
            else
            {

                menuStrip3.Hide();
                menuStrip1.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuStrip main = new MenuStrip();
            ToolStripMenuItem file = new ToolStripMenuItem("File");
            main.Items.Add(file);
            {
                file.DropDownItems.Add("Open");
                file.DropDownItems.Add(new ToolStripSeparator());
                ToolStripMenuItem save = (ToolStripMenuItem)file.DropDownItems.Add("Save");
                save.ShortcutKeys = Keys.Control | Keys.S;
                save.Click += saveToolStripMenuItem_Click;
            }
            // ToolStripMenuItem edit = (ToolStripMenuItem)main.Items.Add("Edit");
            // ToolStripMenuItem edit=(ToolStripMenuItem)main.Items[1];
            main.Items.Add("Edit");
            ToolStripMenuItem edit = main.Items
                .OfType<ToolStripMenuItem>()
                .Where(x=>x.Text== "Edit")
                .FirstOrDefault();            
            {
                edit.DropDownItems.Add("Cut");
                edit.DropDownItems.Add(new ToolStripSeparator());
                edit.DropDownItems.Add("Copy");
                edit.DropDownItems.Add(new ToolStripSeparator());
                edit.DropDownItems.Add("Paste");
            }

            this.Controls.Add(main);




            //ToolStripMenuItem edit = 

        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Text = "Color";
        }
    }
}
