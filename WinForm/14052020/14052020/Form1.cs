using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14052020
{
    public partial class Form1 : Form
    {
        List<Student> group;

        public Form1()
        {
            InitializeComponent();
            group = new List<Student>();
            group.AddRange(
                new Student[] {
                new Student{
                    Name="Ivan", 
                    Bday= new DateTime(1998,10,25) },
                new Student{
                    Name="Piter",
                    Bday= new DateTime(1999,03,25) },
                new Student{
                    Name="Stepan",
                    Bday= new DateTime(2010,02,24) },
                new Student{
                    Name="Ira",
                    Bday= new DateTime(1960,04,25) },
                }
                );
            listBox1.DataSource = group;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Bday";

            comboBox1.DataSource = group.ToArray();
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Bday";

         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var st = (Student)listBox1.SelectedItem;
            //Text = "" + st;

            var bday=(DateTime)listBox1.SelectedValue;
            Text = "" + bday;

        }

        private void buttonADD_Click(object sender, EventArgs e)
        {
            group.Add(
                new Student
                {
                    Name = "Anna",
                    Bday = new DateTime(2011, 10, 25)
                });

            listBox1.DataSource = null;
            listBox1.DataSource = group;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Bday";

        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Brush brush = Brushes.Red;
            if (e.Index%2==0)
                brush = Brushes.Blue;


            string str = group[e.Index].Name;
            e.Graphics.DrawString(str, e.Font, brush,
                e.Bounds, StringFormat.GenericDefault);
         
            e.DrawFocusRectangle();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //checkedListBox1.SetItemChecked(1, true);
            //checkedListBox1.SetItemCheckState (2, CheckState.Checked);
            //checkedListBox1.SetItemCheckState (3, CheckState.Unchecked);
            //checkedListBox1.SetItemCheckState (4, CheckState.Indeterminate);
            string text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked) {
                    text += checkedListBox1.Items[i] + "\n";
                }
            }
            MessageBox.Show(text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.ImageIndex++;
        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ImageIndex = 0;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ImageIndex = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fullname = System.IO.Path.GetFullPath(@"img\deposit.png");
           // imageList1.Images.Add(Image.FromFile(@"img\deposit.png"));
            imageList1.Images.Add(Image.FromFile(fullname));
            button4.ImageIndex = imageList1.Images.Count - 1;
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
