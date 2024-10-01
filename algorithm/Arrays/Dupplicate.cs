using System.Text;

namespace algorithm
{
    public class Dupplicate
    {
        public string FindDuplicate(string str)
        {
            string[] arr = str.Split(" ");
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                // var res = arr.Where(x => x.Equals(arr[i])).Count();
                // if(arr.Where(x => x.Equals(arr[i])).Count() > 2)
                // {
                //     sb.Append(arr[i]);
                // }
                Console.WriteLine(i);
            }
            return sb.ToString();
        }

        public void FindDuplicateWithDictionary(string str)
        {
            string[] words = str.Split(" ");
            Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (wordFrequencies.ContainsKey(word))
                {
                    // Increment the count if the word is already in the dictionary
                    wordFrequencies[word]++;
                }
                else
                {
                    // Add the word to the dictionary with a count of 1
                    wordFrequencies[word] = 1;
                }
            }

            // Print duplicates (words with count > 1)
            foreach (var pair in wordFrequencies)
            {
                if (pair.Value > 1)
                {
                    Console.WriteLine($"Duplicate: {pair.Key} (Count: {pair.Value})");
                }
            }
        }

        public void FindDuplicateWithArray(string str)
        {
            string[] words = str.Split(' ');

            // Sort thethe words for easier comparison
            Array.Sort(words);

            // Initialize variables to keep track of the previous word and its count
            string prevWord = "";
            int count = 1;

            foreach (string word in words)
            {
                if (word == prevWord)
                {
                    // We found a duplicate!
                    count++;
                }
                else
                {
                    // Print the previous word's count if it's greater than 1
                    if (count > 1)
                    {
                        Console.WriteLine($"Duplicate: {prevWord} (Count: {count})");
                    }

                    // Reset count for the new word
                    prevWord = word;
                    count = 1;
                }
            }

            // Don't forget the last word!
            if (count > 1)
            {
                Console.WriteLine($"Duplicate: {prevWord} (Count: {count})");
            }
        }

        public string RemoveDuplicateChars(string key)
        {
            // --- Removes duplicate chars using string concats. ---
            // Store encountered letters in this string.
            string table = "";

            // Store the result in this string.
            string result = "";

            // Loop over each character.
            foreach (char value in key)
            {
                // See if character is in the table.
                if (table.IndexOf(value) == -1)
                {
                    // Append to the table and the result.
                    table += value;
                    result += value;
                }
            }
            return result;
        }
        public void FindDuplicateChars(string word)
        {
            // Initialize a list to store duplicate characters
            List<char> duplicates = new List<char>();

            for (int i = 0; i < word.Length; i++)
            {
                char currentChar = word[i];

                // Check if we've already encountered this character
                if (word.IndexOf(currentChar, i + 1) != -1)
                {
                    // It's a duplicate!
                    if (!duplicates.Contains(currentChar))
                    {
                        duplicates.Add(currentChar);
                    }
                }
            }

            // Print the duplicates
            if (duplicates.Count > 0)
            {
                Console.WriteLine("Duplicate characters found:");
                foreach (char duplicate in duplicates)
                {
                    Console.WriteLine(duplicate);
                }
            }
            else
            {
                Console.WriteLine("No duplicates found. This string is as unique as a rare gem!");
            }
        }
        public void DictionaryTest(string str)
        {
            Dictionary<string, int> wordFrequencies = new Dictionary<string, int>();
            string[] words = str.Split(" ");

            foreach (var word in words)
            {
                if (wordFrequencies.ContainsKey(word))
                {
                    wordFrequencies[word]++;  // Increment the count for the existing word
                }
                else
                {
                    wordFrequencies[word] = 1;  // Add the word with an initial count of 1
                }
            }
            foreach (var key in wordFrequencies)
            {
                Console.WriteLine(key.Key + key.Value);
            }
        }
    }
}