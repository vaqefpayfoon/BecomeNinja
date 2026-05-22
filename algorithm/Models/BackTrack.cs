namespace algorithm.Models;

public class BackTrack
{
    //الگوریتم متفاوت - Backtracking):
    // یک تابع بنویس که همه‌ی زیرمجموعه‌های یک آرایه از اعداد صحیح متمایز (بدون تکرار) را برگرداند.
    // مثال:
    // ورودی: nums = [1, 2, 3]
    // خروجی: [[], [1], [2], [3], [1,2], [1,3], [2,3], [1,2,3]]

    List<(int, int)> clone = new(); // or List<(int First, int Second)> clone = new();
        // clone.Add((nums[i], nums[i + 1]));
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        Backtrack(result, new List<int>(), nums, 0);
        return result;
    }
    
    private static void Backtrack(IList<IList<int>> result, List<int> current, int[] nums, int start)
    {
        // اضافه کردن زیرمجموعه فعلی
        result.Add(new List<int>(current));
        
        for (int i = start; i < nums.Length; i++)
        {
            current.Add(nums[i]);
            Backtrack(result, current, nums, i + 1);
            current.RemoveAt(current.Count - 1);
        }
    }

}