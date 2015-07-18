using System;


namespace Cards
{
    class Game
    {
        public PlayerInf player;
        public DillerInf diller;
        public byte peek;
        public infcard[] cld = new infcard[208];
        public int startgame = 0;
        public Game(int coins)
        {
            player = new PlayerInf(coins);
            peek = 0;
            for (int i = 1; i < 208; i++)
            {
                cld[i - 1] = RecognisingCard.StrToCard(i % 52);
            }
            diller = new DillerInf();
            startgame++;
        }
        public void ShowCoins()
        {
            Console.Write("Coins: " + player.coins);
            Console.ReadKey();
        }
        public void RandomCards()
        {
            CreateRandomCards.RandomCards(this);
        }
        public void ShowCards()
        {
            for (int i = 0; i < 208; i++) Console.WriteLine(cld[i].name + " " + cld[i].suit + " " + cld[i].val);
        }
        public void GiveDiller()
        {
            diller.GiveDiller(this);
        }
        public void GivePlayer()
        {
            player.GivePlayer(this);
        }
        public static void BlackJack(Game play1)
        {
            BasisBlackJack.BlackJack(play1);
        }
    }
}
