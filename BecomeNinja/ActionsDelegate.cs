using System;

namespace BecomeNinja
{
    public class ActionsDelegate
    {
        public delegate void Print(int val);
        Action<int> printActionDel = delegate(int i)
        {
            Console.WriteLine(i);
        };
        static void ConsolePrint(int i)
        {
            Console.WriteLine(i);
        }
        public ActionsDelegate()
        {
            printActionDel(22);

            Print prnt = ConsolePrint;
            prnt(10);

            Action<int> printAction = ConsolePrint;
            printAction(0);

            Action<int> printActionArrow = i => Console.WriteLine(i);
       
            printActionArrow(71);
        }
    }
}