using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApplication4
{
    // Thread thread;
    delegate void ProgressB();
    class FilterWorker
    {
        Bitmap BMP;
        int num_filtr;
        PictureBox pictureBox2;
        ProgressBar progressBar1;
        ProgressThread pr;
        public FilterWorker(Bitmap BMP1, int num_filtr1, PictureBox pictureBox21, ProgressBar progressBar21)
        {
            BMP = BMP1;
            num_filtr = num_filtr1;
            pictureBox2 = pictureBox21;
            progressBar1 = progressBar21;
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = BMP.Height - 2;
            pr = new ProgressThread(progressBar1);
        }
        public void FilterWork()
        {
            pictureBox2.Image = BMPCreate.bmp_create(BMP, num_filtr, progressBar1, pr);
            pictureBox2.Invalidate();
            Form1.worker = false;
        }
    }
}
