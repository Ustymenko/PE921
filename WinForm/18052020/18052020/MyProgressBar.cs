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

namespace _18052020
{
    public partial class MyProgressBar : ProgressBar
    {
        public MyProgressBar()
        {
            InitializeComponent();
            SetStyle(
                ControlStyles.UserPaint  | 
                ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                , true);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // base.OnPaint(pe);
            Graphics gr = pe.Graphics;
           
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.SmoothingMode = SmoothingMode.HighQuality;
            gr.PixelOffsetMode = PixelOffsetMode.HighQuality;

            Rectangle RecPB = ClientRectangle;
            ProgressBarRenderer.DrawHorizontalBar(gr, RecPB);
            int val = Width * Value / Maximum;
            Rectangle green = new Rectangle(
                1,1,val-2,RecPB.Height-2);
            ProgressBarRenderer.DrawHorizontalChunks(gr, green);
            string text= $"{100.0 * Value / Maximum,6:F2} %";

            float sizefont = Height / 2.5f;
            Font font = new Font(FontFamily.GenericMonospace, sizefont, FontStyle.Bold);
            SizeF sizeF = gr.MeasureString(text, font);

            Point pointT = new Point(
                (int)(Width- sizeF.Width)/2,
                 (int)(Height - sizeF.Height) / 2 +2
                );

            gr.DrawString(text,font, new SolidBrush(ForeColor),pointT);







        }
    }
}
