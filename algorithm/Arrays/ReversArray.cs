using System.Text;

namespace algorithm
{
    public class ReversArray
    {
        public string ReverseWordOrder(string wordOrder)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = wordOrder.Split(" ");
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i] is not null)
                {
                    sb.Append(words[i]);
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
        public string ReverseWords(string wordOrder)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = wordOrder.Split(" ");
            for (int i = 0; i <= words.Length - 1; i++)
            {
                string str = words[i];
                if (str is not null)
                {
                    char[] charArray = str.ToCharArray();
                    for (int i2 = 0, j = str.Length - 1; i2 < j; i2++, j--)
                    {
                        charArray[i2] = str[j];
                        charArray[j] = str[i2];
                    }
                    string result = string.Join("", charArray);
                    sb.Append(result);
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }
    }
}