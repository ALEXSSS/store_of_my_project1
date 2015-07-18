using System;


namespace Cards
{
    class Game
    {
        public DillerInf diller;
        public PlayerInf player;

        //информация о колоде
        public byte peek;
        public infcard[] cld = new infcard[208];
        public int startgame = 0;

        public BotForBlackJack bot;

        public Game(double coins)
        {
            player = new PlayerInf(coins);
            peek = 0;
            for (int i = 0; i < 208; i++)
            {
                cld[i] = RecognisingCard.StrToCard(i % 52);
            }
            diller = new DillerInf();
            startgame++;
            bot = new BotForBlackJack(208);
        }
        public void ShowCoins()
        {
            Console.Write("Coins: {0:.#}", player.coins);
            Console.ReadKey();
        }
        public void RandomCards()
        {
            CreateRandomCards.RandomCards(this);
        }
        public void ShowColods()
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
