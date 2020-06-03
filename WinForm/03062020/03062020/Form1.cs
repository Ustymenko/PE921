using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03062020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox2.AllowDrop = true;
        }

        string buf = String.Empty;
        bool selected = false;
        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selected)
                textBox1.DoDragDrop(buf, DragDropEffects.Copy);
            selected = false;
        }
        private void textBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (textBox1.SelectionLength > 0)
            {
                buf = textBox1.SelectedText;
                selected = true;
            }
        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            string text = e.Data.GetData(DataFormats.StringFormat) as string;
            if (!String.IsNullOrWhiteSpace(text))
                listBox1.Items.Add(text);
        }

        private void listBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files.Length > 0)
            {
                listBox2.Items.Clear();
                listBox2.Items.AddRange(files);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (pictureBox1.Image !=null)
            pictureBox1.DoDragDrop(pictureBox1.Image, DragDropEffects.Move);
        }
        private void pictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            pictureBox2.Image= (Bitmap)e.Data.GetData(DataFormats.Bitmap);
            pictureBox1.Image = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // ControlExtension.Draggable(textBox1, true);
            ControlExtension.Draggable(pictureBox2, true);

        }
    }
}
