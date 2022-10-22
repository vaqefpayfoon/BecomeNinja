// See https://aka.ms/new-console-template for more information
using System.Text;

namespace algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // ReverseString("Vaqef Payfoon");
            // chkPalindrome("VaaV");
            ReverseWordOrder("Yaka Vaqef omade khosro");
            ReverseWords("Yaka Vaqef omade khosro");
        }
        //How to reverse a string?
        internal static void ReverseString(string str)
        {

            char[] charArray = str.ToCharArray();
            Console.WriteLine(charArray);
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedstring = new string(charArray);
            string s1 = string.Join("", charArray);
            string s2 = string.Concat(charArray);
            Console.WriteLine(s2);
        }
        //How to find if the given string is a palindrome or not?
        internal static void chkPalindrome(string str)
        {
            bool flag = false;
            for (int i = 0, j = str.Length - 1; i < str.Length / 2; i++, j--)
            {
                if (str[i] != str[j])
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }
            if (flag)
                Console.WriteLine("Palindrome");
            else
                Console.WriteLine("Not Palindrome");
        }
        //How to reverse the order of words in a given string
        internal static void ReverseWordOrder(string str)
        {
            int i;
            StringBuilder reverseSentence = new StringBuilder();

            int Start = str.Length - 1;
            int End = str.Length - 1;
            while (Start > 0)
            {
                if (str[Start] == ' ')
                {
                    i = Start + 1;
                    while (i <= End)
                    {
                        reverseSentence.Append(str[i]);
                        i++;
                    }
                    reverseSentence.Append(' ');
                    End = Start - 1;
                }
                Start--;
            }

            for (i = 0; i <= End; i++)
            {
                reverseSentence.Append(str[i]);
            }
            Console.WriteLine(reverseSentence.ToString());
        }
        //How to reverse each word in a given string
        internal static void ReverseWords(string str)
        {
            StringBuilder output = new StringBuilder();
            List<char> charlist = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ' || i == str.Length - 1)
                {
                    if (i == str.Length - 1)
                        charlist.Add(str[i]);
                    Console.WriteLine(charlist);
                    for (int j = charlist.Count - 1; j >= 0; j--)
                        output.Append(charlist[j]);

                    output.Append(' ');
                    charlist = new List<char>();
                }
                else
                    charlist.Add(str[i]);
            }
            Console.WriteLine(output.ToString());
        }
    }
    public abstract class Car
    {
        public abstract void Engine();
        public virtual void Dashboard()
        {

        }
    }
    public class SportCar : Car
    {
        public override void Engine()
        {
            throw new NotImplementedException();
        }
        public override void Dashboard()
        {
            base.Dashboard();
        }
    }
}