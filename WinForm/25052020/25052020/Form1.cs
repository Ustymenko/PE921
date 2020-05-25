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
            if (menuStrip1.Visible)
            {

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
                .Where(x => x.Text == "Edit")
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Text = "StripButton1";
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            Text = "StripSplitButton1";
        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            Text = "toolStripDropDownButton1";
        }

        int i = 1;
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage newpage = new TabPage("New file" + i++);
            tabControl1.TabPages.Add(newpage);
            TextBox tb = new TextBox
            {
                Dock = DockStyle.Fill,
                ScrollBars = ScrollBars.Both,
                Multiline = true,
            };
            tb.TextChanged += textBox_TextChanged;
            newpage.Controls.Add(tb);

            tabControl1.SelectedTab = newpage;
        }

        private void closeActivitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != -1)
            {
                TextBox tb = tabControl1.SelectedTab.Controls.OfType<TextBox>().FirstOrDefault();
                if (tb != null)
                {

                    if (tb.Tag is bool fl && fl)
                    {
                        Text = "Змінено";
                    }
                    else
                    {

                        tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);

                    }

                }


            }
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                tb.Tag = true;
            }

        }
    }
}
