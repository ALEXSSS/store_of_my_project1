using System;


namespace filtrsBMP
{
    // delegate double[,] STRMOD();(*)
    static class ChooseBMPclass
    {//заполняем фильтры значениями
        public static int n;
        public static bool black;
        public static bool bl;
        public static int div;
        public static double[,] fl;
        static public void FiltrsChoose()
        {
            //STRMOD d1 = new STRMOD(filtrs); для многопоточнсти придётся использовать не статическое поле(*)
            Filtrsname.menufiltrs();
            //n = int.Parse(Console.ReadLine());
            filtrs();
        }
        static void filtrs()//почему нельзя указать определённый размер массива
        {
            switch (n)
            {
                //black - истинна оставляй прозрачность, иначе заливай чёрным.
                //bl - истина, то соблюдает границы, иначе нет.
                case 1: fl = new double[3, 3] { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } }; black = true; bl = true; div = 8; break;
                case 2: fl = new double[3, 3] { { 0.5, 0.75, 0.5 }, { 0.75, 1, 0.75 }, { 0.5, 0.75, 0.5 } }; black = true; bl = true; div = 6; break;
                case 3: fl = new double[3, 3] { { 0.06163058, 0.12499331, 0.06163058 }, { 0.12499331, 0.25355014, 0.12499331 }, { 0.06163058, 0.12499331, 0.06163058 } }; black = true; bl = true; div = 1; break;
                case 4: fl = new double[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }; black = false; bl = true; div = 1; break;
                case 5: fl = new double[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } }; black = false; bl = true; div = 1; break;
                case 6: fl = new double[3, 3] { { 0, 0, 0 }, { -1, 0, 1 }, { 0, 0, 0 } }; black = false; bl = true; div = 1; break;
                case 7: fl = new double[3, 3] { { 0, -1, 0 }, { 0, 0, 0 }, { 0, 1, 0 } }; black = false; bl = true; div = 1; break;

                case 8: fl = new double[3, 3] { { 0.5, 0.75, 0.5 }, { 0.75, 1, 0.75 }, { 0.5, 0.75, 0.5 } }; black = false; bl = false; div = 1; break;
                case 9: fl = new double[3, 3] { { 0, -1, 0 }, { -1, 0, 1 }, { 0, 1, 0 } }; black = false; bl = false; div = 1; break;
                case 10: fl = new double[3, 3] { { -0.5, 0.75, 0.5 }, { 0.75, 2, 0.75 }, { 0.5, 0.75, -0.5 } }; black = false; bl = false; div = 1; break;
                case 11: fl = new double[3, 3] { { 2, 2, 0 }, { 2, 0, 2 }, { 0, 2, 2 } }; black = false; bl = true; div = 5; break;
                case 12: fl = new double[3, 3] { { 0, -1, 0 }, { -1, 0, 1 }, { 0, 1, 0 } }; black = false; bl = true; div = 5; break;
                default: fl = new double[3, 3]; break;
            }
        }
    }
}
