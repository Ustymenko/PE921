using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// + - * /
namespace _07052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox1.AutoCompleteCustomSource.Add("Юра");
        }

        private void btResult_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(textA.Text, out double a))
            {
                MessageBox.Show("Введіть число у поле А", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Double.TryParse(textB.Text, out double b))
            {
                MessageBox.Show("Введіть число у поле B", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (sender is Button bt)
            {
                switch (bt.Text)
                {
                    case "+":
                        textResult.Text = "" + (a + b);
                        break;
                    case "-":
                        textResult.Text = "" + (a - b);
                        break;
                    case "*":
                        textResult.Text = "" + (a * b);
                        break;
                    case "/":
                        if (b != 0)
                            textResult.Text = "" + (a / b);
                        else
                            MessageBox.Show("На нуль ділити не можна", "Помилка",
                                                MessageBoxButtons.OK,
                                                MessageBoxIcon.Information);
                        break;
                }

            }

        }
        private void textClear_TextChanged(object sender, EventArgs e)
        {
            textResult.Text = "";
        }
        private void textFilterNumber(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox tb)
            {
                char number = e.KeyChar;
                char numberDecSepar = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

                if (number == '-' && (tb.Text.Contains("-") || tb.Text.Length > 0))
                    e.Handled = true;
                else
                if (number == numberDecSepar && tb.Text.Length == 0)
                {
                    tb.Text = "0" + numberDecSepar;
                    e.Handled = true;
                    tb.SelectionStart = tb.Text.Length;
                }
                else
                if (number == numberDecSepar && tb.Text[0] == '-' && tb.Text.Length == 1)
                {
                    tb.Text = "-0" + numberDecSepar;
                    e.Handled = true;
                    tb.SelectionStart = tb.Text.Length;
                }
                else
                if (number == numberDecSepar && tb.Text.Contains(numberDecSepar))
                    e.Handled = true;
                // if (char.IsLetter(number))
                else
                if (!char.IsDigit(number) && number != numberDecSepar && number != 8 && number != '-')
                    e.Handled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(textA.Text, out double a))
            {
                MessageBox.Show("Введіть число у поле А", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Double.TryParse(textB.Text, out double b))
            {
                MessageBox.Show("Введіть число у поле B", "Помилка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton1.Checked)  textResult.Text = "" + (a + b);
            else
            if (radioButton2.Checked)  textResult.Text = "" + (a - b);
            else
            if (radioButton3.Checked)  textResult.Text = "" + (a * b);
            else
            if (radioButton4.Checked) 
                if (b != 0)
                    textResult.Text = "" + (a / b);
                else
                    MessageBox.Show("На нуль ділити не можна", "Помилка",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
        }
    }
}
