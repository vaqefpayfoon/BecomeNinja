using System;
using System.Collections.Generic;
using System.Linq;

namespace BecomeNinja
{
    public class FuncDelegate
    {
        static int Sum(int x, int y)
        {
            return x + y;
        }
        Func<int> getRandomNumber = delegate ()
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


            Func<int, int, int> SumArrow = (x, y) => x + y;
            Console.WriteLine(SumArrow(1, 1));


            Func<string, string> selector = str => str.ToUpper();
            string[] words = { "orange", "apple", "Article", "elephant" };
            // Query the array and select strings according to the selector method.
            IEnumerable<String> aWords = words.Select(selector);

            // Output the results to the console.
            foreach (String word in aWords)
                Console.WriteLine(word);


            Func<string, string> convert = delegate (string s)
            { return s.ToUpper(); };

            string name = "Dakota";
            Console.WriteLine(convert(name));


            Func<string, string> convert2 = s => s.ToUpper();

            string name2 = "Dakota";
            Console.WriteLine(convert2(name2));
        }

    }
}