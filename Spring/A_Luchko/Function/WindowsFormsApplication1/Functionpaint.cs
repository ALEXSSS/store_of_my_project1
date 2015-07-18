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
using System.Drawing;


namespace WindowsFormsApplication1
{
    static class Functionpaint
    {
       public static void PaintFun(PaintEventArgs e, PictureBox pictureBox1,int _allowPaint)
       {
           var graphPen = new Pen(Color.Black);
           if (_allowPaint == 0)
            {
                return;
            }
            else
            {
                var points = new PointF[pictureBox1.Size.Width];
                if (_allowPaint == 1)
                {
                    for (var i = 0; i < pictureBox1.Size.Width; i++)
                    {
                        points[i] = new PointF(i, Function.Fcos(i - (pictureBox1.Size.Width / 2)) + pictureBox1.Size.Height / 2);
                    }
                }
                if (_allowPaint == 2)
                {
                    for (int i = 0; i < pictureBox1.Size.Width; i++)
                    {
                        points[i] = new PointF(i, Function.Fsin(i - (pictureBox1.Size.Width / 2)) + pictureBox1.Size.Height / 2);
                    }
                }
                if (_allowPaint == 3)
                {
                    for (int i = 0; i < pictureBox1.Size.Width; i++)
                    {
                        points[i] = new PointF(i, Function.Fexp(i - (pictureBox1.Size.Width / 2)) + pictureBox1.Size.Height / 2);
                    }
                }
                if (_allowPaint == 4)
                {
                    for (int i = 0; i < pictureBox1.Size.Width; i++)
                    {
                        points[i] = new PointF(i, Function.Fx2(i - (pictureBox1.Size.Width / 2)) + pictureBox1.Size.Height / 2);
                    }
                }
                if (_allowPaint == 5)
                {
                    for (int i = 0; i < pictureBox1.Size.Width; i++)
                    {
                        points[i] = new PointF(i, Function.Fx3(i - (pictureBox1.Size.Width / 2)) + pictureBox1.Size.Height / 2);
                    }
                }
                e.Graphics.DrawCurve(graphPen, points);
            }
            _allowPaint = 0;
       }
    }
}
