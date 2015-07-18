using System;
//using System.Management;
namespace WindowsFormsApplication1
{
    static class Function
    {
        static public float Fsin(int i)
        {
            return (float)Math.Sin((double)i / (double)50) * (-50);
        }
        static public float Fcos(int i)
        {
            return (float)Math.Cos((double)i / (double)50) * (-50);
        }
        static public float Fexp(int i)
        {
            return (float)Math.Exp((double)i / (double)50) * (-50);
        }
        static public float Fx2(int i)
        {
            return (float)(((double)i / (double)50) * ((double)i / (double)50)) * (-50);
        }
        static public float Fx3(int i)
        {
            return (float)(((double)i / (double)50) * ((double)i / (double)50) * ((double)i / (double)50)) * (-50);
        }
    }
}
