using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    //Класс не меняет основную структуру программы BlackJack, о просто делает ставку за игрока, исходя из своих данных
    class BotForBlackJack
    {
        int mnum;
        public int _cards;
        public BotForBlackJack(int cards)
        {
            _cards = cards;
            mnum = 0;
        }
        public int num
        {
            get
            {
                return mnum;
            }
            set
            {
                if (value == 10)
                {
                    mnum--;
                }
                else
                {
                    if (value <= 6)
                    {
                        if (value == 0)
                        {
                            mnum = 0;
                        }
                        else
                        {
                            mnum++;
                        }
                    }
                }
            }
        }
        public double bid(double coins, byte peek, ref byte win)
        {
            Exception ex;
            try
            {
                ex = null;
                _cards = 208 - peek;
                if ((win > 14) || ((0.005 * coins * 2 * (win + 1)) * (1 + 0.005 * mnum) > coins)) throw ex;
                return (0.005 * coins * 2*(win + 1)) * (1 + 0.001 * mnum);
            }
            catch (Exception)
            {
                win = 0;
                return (0.005 * coins) * (1 + 0.001 * mnum);
            }
        }
    }
}
