using System;


namespace Cards
{
    //класс, который позволяет только по числу выявить принадлежность карты к данной масти и другую информацию
    //что упрощает замешивание карт
    static class RecognisingCard
    {
       public static infcard str_to_card(int n)
        {
            infcard crd = new infcard();
            switch (n % 13)
            {
                case 0: crd.name = "ace"; break;
                case 1: crd.name = "two"; break;
                case 2: crd.name = "three"; break;
                case 3: crd.name = "four"; break;
                case 4: crd.name = "five"; break;
                case 5: crd.name = "six"; break;
                case 6: crd.name = "seven"; break;
                case 7: crd.name = "eight"; break;
                case 8: crd.name = "nine"; break;
                case 9: crd.name = "ten"; break;
                case 10: crd.name = "jack"; break;
                case 11: crd.name = "queen"; break;
                case 12: crd.name = "king"; break;
            }
            if ((n % 13 + 1) < 10)
            {
                crd.val = n % 13 + 1;
            }
            else
            {
                crd.val = 10;
            }
            switch (n / 13)
            {
                case 0: crd.suit = "chervi"; break;
                case 1: crd.suit = "bubny"; break;
                case 2: crd.suit = "kresti"; break;
                case 3: crd.suit = "piki"; break;
            }
            return crd;
        }
    }
    struct infcard
    {
        public string suit;
        public string name;
        public int val;
    }
}
