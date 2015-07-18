using System;


namespace Cards
{
    class DillerInf
    {
        public int kol_diller;//сумма очков диллера
        public infcard[] cards_for_diller;//его карты
        public int all_cards_diller;//сколько карт у диллера
        public DillerInf()
        {
            kol_diller = 0;
            cards_for_diller = new infcard[17];
            all_cards_diller = 0;
        }
        public void GiveDiller(Game play)
        {
            while (kol_diller <= 17)
            {
                if ((all_cards_diller == 0))
                {
                    cards_for_diller[all_cards_diller] = play.cld[play.peek];
                    if (play.cld[play.peek].val == 1)
                    {
                        kol_diller += 11;
                    }
                    else
                    {
                        kol_diller += play.cld[play.peek].val;
                    }
                    Console.WriteLine("first card: " + play.cld[play.peek].name + " " + play.cld[play.peek].suit + " (summa: " + kol_diller + " )");
                    all_cards_diller++;
                    play.bot.Num = play.cld[play.peek].val;
                    play.peek++;
                    cards_for_diller[all_cards_diller] = play.cld[play.peek];

                }
                else
                {
                    if (((play.cld[play.peek].val == 1) && (kol_diller + 11 > 21)) || (play.cld[play.peek].val != 1))
                    {
                        cards_for_diller[all_cards_diller] = play.cld[play.peek];
                    }
                    else
                    {
                        cards_for_diller[all_cards_diller] = play.cld[play.peek];
                        cards_for_diller[all_cards_diller].val = 11;
                    }
                }
                if (((play.cld[play.peek].val == 1) && (kol_diller + 11 > 21)) || (play.cld[play.peek].val != 1))
                {
                    kol_diller += cards_for_diller[all_cards_diller].val;
                }
                else
                {
                    kol_diller += 11;
                }

                Console.WriteLine("SECRET card for diller: " + play.cld[play.peek].name + " " + play.cld[play.peek].suit + " (summa: " + kol_diller + " )");
                all_cards_diller++;
                play.bot.Num = play.cld[play.peek].val;
                play.peek++;
                if (all_cards_diller == 2) break;
            }
        }
    }
}
