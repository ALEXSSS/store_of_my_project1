using System;


namespace Cards
{
    static class FirstIter
    {
        public static void first_iter(ref int bid,int coins)
        {
            Exception exc;
            do
            {
                try
                {
                    exc = null;
                    bid = 0;
                    while ((bid > coins) | (bid == 0))
                    {
                        Console.Write("Enter bid: ");
                        bid = int.Parse(Console.ReadLine());
                        if (bid > coins)
                        {
                            Console.WriteLine("You do not bring much money.");
                        }
                    }
                }
                catch (Exception ExcParse)
                {
                    exc = ExcParse;
                }
            }
            while (exc != null);
        }
    }
}
