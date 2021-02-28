using System;

namespace BecomeNinja
{
    public class Small
    {

    }
    public class Big : Small
    {

    }
    public class Bigger : Big
    {

    }
    public class Covariance
    {
        public delegate Small covarDel(Big mc);
        static Big Method1(Big bg)
        {
            Console.WriteLine("Method1");
            return new Big();
        }
        static Small Method2(Big bg)
        {
            Console.WriteLine("Method2");
            return new Small();
        }

        static Small Method3(Small sml)
        {
            Console.WriteLine("Method3");

            return new Small();
        }
        public Covariance()
        {
            covarDel del = Method1;
            del += Method2;
            del += Method3;

            Small sm = del(new Big());
        }
    }
}