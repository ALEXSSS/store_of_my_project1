using System;


namespace Cards
{
    static class CreateRandomCards
    {
        public static void RandomCards(Game play)
        {
            Random rnd = new Random();
            byte[] ost = new byte[208];//запоминает перемешанные
            int kol = 103;
            int start = 104;
            for (int i = 0; i < 207; i++) ost[i] = 1;
            for (int i = 0; i < 103; i++)
            {
                int pl = rnd.Next(kol - i);
                int control = 0;
                while (control != pl + 1)
                {
                    if (ost[start] == 1)
                    {
                        start++; control++;
                    }
                    else
                    {
                        start++;
                    }
                }
                start--;
                infcard m = play.cld[i];
                play.cld[i] = play.cld[start];
                play.cld[start] = m;
                ost[i] = ost[start] = 0;
                start = 0;
                //bot.num = 0;
            }
            Console.WriteLine();
            play.bot.num = 0;
            play.peek = 0;
        }
    }
}
