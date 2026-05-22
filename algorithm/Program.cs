// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Xml.XPath;
using algorithm.Models;

namespace algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // var duplicate = new DuplicatePatterns().FindDuplicates();
            // foreach(var item in duplicate)
            //     Console.WriteLine(item);

            // var mostDuplicate = new DuplicatePatterns().FindMostDuplicate();
            // Console.WriteLine("key: " + mostDuplicate);

            // int[] nums = [1, 2, 3];
            // var backtrack = new BackTrack();
            // var subsets = backtrack.Subsets(nums);
            // Console.Write("[");
            // for (int i = 0; i < subsets.Count; i++)
            // {
            //     Console.Write("[");
            //     Console.Write(string.Join(",", subsets[i]));
            //     Console.Write("]");

            //     if (i < subsets.Count - 1)
            //         Console.Write(", ");
            // }
            // Console.WriteLine("]");

            // var binarySearch = new BinarySearch();
            // int[] nums1 = { 5, 7, 7, 8, 8, 10 };
            // int target1 = 8;
            // int[] result1 = binarySearch.SearchRange(nums1, target1);
            // Console.WriteLine($"nums = [{string.Join(",", nums1)}], target = {target1}");
            // Console.WriteLine($"خروجی: [{result1[0]}, {result1[1]}]\n");


            var teams = new List<Team>
            {
                new Team("برزیل", 1, "آمریکای جنوبی"),
                new Team("آلمان", 2, "اروپا"),
                new Team("آرژانتین", 3, "آمریکای جنوبی"),
                new Team("فرانسه", 4, "اروپا"),
                new Team("انگلیس", 5, "اروپا"),
                new Team("اسپانیا", 6, "اروپا"),
                new Team("هلند", 7, "اروپا"),
                new Team("پرتغال", 8, "اروپا")
            };

            Console.WriteLine("تیم‌های حاضر در جام جهانی:");
            Console.WriteLine("-".Repeat(40));
            foreach (var team in teams.OrderBy(t => t.Rank))
            {
                Console.WriteLine($"{team}");
            }
            Console.WriteLine();

            var draw = new WorldCupDraw(teams);
            draw.FindBestDraw();
        }
    }
}