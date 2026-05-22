namespace algorithm.Models;

public class BinarySearch
{
    public int[] SearchRange(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return new int[] { -1, -1 };

        int first = FindFirstPosition(nums, target);
        int last = FindLastPosition(nums, target);

        return new int[] { first, last };
    }

    private int FindFirstPosition(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                result = mid;      // پیدا کردیم، ولی ممکنه اولی نباشه
                right = mid - 1;   // به چپ بریم برای پیدا کردن اولین
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }

    private int FindLastPosition(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;
        int result = -1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            if (nums[mid] == target)
            {
                result = mid;      // پیدا کردیم، ولی ممکنه آخری نباشه
                left = mid + 1;    // به راست بریم برای پیدا کردن آخرین
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}