using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _12052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Igor");
            listBox1.Items.Add(10);
            int[] arr = new int[] { 10, 20, 30, 40, 50 };
            listBox1.Items.AddRange(arr.Select(x => (object)x).ToArray());

            listBox1.Items.Add(new Student { Name = "Piter",
                Bday=new DateTime(1996,10,25) });
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            //listBox1.Items.RemoveAt(1);
            //  listBox1.Items.Remove("Петро");
            if (listBox1.SelectedIndex != -1)
            {
                if (MessageBox.Show($"Видалити {listBox1.SelectedItem}?", "Видалення", MessageBoxButtons.YesNo)
                    == DialogResult.Yes)
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
                MessageBox.Show("Не вибрано елемент для видалення");
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            MessageBox.Show("" + listBox1.SelectedIndices.Count);

            MessageBox.Show(
                String.Join("\t", listBox1.SelectedItems.OfType<String>())
                );
            MessageBox.Show(
            String.Join("\t", listBox1.SelectedIndices.OfType<int>())
            );
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            // listBox1.SetSelected(2, true);
            // listBox1.ClearSelected();

        }

        private void MoveElem(ListBox dest, ListBox source)
        {
           if (source.SelectedItem  is null) 
                MessageBox.Show("Не вибрано елемент");
           else
            while (source.SelectedItem != null)
            {
                dest.Items.Add(source.SelectedItems[0]);
                source.Items.Remove(source.SelectedItems[0]);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            MoveElem(listBox2, listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MoveElem(listBox1, listBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                if (listBox1.SelectedItem is Student st) {

                    MessageBox.Show(""+st);
                    st.Name = "Ivan";
                    listBox1.Items[listBox1.SelectedIndex] = st;
                };
            }
            else
                MessageBox.Show("Не вибрано елемент для видалення");

        }
    }

    class Student
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }
        public override string ToString()
        {
            return $"{Name} {Bday.ToShortDateString()}";
        }
    }
}


