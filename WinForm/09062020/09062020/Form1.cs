using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _09062020
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer { 
            Interval=500
        };
        int R ;
        int r;
        int xc;
        int yc;
        int step;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            r = 20;
            step = DateTime.Now.Second;
            ClientSize = new Size(600, 600);
            xc = ClientSize.Width / 2;
            yc = ClientSize.Height / 2;
            R = (int)(Math.Min(ClientSize.Width, ClientSize.Height) / 2)-r-5;

            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            //using (Graphics g = CreateGraphics())
            //{

            //    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //    g.TranslateTransform(xc, yc);
            //    Pen penRed = new Pen(Brushes.Red, 1);
            //    g.RotateTransform(step*360/12);
            //    g.FillEllipse(Brushes.Blue, R - r , -r, r * 2, r * 2);
            //    //g.DrawLine(penRed, -R, 0, R, 0);
            //    // g.DrawLine(penRed, 0, -R, 0, R);
            //    step++;
            //}
            step = DateTime.Now.Second;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            ///--------------------Task 2-----------------
            xc = ClientSize.Width / 2;
            yc = ClientSize.Height / 2;
            R = (int)(Math.Min(ClientSize.Width, ClientSize.Height) / 2) - r - 5;

            g.TranslateTransform(xc, yc);
            Pen penRed = new Pen(Brushes.Red, 1);
            g.RotateTransform(step * 360 / 60-90);
            g.FillEllipse(Brushes.Blue, R - r, -r, r * 2, r * 2);

            g.TranslateTransform(R , 0);
            g.RotateTransform(-step * 360 / 60 +90);
            g.DrawString(""+ step, new Font("Arial", 14), Brushes.Red, -r/2-3, -10);


            //  g.ResetTransform();









            //------------------------------------------------------------------------
            //   // g.PageUnit = GraphicsUnit.Millimeter;
            //   g.DrawString("Hello It Step Zhytomyr 2020",
            //      new Font("Arial", 14), Brushes.DarkBlue,
            //      new Rectangle(10, 20, 90, 100),
            //      new StringFormat
            //      {
            //          Alignment = StringAlignment.Far,
            //          LineAlignment = StringAlignment.Center,
            //          FormatFlags = StringFormatFlags.FitBlackBox
            //      }
            //      );


            //   Pen penBlue = new Pen(Brushes.Blue, 5);
            //   Pen penRed = new Pen(Brushes.Red, 5);
            //   g.DrawLine(penBlue, 10, 20, 190, 20);

            //   int R = 100;
            //   int xc = ClientSize.Width/2;
            //   int yc = ClientSize.Height/2;

            //   g.DrawEllipse(penBlue,xc-R,yc-R,R*2,R*2);

            //   R = 100;
            //   g.TranslateTransform(xc, yc);
            ////   g.ScaleTransform(0.5f, 0.5f);
            //   g.DrawEllipse(penRed, - R,  - R, R * 2, R * 2);
            // //  g.ScaleTransform(2f, 2f);


            //   g.DrawLine(penRed, 0, 0, 150, 0);

            //   g.DrawLine(penRed, 0, 0, 120, -120);

            //   //  g.DrawLine(penBlue, 0, 0,(float) (150/Math.Sqrt(2)), (float)(-150 / Math.Sqrt(2)));//150

            //   g.RotateTransform(245);
            //   g.DrawLine(penBlue, 0, 0, 150, 0);
            //   g.DrawString("Hello", new Font("Arial",14), Brushes.Green, 50,-24);

            //   g.DrawString("Hello It Step Zhytomyr 2020",
            //       new Font("Arial", 14), Brushes.DarkBlue, 
            //       new Rectangle(-100,0,100,100),
            //       new StringFormat {
            //           Alignment= StringAlignment.Center,
            //           LineAlignment = StringAlignment.Center,
            //           FormatFlags = StringFormatFlags.FitBlackBox
            //       }
            //       );




            // g.TranslateTransform(100, 100);
            //  g.DrawEllipse(pen,)
            // g.DrawLine(new Pen(Brushes.Blue,3), 10, 20, 190, 20);



            // g.Dispose();
        }
    }
}
