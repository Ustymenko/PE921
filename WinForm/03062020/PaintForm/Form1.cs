using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddPolygon(new[] {
                new Point(0,ClientSize.Height),
                new Point(ClientSize.Width/2,0),
                new Point(ClientSize.Width, ClientSize.Height)
            });
            this.Region = new Region(path);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
