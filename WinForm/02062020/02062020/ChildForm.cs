using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _02062020
{
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        private void rEdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red  ;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor = Color.Blue;
        }

        private void addTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Несе Галя воду\nКоромисло гнеться\n";
            richTextBox1.AppendText("Line 2" + System.Environment.NewLine);
            richTextBox1.AppendText("В одной из прошлых заметок я писал о том, что изменяемые значимые типы являются достаточно опасным инструментом, который в неумелых руках может привести к неожиданному поведению и трудноуловимым ошибкам. В общем, дело это хорошее, но опасное; а сегодня будет еще пара примеров, подтверждающих все эти мысли." + System.Environment.NewLine);

        }

        private void goToCursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.ScrollToCaret();
        }

        private void lengthRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Text =""+ richTextBox1.Lines[1].Length;
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // richTextBox1.Font
            richTextBox1.SelectionFont = new Font("Verdana",22, FontStyle.Bold);
        }

        private void colorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionColor = Color.Red;
        }

        private void selectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectionStart = 10;
            //richTextBox1.SelectionLength = 30;
            //richTextBox1.Focus();

            richTextBox1.Select(10, 20);

          //  richTextBox1.SelectAll();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;

        }
    }
}
