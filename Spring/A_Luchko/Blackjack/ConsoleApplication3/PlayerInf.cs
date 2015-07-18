using System;


namespace Cards
{
    class PlayerInf
    {
        public int coins;
        public int kol_player;
        public int bid;
        public PlayerInf(int coins)
        {
            this.coins = coins;
            kol_player = 0;
            bid = 0;
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
            play.peek++;
            Console.Write("Do you want to continue take cards? ");

            while ((String.Compare(Console.ReadLine(), "yes", true) == 0) && (kol_player <= 21))
            {
                //Console.Write(" " + cld[peek].name + " " + cld[peek].suit);
                if (((play.cld[play.peek].val == 1) && (play.diller.kol_diller + 11 > 21)) || (play.cld[play.peek].val != 1))
                {
                    kol_player += play.cld[play.peek].val;
                    play.peek++;
                    Console.WriteLine("Your Points: " + play.cld[play.peek - 1].name + " " + play.cld[play.peek - 1].suit + " (summa: " + play.player.kol_player + ")");
                    if (kol_player == 21) break;
                }
                else
                {
                    kol_player += 11;
                    play.peek++;
                    Console.WriteLine("Your Points: " + play.cld[play.peek - 1].name + " " + play.cld[play.peek - 1].suit + " (summa: " + kol_player + ")");
                    if (kol_player == 21) break;
                }
                if (kol_player <= 21) Console.Write("Do you want to continue take cards? ");
            }
        }
    }
}
