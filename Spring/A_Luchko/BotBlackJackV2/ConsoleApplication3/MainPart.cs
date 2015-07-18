using System;
using Cards;

namespace MainPart
{
    class Program
    {
        static void Main(string[] args)
        {
            int coins=0;
            Exception exc;
            Console.Write("How much money did you get home: ");
            do
            {
               
                    exc = null;
                    coins = int.Parse(Console.ReadLine());
                    //if (coins <= 0) throw exc;
                    Console.WriteLine();
                    Game play = new Game((double)coins);
                    Game.BlackJack(play);

                
            }
            while (exc!=null); 
        }
    }
}
