using System;


namespace filtrsBMP
{
    class Filtrsname
    {
        public static void menufiltrs()
        {//хранятся названия фильтров, которые будут выведены на экран( не для командной строки);
            Console.WriteLine("Select Filters: ");
            Console.WriteLine("1)Medium filtr.\n");
            Console.WriteLine("2)Convolution.\n");
            Console.WriteLine("3)Filtr Gaussa blur\n");
            Console.WriteLine("4)Filtr Sobel to x\n");
            Console.WriteLine("5)Filtr Sobel to y\n");
            Console.WriteLine("6)Filtr Gaussa to x\n");
            Console.WriteLine("7)Filtr Gaussa to y\n");
            Console.WriteLine("  Other filtrs for large objects\n");
            Console.WriteLine("8)Happy\n");
            Console.WriteLine("9)Pasta\n");
            Console.WriteLine("10)Color filtr\n");
            Console.WriteLine("11)Filtr Sobel to x and y (sunny)\n");
            Console.WriteLine("12)Filtr Gaussa to x and y\n");

            Console.WriteLine("Выбирете фильтр: ");
        }
    }
}
