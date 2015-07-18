using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    static class BotControl
    {
        public static bool take_cards(int num, int kol_player)
        {
            if ((num > 8) && (kol_player <= 12))
            {
                return true;
            }
            else
            {
                if ((num > 6) && (kol_player <= 13))
                {
                    return true;
                }
                else
                {
                    if ((num > 5) && (kol_player <= 13))
                    {
                        return true;
                    }
                    else
                    {
                        if ((num > 4) && (kol_player <= 14))
                        {
                            return true;
                        }
                        else
                        {
                            if ((num >= 3) && (kol_player <= 15))
                            {
                                return true;
                            }
                            else
                            {
                                if ((num >= 0) && (kol_player <= 16))
                                {
                                    return true;
                                }
                                else
                                {
                                    if((Math.Abs(num)<4) && (num <= 0) && (kol_player <= 17))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        if ((num <= 0) && (Math.Abs(num) > 4) && (kol_player <= 19))
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                        return false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}