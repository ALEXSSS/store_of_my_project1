using System;


namespace Cards
{
    class PlayerInf
    {
        public double coins;
        public int kol_player;
        public double bid;
        public byte win;
        public PlayerInf(double coins)
        {
            this.coins = coins;
            kol_player = 0;
            bid = 0;
            win = 0;
        }
        public void GivePlayer(Game play)
        {
            if (play.cld[play.peek].val != 1)
            {
                kol_player += play.cld[play.peek].val;
            }
            else
            {
                kol_player += 11;
            }
            Console.WriteLine("Your Points: " + play.cld[play.peek].name + " " + play.cld[play.peek].suit + " (summa: " + kol_player + ")");
            play.bot.Num = play.cld[play.peek].val;
            play.peek++;


            while (BotControl.TakeCards(play.bot.Num, kol_player))
            {
                //Console.Write(" " + cld[peek].name + " " + cld[peek].suit);
                if (((play.cld[play.peek].val == 1) && (play.diller.kol_diller + 11 > 21)) || (play.cld[play.peek].val != 1))
                {
                    kol_player += play.cld[play.peek].val;
                    play.bot.Num = play.cld[play.peek].val;
                    play.peek++;
                    Console.WriteLine("Your Points: " + play.cld[play.peek - 1].name + " " + play.cld[play.peek - 1].suit + " (summa: " + kol_player + ")");
                }
                else
                {
                    kol_player += 11;
                    play.bot.Num = play.cld[play.peek].val;
                    play.peek++;
                    Console.WriteLine("Your Points: " + play.cld[play.peek - 1].name + " " + play.cld[play.peek - 1].suit + " (summa: " + kol_player + ")");
                }
            }
        }
    }
}
