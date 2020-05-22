using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _19052020
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Child child = new Child();
            //1 private->public child.textBox1
            // child.textBox1.Text = textBox1.Text;

            //2  public Child(string text)
            //Child child = new Child(textBox1.Text);

            //3 public Child(FormMain main) 
            // Child child = new Child(this);

            //4
            //Child child = new Child();
            //child.SetText = textBox1.Text;

            //child.ShowDialog();

            //5
            // Child child = new Child();
            // child.ShowDialog(textBox1.Text);

            // child.Show();
            //  child.ShowDialog();

            // Child to Main
            Child child = new Child();
            child.SetText = textBox1.Text;
            if (child.ShowDialog() == DialogResult.OK)
                textBox1.Text = child.GetText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Child child = new Child())
            {
                if (child.ShowDialog() == DialogResult.OK)
                    listBox1.Items.Add(child.Product);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                using (Child child = new Child())
                {
                    int pos = listBox1.SelectedIndex;
                    child.Product = listBox1.SelectedItem as Tovar;
                    if (child.ShowDialog() == DialogResult.OK)
                    {
                        listBox1.Items.RemoveAt(pos);
                        listBox1.Items.Insert(pos, child.Product);
                        listBox1.SelectedIndex = pos;
                    }
                }

            }
            else
                MessageBox.Show("Виберіть товар для редагування");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
