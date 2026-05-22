namespace algorithm.Models;

public class DuplicatePatterns
{
    public DuplicatePatterns()
    {

    }
    private int[] myList =
    {
        1, 4, 3, 21, 44, 32, 4, 10, 12, 32
    };

    public List<int> FindDuplicates()
    {
        // Create a copy and sort (O(n log n))
        int[] sorted = (int[])myList.Clone();
        Array.Sort(sorted);

        List<int> duplicates = new();

        // Single pass to find duplicates (O(n))
        for (int i = 0; i < sorted.Length - 1; i++)
        {
            if (sorted[i] == sorted[i + 1])
            {
                // Avoid adding duplicate duplicates
                if (duplicates.Count == 0 || duplicates[duplicates.Count - 1] != sorted[i])
                {
                    duplicates.Add(sorted[i]);
                }
            }
        }

        return duplicates;
    }
    public IReadOnlyCollection<int> FindDuplicateHashSet()
    {
        HashSet<int> seen = new();
        List<int> numbers = new();
        foreach (var item in myList)
        {
            if (!seen.Add(item))
            {
                numbers.Add(item);
            }
        }
        return numbers;
    }

    public IReadOnlyCollection<int> FindDuplicateDictionary()
    {
        Dictionary<int, int> seen = new();
        List<int> numbers = new();
        foreach (var item in myList)
        {
            if (!seen.TryAdd(item, item))
            {
                numbers.Add(item);
            }
        }
        return numbers;
    }

    //برنامه‌ای بنویس که یک آرایه از اعداد صحیح دریافت کند و بزرگترین عدد مکرر (عددی که بیشترین تکرار را دارد) را برگرداند.

    public KeyValuePair<int, int> FindMostDuplicateBad() //bad perform but works
    {
        int[] arr = { 3, 1, 4, 1, 5, 3, 2, 3, 5 };
        Dictionary<int, int> clone = new();
        foreach (int i in arr)
        {
            var max = arr.Count(x => x == i);
            clone.TryAdd(i, max);
        }

        var find = clone.ToList().OrderByDescending(x => x.Value).FirstOrDefault();

        return find;
    }
    public int FindMostDuplicate()
    {
        int[] arr = { 3, 1, 4, 1, 5, 3, 2, 3, 5 };

        if (arr == null || arr.Length == 0)
            throw new InvalidOperationException("آرایه خالی است");

        Dictionary<int, int> frequency = new();

        foreach (int num in arr)
        {
            if (frequency.ContainsKey(num))
                frequency[num]++;
            else
                frequency[num] = 1;
        }

        int mostFrequentNum = arr[0];
        int maxCount = 0;

        foreach (var item in frequency)
        {
            if (item.Value > maxCount)
            {
                maxCount = item.Value;
                mostFrequentNum = item.Key;
            }
        }

        return mostFrequentNum;
    }
}