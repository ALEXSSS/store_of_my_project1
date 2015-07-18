using System;

namespace Ac
{
    class Program
    {
        static void Main()
        {
            Accessor accessor = new Accessor();
            A a = new A();
            
                Console.Write("Значение : " + accessor.AccessorDelegate<A>("a.b.c.V")(a));
                if (accessor.AccessorDelegate<A>("a.b.c.V")(a) == null) Console.WriteLine("null");
          
            Console.ReadKey();
        }
    }
    class A
    {
        B b;
        public A()
        {
            b = new B(); 
        }
    }
    class B
    {
        C c;
        
        public B()
        {
            c = new C();
        }
    }
    class C
    {
        Object V;
        public C()
        {
            V = 4;
        }
    }
}
