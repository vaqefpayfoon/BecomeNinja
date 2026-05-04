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
}