using System;


namespace Cards
{
    //класс cards отвечает за индивидуальную игру диллера с одним из игроков
    //здесь собраны данные о колоде, состояние счёта игрока, а также функции замешивания карт и их выдачи
    //количество игроков может быть изменено


    class Game
    {
        diller_inf diller;
        player_inf player;

        //информация о колоде
        byte peek;
        infcard[] cld = new infcard[208];
        int startgame = 0;

        BotForBlackJack bot;

        public Game(double coins)
        {
            this.player.coins = coins;
            peek = 0;
            for (int i = 0; i < 208; i++)
            {
                cld[i] = RecognisingCard.str_to_card(i % 52);
            }
            diller.cards_for_diller = new infcard[17];
            diller.all_cards_diller = 0;
            startgame++;
            player.bid = 0;
            diller.kol_diller = player.kol_player = player.win = 0;
            bot = new BotForBlackJack(208);
        }
        void Show_coins()
        {
            Console.Write("Coins: {0:.#}", player.coins);
            Console.ReadKey();
        }
        //.......................................операции по раздаче карт
        //замешаем карты
        void random_cards()
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
                infcard m = cld[i];
                cld[i] = cld[start];
                cld[start] = m;
                ost[i] = ost[start] = 0;
                start = 0;
                //bot.num = 0;
            }
            Console.WriteLine();
            bot.num = 0;
            peek = 0;
        }
        public void show_colods()
        {
            for (int i = 0; i < 208; i++) Console.WriteLine(cld[i].name + " " + cld[i].suit + " " + cld[i].val);
        }
        void give_diller()
        {
            while (diller.kol_diller <= 17)
            {
                if ((diller.all_cards_diller == 0))
                {
                    diller.cards_for_diller[diller.all_cards_diller] = cld[peek];
                    if (cld[peek].val == 1)
                    {
                        diller.kol_diller += 11;
                    }
                    else
                    {
                        diller.kol_diller += cld[peek].val;
                    }
                    Console.WriteLine("first card: " + cld[peek].name + " " + cld[peek].suit + " (summa: " + diller.kol_diller + " )");
                    diller.all_cards_diller++;
                    bot.num = cld[peek].val;
                    peek++;
                    diller.cards_for_diller[diller.all_cards_diller] = cld[peek];

                }
                else
                {
                    if (((cld[peek].val == 1) && (diller.kol_diller + 11 > 21)) || (cld[peek].val != 1))
                    {
                        diller.cards_for_diller[diller.all_cards_diller] = cld[peek];
                    }
                    else
                    {
                        diller.cards_for_diller[diller.all_cards_diller] = cld[peek];
                        diller.cards_for_diller[diller.all_cards_diller].val = 11;
                    }
                }
                if (((cld[peek].val == 1) && (diller.kol_diller + 11 > 21)) || (cld[peek].val != 1))
                {
                    diller.kol_diller += diller.cards_for_diller[diller.all_cards_diller].val;
                }
                else
                {
                    diller.kol_diller += 11;
                }

                Console.WriteLine("SECRET card for diller: " + cld[peek].name + " " + cld[peek].suit + " (summa: " + diller.kol_diller + " )");
                diller.all_cards_diller++;
                bot.num = cld[peek].val;
                peek++;
                if (diller.all_cards_diller == 2) break;
            }
        }
        void give_player()
        {
            if (cld[peek].val != 1)
            {
                player.kol_player += cld[peek].val;
            }
            else
            {
                player.kol_player += 11;
            }
            Console.WriteLine("Your Points: " + cld[peek].name + " " + cld[peek].suit + " (summa: " + player.kol_player + ")");
            bot.num = cld[peek].val;
            peek++;


            while (BotControl.take_cards(bot.num, player.kol_player))
            {
                //Console.Write(" " + cld[peek].name + " " + cld[peek].suit);
                if (((cld[peek].val == 1) && (diller.kol_diller + 11 > 21)) || (cld[peek].val != 1))
                {
                    player.kol_player += cld[peek].val;
                    bot.num = cld[peek].val;
                    peek++;
                    Console.WriteLine("Your Points: " + cld[peek - 1].name + " " + cld[peek - 1].suit + " (summa: " + player.kol_player + ")");
                }
                else
                {
                    player.kol_player += 11;
                    bot.num = cld[peek].val;
                    peek++;
                    Console.WriteLine("Your Points: " + cld[peek - 1].name + " " + cld[peek - 1].suit + " (summa: " + player.kol_player + ")");
                }
            }
        }
        public static void this_black_jack(Game play1)
        {
            int play = 0;
            while (play1.player.coins >= 1)
            {
                Console.WriteLine();
                play1.player.kol_player = play1.diller.kol_diller = play1.diller.all_cards_diller = 0;
                play1.player.bid = play1.bot.bid(play1.player.coins, play1.peek, ref play1.player.win);
                if (play1.player.bid >= 1)
                {
                    Console.WriteLine("Bid: {0:.#}", play1.player.bid);
                }
                else
                {
                    Console.WriteLine("Bid: 0{0:.#}", play1.player.bid);
                }
                if (play1.startgame == 1)
                {
                    play1.random_cards();
                }
                play1.startgame = 0;
                play1.give_diller();
                play1.give_player();

                if (play1.player.kol_player > 21)
                {
                    play1.player.coins -= play1.player.bid;
                    Console.WriteLine("diller win");
                    play1.player.win++;
                    play1.Show_coins();
                }
                else
                {
                    if (play1.player.kol_player == 21)
                    {
                        if (play1.diller.cards_for_diller[0].val >= 10)
                        {
                            Console.WriteLine("This push.");
                            if ((play1.bot.num <= 0) && (Math.Abs(play1.bot.num) > 4))
                            {
                                if (play1.diller.cards_for_diller[0].val + play1.diller.cards_for_diller[1].val == 21)
                                {
                                    play1.player.coins -= play1.player.bid;
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("diller win( black jack)");
                                    play1.player.win++;
                                    play1.Show_coins();
                                }
                                else
                                {
                                    play1.player.coins += (0.5 * play1.player.bid);
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("You win( black jack)");
                                    play1.player.win = 0;
                                    play1.Show_coins();
                                }
                            }
                            else
                            {
                                if (play1.diller.cards_for_diller[0].val + play1.diller.cards_for_diller[1].val == 21)
                                {
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("Push");
                                    play1.player.win++;
                                    play1.Show_coins();
                                }
                            }
                        }
                    }
                    else
                    {
                        play1.give_diller();
                        if ((play1.diller.kol_diller > play1.player.kol_player) && (play1.diller.kol_diller <= 21))
                        {
                            play1.player.coins -= play1.player.bid;
                            play1.player.win++;
                            Console.WriteLine("diller win");
                            play1.Show_coins();
                        }
                        else
                        {
                            if (play1.diller.kol_diller != play1.player.kol_player)
                            {
                                play1.player.coins += (0.5 * play1.player.bid);
                                Console.WriteLine("player win");
                                play1.player.win = 0;
                                play1.Show_coins();
                            }
                            else
                            {
                                Console.WriteLine("Both win");
                                play1.player.win++;
                                play1.Show_coins();
                            }
                        }
                    }
                    if (play1.player.coins > 1)
                    {
                        play++;
                        if (play == 10)
                        {
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("No money");
                    }
                }
                if (play1.peek > 156)
                {
                    play1.random_cards();
                    play1.peek = 0;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
    }
}
