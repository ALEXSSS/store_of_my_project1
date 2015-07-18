using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    class BMPCreate
    {
        public Bitmap BMP;
        public int num_filtr;
        public BMPCreate(Bitmap BMP, int num_filtr)
        {
            this.BMP = BMP;
            this.num_filtr = num_filtr;
        }
        static public Bitmap bmp_create(Bitmap BMP, int num_filtr, ProgressBar progressBar1, ProgressThread pr)
        {

            BMPFilters flr = new BMPFilters();
            byte[, ,] rs;
            rs = MatrixPixelReader.matrix(BMP);
            Bitmap BMP1 = new Bitmap(BMP.Width, BMP.Height);
            Color colorBMP1;//переменная, которая будет задавать цвет
            double red1 = 0, blue1 = 0, green1 = 0;
            byte red = 0, blue = 0, green = 0;
            flr.choose_filtr(num_filtr);

            if (flr.filtr.black)
            {
                for (int j = 0; j < BMP.Width; j++) BMP1.SetPixel(j, 0, Color.Black);
            }
            else
            {
                for (int j = 0; j < BMP.Width; j++) BMP1.SetPixel(j, 0, BMP.GetPixel(j, 0));
            }

            for (int i = 1; i < BMP.Height - 1; i++)
            {
                progressBar1.Invoke(pr.MyDelegate);
                if (flr.filtr.black) BMP1.SetPixel(0, i, Color.Black);
                for (int j = 1; j < BMP.Width - 1; j++)
                {
                    for (int p = 0; p < 3; p++)
                        for (int p1 = 0; p1 < 3; p1++)
                        {
                            red1 += flr.filtr.fl[p, p1] * rs[0, i + p - 1, j + p1 - 1];
                            green1 += flr.filtr.fl[p, p1] * rs[1, i + p - 1, j + p1 - 1];
                            blue1 += flr.filtr.fl[p, p1] * rs[2, i + p - 1, j + p1 - 1];
                        }
                    blue = (byte)(flr.filtr.bl ? (blue1 / flr.filtr.div) > 255 ? 255 : (blue1 / flr.filtr.div) < 0 ? 0 : (blue1 / flr.filtr.div) : blue1);
                    red = (byte)(flr.filtr.bl ? (red1 / flr.filtr.div) > 255 ? 255 : (red1 / flr.filtr.div) < 0 ? 0 : (red1 / flr.filtr.div) : red1);
                    green = (byte)(flr.filtr.bl ? (green1 / flr.filtr.div) > 255 ? 255 : (green1 / flr.filtr.div) < 0 ? 0 : (green1 / flr.filtr.div) : green1);
                    colorBMP1 = Color.FromArgb((int)red, (int)green, (int)blue);
                    BMP1.SetPixel(j, i, colorBMP1);
                    red1 = blue1 = green1 = 0;
                }
                if (flr.filtr.black) BMP1.SetPixel(BMP.Width - 1, i, Color.Black);
            }
            if (flr.filtr.black)
            {
                for (int j = 0; j < BMP.Width; j++) BMP1.SetPixel(j, BMP.Height - 1, Color.Black);
            }
            else
            {
                for (int j = 0; j < BMP.Width; j++) BMP1.SetPixel(j, BMP.Height - 1, Color.White);
            }
            return BMP1;
        }
    }
}
