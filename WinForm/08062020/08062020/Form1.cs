using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _08062020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            //Pen pen = new Pen(Brushes.Blue, 5.3f);
            //pen.DashStyle = DashStyle.Dot;
            //g.DrawEllipse(pen, 10, 30, 300, 100);
            ///Brush
            {
                Rectangle rec1 = new Rectangle(10, 10, 190, 40);
            LinearGradientBrush lgBrush = new LinearGradientBrush(
                rec1, Color.Red, Color.Green, 5f, true);
            g.FillRectangle(lgBrush, rec1);

            Rectangle rec2 = new Rectangle(10, 60, 190, 40);
            HatchBrush hBrush = new HatchBrush(HatchStyle.Cross, Color.Red);
            g.FillRectangle(hBrush, rec2);

            Rectangle rec3 = new Rectangle(10, 110, 190, 40);
            SolidBrush sBrush = new SolidBrush(Color.Green);
            g.FillRectangle(sBrush, rec3);

            Rectangle rec4 = new Rectangle(10, 160, 190, 40);
            TextureBrush tBrush = new TextureBrush(new Bitmap("deposit.png"));
            g.FillRectangle(tBrush, rec4);
        }
            ///DrawString
            {
                Rectangle rec1 = new Rectangle(10, 10, 190, 40);
                LinearGradientBrush lgBrush = new LinearGradientBrush(
                    rec1, Color.Red, Color.Green, 5f, true);
                Font font = new Font("Verdana", 28, FontStyle.Bold | FontStyle.Italic);
                // g.DrawString("Hello It Step", font, tBrush, 210, 10);
                g.DrawString("Hello It Step", font, lgBrush, 210, 10);

            }
            ///Image
            {
                Rectangle recImg = new Rectangle(210, 60, 100, 100);
                g.DrawImage(new Bitmap("smile.jpg"), recImg);
            }
             ///Region
            {
                Rectangle rec1 = new Rectangle(500,10,50,50);
                Rectangle rec2 = new Rectangle(525,10,50,50);

                Region reg1 = new Region(rec1);
                Region reg2 = new Region(rec2);

                g.FillRectangle(Brushes.Gray, rec1);
                g.FillRectangle(Brushes.DarkSeaGreen, rec2);

                reg1.Union(reg2);
                //reg1.Exclude(reg2);
                //reg1.Intersect(reg2);
                //reg1.Complement(reg2);
                //reg1.Xor(reg2);
                g.FillRegion(Brushes.Red, reg1);



              
            
            }
            ///GraphicsPath
            {
                GraphicsPath path = new GraphicsPath();

                path.StartFigure();
                path.AddEllipse(500, 100, 200, 100);

                g.FillPath(Brushes.Aqua, path);

                path.StartFigure();
                path.AddArc(400, 100, 50, 100, 0, 120);
                path.AddLine(400, 100, 300, 100);

                path.StartFigure();
                //Point[] points = new Point[] { 
                //    new Point(200,200),
                //    new Point(300,200),
                //    new Point(300,300),
                //    new Point(200,300),
                //};
                Point[] points = new Point[] {
                    new Point(200,200),
                    new Point(250,250),
                    new Point(300,190),
                    new Point(350,210),
                };
                // path.AddPolygon(points);
                //path.AddCurve(points);
                path.AddBeziers(points);

              //  path.CloseFigure();
                g.DrawPath(new Pen(Brushes.DarkBlue, 3), path);

            }
            g.Dispose();

        }
    }
}
