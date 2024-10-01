// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Xml.XPath;

namespace algorithm
{
    class Program
    {
        delegate void Printer();
        static void Main(string[] args)
        {
            int k = 3; // Example value for k
            int[] sequence = { 1, 2, 3, 0, 2 }; // Example sequence

            int score = CalculateScore(sequence, k);
            Console.WriteLine($"Score of the sequence: {score}");
        }
        static int CalculateScore(int[] sequence, int k)
        {
            int score = 0;
            for (int i = 0; i < sequence.Length - 1; i++)
            {
                if (sequence[i] + sequence[i + 1] == k)
                {
                    score++;
                }
            }
            return score;
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

        internal static int TotalEvenNumbers(int[] nums)
        {
            int cnt = 0;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                if (nums[i] % 2 == 0)
                {
                    cnt += nums[i];
                }
            }
            return nums.Where(i => i % 2 == 0).Count();

            // return cnt;
        }

        internal static long TotalAllEvenNumbers(int[] intArray)
        {
            return intArray.Where(i => i % 2 == 0).Sum(i => (long)i);
        }

        internal static long TotalAllEvenNumbers2(int[] intArray)
        {
            return (from i in intArray where i % 2 == 0 select (long)i).Sum();
        }

        // Method to count occurrences of two-character substrings that are common in both input strings
        internal static int NumberOfPositions(string str1, string str2)
        {
            var ctr = 0; // Counter to track the occurrences of common two-character substrings

            // Iterate through the first string's characters except the last one
            for (var i = 0; i < str1.Length - 1; i++)
            {
                var firstString = str1.Substring(i, 2); // Extract a two-character substring from the first string

                // Iterate through the second string's characters except the last one
                for (var j = 0; j < str2.Length - 1; j++)
                {
                    var secondString = str2.Substring(j, 2); // Extract a two-character substring from the second string

                    // Check if the extracted substrings from both strings are equal
                    if (firstString.Equals(secondString))
                        ctr++; // Increment the counter if the substrings are equal
                }
            }
            return ctr; // Return the total count of common two-character substrings

        }
        static async Task<string> SaySomething()
        {
            await Task.Delay(5);
            return "Hello world!";
        }


    }
    public sealed class Circle
    {
        public double radius;

        public double Calculate(Func<double, double> op)
        {
            return op(radius);
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

    public class TestStatic
    {
        public static int TestValue;
        //first constructor will run and then static constructor will run
        public TestStatic()
        {
            if (TestValue == 0)
            {
                TestValue = 5;
            }
        }
        static TestStatic()
        {
            if (TestValue == 0)
            {
                TestValue = 10;
            }

        }

        public void Print()
        {
            if (TestValue == 5)
            {
                TestValue = 6;
            }
            Console.WriteLine("TestValue : " + TestValue);

        }
    }
}