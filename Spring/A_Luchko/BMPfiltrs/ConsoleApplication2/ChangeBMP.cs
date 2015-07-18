using System;
using System.IO;
using filtrsBMP;
//using System.Exception;


namespace BMP1
{
    class General
    {
        static void Main(string[] args)
        {
            try
            {
                WriteBMPclass BMP = new WriteBMPclass(args[0], args[1],args[2]);
                BMP.WriteBMP1();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Возникла ошибка чтения или записи файл. Проверьте: является ли файл формата bmp, а также существует ли он.");
            }
        }
    }
}
