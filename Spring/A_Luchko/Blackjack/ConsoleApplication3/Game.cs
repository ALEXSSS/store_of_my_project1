using System;


namespace Cards
{
    class Game
    {
        player_inf player;
        diller_inf diller;

        //информация о колоде
        byte peek;
        infcard[] cld = new infcard[208];

        //информация о игре
        int startgame = 0;
        
        public Game(int coins)
        {
            this.player.coins = coins;
            peek = 0;
            for (int i = 1; i < 208; i++)
            {
                cld[i - 1] = RecognisingCard.str_to_card(i % 52);
            }
            diller.cards_for_diller = new infcard[17];
            diller.all_cards_diller = 0;
            startgame++;
            player.bid = 0;
            diller.kol_diller = player.kol_player = 0;
            //bool end_iter_forplayer = true;

        }
        void Show_coins()
        {
            Console.Write("Coins: " + player.coins);
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
            }
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
                    FirstIter.first_iter(ref player.bid, player.coins);
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
            peek++;
            Console.Write("Do you want to continue take cards? ");

            while ((String.Compare(Console.ReadLine(), "yes", true) == 0) && (player.kol_player <= 21))
            {
                //Console.Write(" " + cld[peek].name + " " + cld[peek].suit);
                if (((cld[peek].val == 1) && (diller.kol_diller + 11 > 21)) || (cld[peek].val != 1))
                {
                    player.kol_player += cld[peek].val;
                    peek++;
                    Console.WriteLine("Your Points: " + cld[peek - 1].name + " " + cld[peek - 1].suit + " (summa: " + player.kol_player + ")");
                    if (player.kol_player == 21) break;
                }
                else
                {
                    player.kol_player += 11;
                    peek++;
                    Console.WriteLine("Your Points: " + cld[peek - 1].name + " " + cld[peek - 1].suit + " (summa: " + player.kol_player + ")");
                    if (player.kol_player == 21) break;
                }
                if (player.kol_player <= 21) Console.Write("Do you want to continue take cards? ");
            }
        }
        public static void this_black_jack(Game play1)
        {
            Console.WriteLine("Do you play?");
            Console.Write("If true, so write 'yes', else other. ");
            while ((String.Compare(Console.ReadLine(), "Yes", true) == 0) && (play1.player.coins > 0))
            {
                Console.WriteLine();
                play1.player.kol_player = play1.diller.kol_diller = play1.diller.all_cards_diller = 0;
                play1.player.bid = 0;
                if (play1.startgame == 1)
                {
                    play1.random_cards();
                }
                else
                {
                    Console.WriteLine("Hey, we play!");
                }
                play1.startgame = 0;
                play1.give_diller();
                play1.give_player();

                if (play1.player.kol_player > 21)
                {
                    play1.player.coins -= play1.player.bid;
                    Console.WriteLine("diller win");
                    play1.Show_coins();
                    if (play1.player.coins > 0)
                    {
                        Console.WriteLine("Play again?");
                        Console.Write("If true, so write 'yes', else other. ");
                    }
                }
                else
                {
                    if (play1.player.kol_player == 21)
                    {
                        if (play1.diller.cards_for_diller[0].val >= 10)
                        {
                            Console.WriteLine("This push. Do you want to continue?");
                            if (String.Compare(Console.ReadLine(), "yes", true) != 0)
                            {
                                if (play1.diller.cards_for_diller[0].val + play1.diller.cards_for_diller[1].val == 21)
                                {
                                    play1.player.coins -= play1.player.bid;
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("diller win( black jack)");
                                    play1.Show_coins();
                                }
                                else
                                {
                                    play1.player.coins += (int)(0.5 * play1.player.bid);
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("You win( black jack)");
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
                            Console.WriteLine("diller win");
                            play1.Show_coins();
                        }
                        else
                        {
                            if (play1.diller.kol_diller != play1.player.kol_player)
                            {
                                play1.player.coins += (int)(0.5 * play1.player.bid);
                                Console.WriteLine("player win");
                                if (play1.player.bid % 2 == 1) play1.player.coins++;
                                play1.Show_coins();
                            }
                            else
                            {
                                Console.WriteLine("Both win");
                                play1.Show_coins();
                            }
                        }
                    }


                    if (play1.player.coins > 0)
                    {
                        Console.WriteLine("Do you play?");
                        Console.Write("If true, so write 'yes', else other. ");
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
