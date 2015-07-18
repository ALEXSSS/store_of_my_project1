using System;


namespace Cards
{

    struct player_inf
    {
        public double coins;
        public int kol_player;
        public  double bid;
        public byte win;
    }

    //информация о диллере
    struct diller_inf
    {
        public int kol_diller;//сумма очков диллера
        public infcard[] cards_for_diller;//его карты
        public int all_cards_diller;//сколько карт у диллера
    }
}

