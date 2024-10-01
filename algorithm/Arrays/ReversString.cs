namespace algorithm
{
    public class ReversString
    {
        public string ConvertValue(string str)
        {
            char[] charArray = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                charArray[i] = str[j];
                charArray[j] = str[i];
            }
            string reversedstring = new string(charArray);
            string s1 = string.Join("", charArray);
            string s2 = string.Concat(charArray);
            return s1;
        }
    }
}