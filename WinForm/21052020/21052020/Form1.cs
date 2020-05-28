using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _21052020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ColorDialog colorDialog = new ColorDialog();
        private void buttonColor_Click(object sender, EventArgs e)
        {
            //if (colorDialog1.ShowDialog() == DialogResult.OK)
            //    BackColor = colorDialog1.Color;
            //ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
                BackColor = colorDialog.Color;

        }

        private void buttonFolder_Click(object sender, EventArgs e)
        {
            // folderBrowserDialog1.RootFolder = Environment.SpecialFolder.ProgramFiles;
            //folderBrowserDialog1.SelectedPath =  "C:\\Users\\Ustymenko\\Desktop";
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            //  BackColor = colorDialog.Color;
        }

        private void buttonFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
                fontDialog1_Apply(sender, e);
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            label1.Font = fontDialog1.Font;
            label1.ForeColor = fontDialog1.Color;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() ==  DialogResult.OK)
            {
                // textBox1.Text = openFileDialog1.FileName;

                switch (openFileDialog1.FilterIndex)
                {
                    case 1:
                        textBox1.Text = "txt";
                        break;
                    case 2:
                        textBox1.Text = "docx";
                        break;
                    default:
                        textBox1.Text = "all";
                        break;
                }

                listBox1.Items.Clear();
                listBox1.Items.AddRange(openFileDialog1.FileNames);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                textBox2.Text = File.ReadAllText(openFileDialog1.FileName);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, textBox2.Text);

            }
        }

        private void buttonPageSetup_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
        }

        string textToPrint;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var gr = e.Graphics;
            gr.MeasureString(textToPrint, textBox2.Font,e.MarginBounds.Size,
                StringFormat.GenericTypographic,
                out int charOnPage, out int linesOnPage );

            gr.DrawString(textToPrint, textBox2.Font, Brushes.Red,
                e.MarginBounds, StringFormat.GenericTypographic);

            textToPrint = textToPrint.Substring(charOnPage);

            e.HasMorePages = textToPrint.Length > 0;

            if (!e.HasMorePages) textToPrint = textBox2.Text;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                textToPrint = textBox2.Text;
                printDocument1.Print();
            }
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            textToPrint = textBox2.Text;
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
