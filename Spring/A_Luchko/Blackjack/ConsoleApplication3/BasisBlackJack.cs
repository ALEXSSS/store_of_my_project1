using System;

namespace Cards
{
    static class BasisBlackJack
    {
        public static void BlackJack(Game play1)
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
                    play1.RandomCards();
                }
                else
                {
                    Console.WriteLine("Hey, we play!");
                }
                play1.startgame = 0;
                play1.GiveDiller();
                play1.GivePlayer();

                if (play1.player.kol_player > 21)
                {
                    play1.player.coins -= play1.player.bid;
                    Console.WriteLine("diller win");
                    play1.ShowCoins();
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
                                    play1.ShowCoins();
                                }
                                else
                                {
                                    play1.player.coins += (int)(0.5 * play1.player.bid);
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("You win( black jack)");
                                    play1.ShowCoins();
                                }
                            }
                            else
                            {
                                if (play1.diller.cards_for_diller[0].val + play1.diller.cards_for_diller[1].val == 21)
                                {
                                    Console.WriteLine("dealer's cards: " + play1.diller.cards_for_diller[0].suit + play1.diller.cards_for_diller[0].name +
                                                                         play1.diller.cards_for_diller[1].suit + play1.diller.cards_for_diller[1].name);
                                    Console.WriteLine("Push");
                                    play1.ShowCoins();
                                }
                            }
                        }
                    }
                    else
                    {
                        play1.GiveDiller();
                        if ((play1.diller.kol_diller > play1.player.kol_player) && (play1.diller.kol_diller <= 21))
                        {
                            play1.player.coins -= play1.player.bid;
                            Console.WriteLine("diller win");
                            play1.ShowCoins();
                        }
                        else
                        {
                            if (play1.diller.kol_diller != play1.player.kol_player)
                            {
                                play1.player.coins += (int)(0.5 * play1.player.bid);
                                Console.WriteLine("player win");
                                if (play1.player.bid % 2 == 1) play1.player.coins++;
                                play1.ShowCoins();
                            }
                            else
                            {
                                Console.WriteLine("Both win");
                                play1.ShowCoins();
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
                    play1.RandomCards();
                    play1.peek = 0;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
        }
    }
}
