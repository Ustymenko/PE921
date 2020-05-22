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
    public partial class Child : Form
    {
        public Tovar Product { get; set; }
        public string SetText
        {
            set => textBox1.Text = value;
        }
        public string GetText => textBox1.Text;
        //{
        //    get => textBox1.Text;
        //}
        public Child()
        {
            InitializeComponent();
        }
        public Child(string text) : this()
        {
            textBox1.Text = text;
        }
        public Child(FormMain main) : this()
        {
            textBox1.Text = main.textBox1.Text;
        }

        public DialogResult ShowDialog(string text)
        {
            textBox1.Text = text;
            return ShowDialog();
        }

        private void Child_Load(object sender, EventArgs e)
        {
            if (Product is null)
                Text = "Новий товар";
            else
            {
                Text = "Редагуємо товар";
                textBox1.Text = Product.Name;
                textBox2.Text = Product.MadeIn;
                textBox3.Text = $"{Product.Price:f2}";
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Controls
                     .OfType<TextBox>()
                     .Any(x => String.IsNullOrWhiteSpace(x.Text)))
                {
                    MessageBox.Show("Заповніть всі поля");
                    return;
                }
                Product = new Tovar {
                    Name = textBox1.Text,
                    MadeIn = textBox2.Text,
                    Price =double.Parse(textBox3.Text)
                };
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
