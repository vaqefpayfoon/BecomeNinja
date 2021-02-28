using System;

namespace BecomeNinja
{
    public class AnonymousMethod
    {
        public delegate void Print(int value);
        public void PrintHelperMethod(Print printDel, int val)
        {
            val += 10;
            printDel(val);
        }
        public AnonymousMethod()
        {
            Print print = delegate (int val)
            {
                Console.WriteLine("Inside Anonymous method. Value: {0}", val);
            };

            print(100);

            PrintHelperMethod(delegate (int val) { Console.WriteLine("Anonymous method: {0}", val); }, 100);
        }
    }
}