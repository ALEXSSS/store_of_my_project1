using System;


namespace ChatLocal
{
    static class KeyControl
    {
       public static string KeyLook(string msg)
        {
            int c = 0;
            c = msg.IndexOf(" ");
            c = msg.IndexOf(" ", c + 1);
            c = msg.IndexOf(" ", c + 1);
            return msg.Substring(0, c);
        }
    }
}
