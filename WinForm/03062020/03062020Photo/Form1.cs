using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03062020Photo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        Point pointMouse;
        bool MouseIsDown = false;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //pointMouse
            if (e.Button== MouseButtons.Left)
            {
                pointMouse = new Point(
                    -e.X,
                    -e.Y
                        
                    ) ;
                //pointMouse = new Point(
                //   -e.X - 2 * SystemInformation.FrameBorderSize.Width,
                //   -e.Y - 2 * SystemInformation.FrameBorderSize.Height -
                //                            SystemInformation.CaptionHeight
                //   );
                MouseIsDown = true;
            }

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsDown) {
                Point curMouse = Control.MousePosition;
                curMouse.Offset(pointMouse);
                Location = curMouse;

            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                MouseIsDown = false;
        }
    }
}
