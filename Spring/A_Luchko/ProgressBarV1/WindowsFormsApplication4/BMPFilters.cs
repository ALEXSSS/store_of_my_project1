using System;


namespace WindowsFormsApplication4
{
    class BMPFilters
    {
        public filtrs filtr;
        public void choose_filtr(int n)
        {
            switch (n)
            {
                //filtr.bl - истина, то соблюдает границы, иначе нет.
                case 1: filtr.fl = new double[3, 3] { { 1, 1, 1 }, { 1, 1, 1 }, { 1, 1, 1 } }; filtr.black = false; filtr.bl = true; filtr.div = 9; break;
                case 2: filtr.fl = new double[3, 3] { { 0.5, 0.75, 0.5 }, { 0.75, 1, 0.75 }, { 0.5, 0.75, 0.5 } }; filtr.black = false; filtr.bl = true; filtr.div = 6; break;
                case 3: filtr.fl = new double[3, 3] { { 0.06163058, 0.12499331, 0.06163058 }, { 0.12499331, 0.25355014, 0.12499331 }, { 0.06163058, 0.12499331, 0.06163058 } }; filtr.black = false; filtr.bl = true; filtr.div = 1; break;
                case 4: filtr.fl = new double[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } }; filtr.black = true; filtr.bl = true; filtr.div = 1; break;
                case 5: filtr.fl = new double[3, 3] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } }; filtr.black = true; filtr.bl = true; filtr.div = 1; break;
                case 6: filtr.fl = new double[3, 3] { { 0, 0, 0 }, { -1, 0, 1 }, { 0, 0, 0 } }; filtr.black = true; filtr.bl = true; filtr.div = 1; break;
                case 7: filtr.fl = new double[3, 3] { { 0, -1, 0 }, { 0, 0, 0 }, { 0, 1, 0 } }; filtr.black = true; filtr.bl = true; filtr.div = 1; break;

                case 8: filtr.fl = new double[3, 3] { { 0.5, 0.75, 0.5 }, { 0.75, 1, 0.75 }, { 0.5, 0.75, 0.5 } }; filtr.black = false; filtr.bl = false; filtr.div = 1; break;
                case 9: filtr.fl = new double[3, 3] { { 0, -1, 0 }, { -1, 0, 1 }, { 0, 1, 0 } }; filtr.black = false; filtr.bl = false; filtr.div = 1; break;
                case 10: filtr.fl = new double[3, 3] { { -0.5, 0.75, 0.5 }, { 0.75, 2, 0.75 }, { 0.5, 0.75, -0.5 } }; filtr.black = false; filtr.bl = false; filtr.div = 1; break;
                case 11: filtr.fl = new double[3, 3] { { 2, 2, 0 }, { 2, 0, 2 }, { 0, 2, 2 } }; filtr.black = true; filtr.bl = true; filtr.div = 5; break;
                case 12: filtr.fl = new double[3, 3] { { 0, -1, 0 }, { -1, 0, 1 }, { 0, 1, 0 } }; filtr.black = true; filtr.bl = true; filtr.div = 5; break;
                default: filtr.fl = new double[3, 3]; break;
            }
        }
    }
    struct filtrs
    {
        public bool black;
        public bool bl;
        public int div;
        public double[,] fl;
    }
}
