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
                try
                {
                    exc = null;
                    coins = int.Parse(Console.ReadLine());
                    if (coins <= 0) throw exc;
                    Console.WriteLine();
                    Game play = new Game(coins);
                    Game.this_black_jack(play);
                }
                catch(Exception EXCParse)
                {
                    exc = EXCParse;
                    Console.WriteLine("Repeat please!");
                    Console.WriteLine();
                    Console.Write("How much money did you get home: ");
                }
            }
            while (exc!=null); 
        }
    }
}
