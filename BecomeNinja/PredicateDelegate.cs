using System;

namespace BecomeNinja
{
    public class PredicateDelegate
    {
        public bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public PredicateDelegate()
        {
            Predicate<string> isUpper = IsUpperCase;

            bool result = isUpper("HH");

            Console.WriteLine(result);


            Predicate<string> isUpper2 = delegate(string s) { return s.Equals(s.ToUpper());};
            bool result2 = isUpper("hello world!!");
            Console.WriteLine(result2);

            Predicate<string> isUpper3 = s => s.Equals(s.ToUpper());
            bool result3 = isUpper("W");
            Console.WriteLine(result3);
        }
    }
}