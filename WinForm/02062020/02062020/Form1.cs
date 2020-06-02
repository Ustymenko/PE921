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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openToolStripMenuItem_Click(null, null);
        }

        int count = 1;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.MdiParent = this;
            child.Text = "New window" + count++;

            child.Show();
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void mycascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeSelectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveMdiChild?.Close();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //while (ActiveMdiChild!=null)
            //{
            //    ActiveMdiChild.Close();
            //}
            foreach (var childForm in this.MdiChildren)
            {
                childForm.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.DefaultExt = "*.rtf";
                saveDialog.Filter = "RTF filter|*.rtf|All files|*.*";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    RichTextBox box = ActiveMdiChild?.Controls.OfType<RichTextBox>().FirstOrDefault();
                    //box?.SaveFile(saveDialog.FileName);
                    //  box?.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText); 
                    // box?.SaveFile(saveDialog.FileName, RichTextBoxStreamType.RichNoOleObjs);
                    //  box?.SaveFile(saveDialog.FileName, RichTextBoxStreamType.RichText);
                    //   box?.SaveFile(saveDialog.FileName, RichTextBoxStreamType.TextTextOleObjs);
                    box?.SaveFile(saveDialog.FileName, RichTextBoxStreamType.UnicodePlainText);

                }
            }
        }

        private void OpenToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = "RTF filter|*.rtf|TXT filter|*.txt|All files|*.*";
                openDialog.FilterIndex = 1;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    ChildForm child = new ChildForm();
                    child.MdiParent = this;
                    child.Text = openDialog.FileName;
                    RichTextBox box = child?.Controls.OfType<RichTextBox>().FirstOrDefault();


                    // box?.LoadFile(openDialog.FileName, RichTextBoxStreamType.RichText);
                    try
                    {
                        box?.LoadFile(openDialog.FileName, RichTextBoxStreamType.RichText);
                    }
                    catch
                    {
                        try
                        {
                            box?.LoadFile(openDialog.FileName, RichTextBoxStreamType.PlainText);
                        }
                        catch
                        {
                            MessageBox.Show("Error format file");
                        }
                    }

                    child.Show();
                }
            }
        }
    }
}
