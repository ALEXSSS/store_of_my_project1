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
    public partial class Form1 : Form
    {
        private int _allowPaint = 0;
        public Form1()
        {
            InitializeComponent();
        }

     
        private void butsin_Click(object sender, EventArgs e)
        {
            _allowPaint = 2;
            pictureBox1.Invalidate();
        }
        private void buexp_Click(object sender, EventArgs e)
        {
            _allowPaint = 3;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            _allowPaint = 0;
            pictureBox1.Invalidate();
        }

        private void butx2_Click(object sender, EventArgs e)
        {
            _allowPaint = 4;
            pictureBox1.Invalidate();
        }

        private void butx3_Click(object sender, EventArgs e)
        {
            _allowPaint = 5;
            pictureBox1.Invalidate();
        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            FuncOXY.paintOXY(e, pictureBox1);//вопрос
            Functionpaint.PaintFun(e, pictureBox1, _allowPaint);
        }

        private void butcos_Click(object sender, EventArgs e)
        {
            _allowPaint = 1;
            pictureBox1.Invalidate();
        }
    }
}
