using System;

namespace BecomeNinja
{
    public class FuncDelegate
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }
        Func<int> getRandomNumber = delegate()
                            {
                                Random rnd = new Random();
                                return rnd.Next(1, 100);
                            };
        public FuncDelegate()
        {
            Func<int, int, int> add = Sum;

            int result = add(10, 10);

            Console.WriteLine(result); 

            int getnumber = getRandomNumber();
            Console.WriteLine(getnumber);
            Func<int> getRandomNumberArrow = () => new Random().Next(1, 100);

            int getnumberArrow = getRandomNumberArrow.Invoke();
            Console.WriteLine(getnumberArrow);


            Func<int, int, int>  SumArrow  = (x, y) => x + y;
            Console.WriteLine(SumArrow(1, 1));
        }
    }
}