using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using filtrsBMP;

namespace filtrsBMP
{
    public class WriteBMPclass
    {//класс занимается только записью изображения, после выбора фильтра
        string nameRead;
        string nameWrite;
        int n;
        public WriteBMPclass(string name, string name1, string n)
        {
            this.nameWrite = name1;
            this.nameRead = name;
            this.n = int.Parse(n);
        }
        public void WriteBMP1()
        {         
            FileStream FILE = new FileStream(nameWrite, FileMode.Create);
            BinaryWriter dataout = new BinaryWriter(FILE);
            BITMAP BMP = new BITMAP(nameRead);//считали файл
            dataout.Write(BMP.HeadBMP.bfType);
            dataout.Write(BMP.HeadBMP.bfSize);
            dataout.Write(BMP.HeadBMP.Reserved1);
            dataout.Write(BMP.HeadBMP.Reserved2);
            dataout.Write(BMP.HeadBMP.bfOffBits);

            dataout.Write(BMP.HeadBMP.biSize);
            dataout.Write(BMP.HeadBMP.biWidth);
            dataout.Write(BMP.HeadBMP.biHeight);
            dataout.Write(BMP.HeadBMP.biPlanes);
            dataout.Write(BMP.HeadBMP.biBitCount);
            dataout.Write(BMP.HeadBMP.biCompression);
            dataout.Write(BMP.HeadBMP.biSizeImage);
            dataout.Write(BMP.HeadBMP.biXPelsPerMeter);
            dataout.Write(BMP.HeadBMP.biYPelsPerMeter);
            dataout.Write(BMP.HeadBMP.biClrUsed);
            dataout.Write(BMP.HeadBMP.biClrImportant);
            ChooseBMPclass.n = n;
            ChooseBMPclass.FiltrsChoose();

            byte zero = 0;
            int k = (int)(4 - (BMP.HeadBMP.biWidth * 3) % 4) % 4;
            byte red, green, blue;
            double red1 = 0, green1 = 0, blue1 = 0;
            byte black = 255;
 
            if (ChooseBMPclass.black)
             {
                 for (int i = 0; i < Math.Abs(BMP.HeadBMP.biWidth); i++)
                 {
                     dataout.Write(BMP.matrix[0, i].rgbBlue);
                     dataout.Write(BMP.matrix[0, i].rgbGreen);
                     dataout.Write(BMP.matrix[0, i].rgbRed);
                 }
             }
             else
             {
                 for (int i = 0; i < Math.Abs(BMP.HeadBMP.biWidth); i++)
                 {
                     dataout.Write(black);
                     dataout.Write(black);
                     dataout.Write(black);
                 }
             }
             for (int i = 0; i < k; i++)
             {
                 dataout.Write(zero);
             }
             for (int i = 1; i < Math.Abs(BMP.HeadBMP.biHeight) - 1; i++)
             {
                 if (ChooseBMPclass.black)
                 {
                     dataout.Write(BMP.matrix[i, 0].rgbBlue);
                     dataout.Write(BMP.matrix[i, 0].rgbGreen);
                     dataout.Write(BMP.matrix[i, 0].rgbRed);
                 }
                 else
                 {
                     dataout.Write(black);
                     dataout.Write(black);
                     dataout.Write(black);
                 }
                 for (int j = 1; j < Math.Abs(BMP.HeadBMP.biWidth) - 1; j++)
                 {
                     for (int i12 = 0; i12 < 3; i12++)
                         for (int j1 = 0; j1 < 3; j1++)
                         {
                             red1 = red1 + BMP.matrix[i + i12 - 1, j + j1 - 1].rgbRed * ChooseBMPclass.fl[i12, j1];
                             blue1 = blue1 + BMP.matrix[i + i12 - 1, j + j1 - 1].rgbBlue * ChooseBMPclass.fl[i12, j1];
                             green1 = green1 + BMP.matrix[i + i12 - 1, j + j1 - 1].rgbGreen * ChooseBMPclass.fl[i12, j1];
                         }
                     blue = (byte)(ChooseBMPclass.bl ? (blue1 / ChooseBMPclass.div) > 255 ? 255 : (blue1 / ChooseBMPclass.div) < 0 ? 0 : (blue1 / ChooseBMPclass.div) : blue1);
                     red = (byte)(ChooseBMPclass.bl ? (red1 / ChooseBMPclass.div) > 255 ? 255 : (red1 / ChooseBMPclass.div) < 0 ? 0 : (red1 / ChooseBMPclass.div) : red1);
                     green = (byte)(ChooseBMPclass.bl ? (green1 / ChooseBMPclass.div) > 255 ? 255 : (green1 / ChooseBMPclass.div) < 0 ? 0 : (green1 / ChooseBMPclass.div) : green1);
                     red1 = blue1 = green1 = 0;
                     dataout.Write(blue);
                     dataout.Write(green);
                     dataout.Write(red);
                 }
                 if (ChooseBMPclass.black)
                 {
                     dataout.Write(BMP.matrix[i, Math.Abs(BMP.HeadBMP.biWidth) - 1].rgbBlue);
                     dataout.Write(BMP.matrix[i, Math.Abs(BMP.HeadBMP.biWidth) - 1].rgbGreen);
                     dataout.Write(BMP.matrix[i, Math.Abs(BMP.HeadBMP.biWidth) - 1].rgbRed);
                 }
                 else
                 {
                     dataout.Write(black);
                     dataout.Write(black);
                     dataout.Write(black);
                 }
                 for (int i1 = 0; i1 < k; i1++)
                 {
                     dataout.Write(zero);
                 }
             }
             if (ChooseBMPclass.black)
             {
                 for (int i = 0; i < Math.Abs(BMP.HeadBMP.biWidth); i++)
                 {
                     dataout.Write(BMP.matrix[BMP.HeadBMP.biHeight - 1, i].rgbBlue);
                     dataout.Write(BMP.matrix[BMP.HeadBMP.biHeight - 1, i].rgbGreen);
                     dataout.Write(BMP.matrix[BMP.HeadBMP.biHeight - 1, i].rgbRed);
                 }
             }
             else
             {
                 for (int i = 0; i < Math.Abs(BMP.HeadBMP.biWidth); i++)
                 {
                     dataout.Write(black);
                     dataout.Write(black);
                     dataout.Write(black);
                 }
             }
             for (int i1 = 0; i1 < k; i1++)
             {
                 dataout.Write(zero);
             }
            Console.WriteLine("Complete");
            FILE.Close();
        }
    }
}

