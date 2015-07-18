using System;
using System.IO;



namespace filtrsBMP
{
    public class BITMAP
    {
        //читаем файл
        public HeaderBMP HeadBMP;
        public BMPRGB[,] matrix;
        public string name;
        public BITMAP(string name)
        {
            this.name = name;
            ReadBMP();
        }

        void ReadBMP()
        {
            
            FileStream BMP = new FileStream(name, FileMode.Open);
            BinaryReader dataout = new BinaryReader(BMP);
            HeadBMP = new HeaderBMP();
            HeadBMP.bfType = dataout.ReadInt16();
            HeadBMP.bfSize = dataout.ReadUInt32();
            HeadBMP.Reserved1 = dataout.ReadInt16();
            HeadBMP.Reserved2 = dataout.ReadInt16();
            HeadBMP.bfOffBits = dataout.ReadInt32();

            HeadBMP.biSize = dataout.ReadUInt32();
            HeadBMP.biWidth = dataout.ReadInt32();
            HeadBMP.biHeight = dataout.ReadInt32();
            HeadBMP.biPlanes = dataout.ReadUInt16();
            HeadBMP.biBitCount = dataout.ReadUInt16();
            HeadBMP.biCompression = dataout.ReadUInt32();
            HeadBMP.biSizeImage = dataout.ReadUInt32();
            HeadBMP.biXPelsPerMeter = dataout.ReadInt32();
            HeadBMP.biYPelsPerMeter = dataout.ReadInt32();
            HeadBMP.biClrUsed = dataout.ReadUInt32();
            HeadBMP.biClrImportant = dataout.ReadUInt32();
            int k = (int)(4 - (HeadBMP.biWidth * 3) % 4) % 4;
            matrix = new BMPRGB[Math.Abs(HeadBMP.biHeight), Math.Abs(HeadBMP.biWidth)];
            for (int i = 0; i < Math.Abs(HeadBMP.biHeight); i++)
            {
                for (int j = 0; j < Math.Abs(HeadBMP.biWidth); j++)
                {
                    matrix[i, j].rgbBlue = dataout.ReadByte();
                    matrix[i, j].rgbGreen = dataout.ReadByte();
                    matrix[i, j].rgbRed = dataout.ReadByte();
                }
                for (int i1 = 0; i1 < k; i1++)
                    dataout.ReadByte();
            }
        }
    }

    public struct BMPRGB
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
    }
    public struct HeaderBMP
    {
        public short bfType;
        public uint bfSize;
        public short Reserved1;
        public short Reserved2;
        public int bfOffBits;

        public uint biSize;
        public int biWidth; //может быть отрицателен
        public int biHeight;
        public ushort biPlanes;
        public ushort biBitCount; //Количество бит на пиксель
        public uint biCompression;
        public uint biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public uint biClrUsed;
        public uint biClrImportant;
    }
}

