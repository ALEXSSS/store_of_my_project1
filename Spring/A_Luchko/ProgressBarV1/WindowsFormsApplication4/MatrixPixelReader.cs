using System;
using System.Drawing;

namespace WindowsFormsApplication4
{
    class MatrixPixelReader
    {
        public static byte[, ,] matrix(Bitmap BMP2)
        {
            int width = BMP2.Width, height = BMP2.Height;
            byte[, ,] mt = new byte[3, height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Color color = BMP2.GetPixel(j, i);
                    mt[0, i, j] = color.R;
                    mt[1, i, j] = color.G;
                    mt[2, i, j] = color.B;
                }
            }
            return mt;
        }
    }
}
