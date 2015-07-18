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
    static class FuncOXY
    {
        public static void paintOXY(PaintEventArgs e, PictureBox pictureBox1)
        {
            var paper = e.Graphics;
            var gridPen = new Pen(Color.Gray);
            paper.Clear(Color.White);
            //Прорисовка осей
            paper.DrawLine(gridPen, pictureBox1.Size.Width / 2, 0, pictureBox1.Size.Width / 2, pictureBox1.Size.Height);
            paper.DrawLine(gridPen, 0, pictureBox1.Size.Height / 2, pictureBox1.Size.Width, pictureBox1.Size.Height / 2);
            for (int i = 0; i < 11; i++)
            {
                paper.DrawLine(gridPen, (pictureBox1.Size.Width / 2) + 50 * (i - 5), (pictureBox1.Size.Height / 2) - 3, (pictureBox1.Size.Width / 2) + 50 * (i - 5), (pictureBox1.Size.Height / 2) + 3);
                paper.DrawLine(gridPen, (pictureBox1.Size.Width / 2) - 3, (pictureBox1.Size.Height / 2) + 50 * (i - 5), (pictureBox1.Size.Width / 2) + 3, (pictureBox1.Size.Height / 2) + 50 * (i - 5));
            }
        }
    }
}
