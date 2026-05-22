namespace algorithm.Models;

public class Team
{
    public string Name { get; set; }
    public int Rank { get; set; }
    public string Continent { get; set; }
    
    public Team(string name, int rank, string continent)
    {
        Name = name;
        Rank = rank;
        Continent = continent;
    }
    
    public override string ToString()
    {
        return $"{Name} (رنکینگ: {Rank}, {Continent})";
    }
}

public class WorldCupDraw
{
    private List<Team> _teams;
    private List<Team> _groupA;
    private List<Team> _groupB;
    private int _minDifference;
    private List<Team> _bestGroupA;
    
    public WorldCupDraw(List<Team> teams)
    {
        _teams = teams;
        _groupA = new List<Team>();
        _groupB = new List<Team>();
        _minDifference = int.MaxValue;
        _bestGroupA = new List<Team>();
    }
    
    public void FindBestDraw()
    {
        Backtrack(0);
        PrintResult();
    }
    
    private void Backtrack(int index)
    {
        // شرط پایان: همه تیم‌ها تقسیم شدند
        if (index == _teams.Count)
        {
            // بررسی اعتبار گروه‌ها
            if (IsValidGroups())
            {
                int sumA = _groupA.Sum(t => t.Rank);
                int sumB = _groupB.Sum(t => t.Rank);
                int difference = Math.Abs(sumA - sumB);
                
                if (difference < _minDifference)
                {
                    _minDifference = difference;
                    _bestGroupA = new List<Team>(_groupA);
                }
            }
            return;
        }
        
        // اضافه کردن تیم فعلی به گروه A
        if (_groupA.Count < 4)
        {
            _groupA.Add(_teams[index]);
            Backtrack(index + 1);
            _groupA.RemoveAt(_groupA.Count - 1);
        }
        
        // اضافه کردن تیم فعلی به گروه B
        if (_groupB.Count < 4)
        {
            _groupB.Add(_teams[index]);
            Backtrack(index + 1);
            _groupB.RemoveAt(_groupB.Count - 1);
        }
    }
    
    private bool IsValidGroups()
    {
        return IsValidGroup(_groupA) && IsValidGroup(_groupB);
    }
    
    private bool IsValidGroup(List<Team> group)
    {
        // قانون 1: هر گروه دقیقاً 4 تیم دارد
        if (group.Count != 4)
            return false;
        
        // قانون 2: حداکثر 2 تیم از یک قاره
        var continentCount = group.GroupBy(t => t.Continent)
                                  .ToDictionary(g => g.Key, g => g.Count());
        
        foreach (var count in continentCount.Values)
        {
            if (count > 2)
                return false;
        }
        
        return true;
    }
    
    private void PrintResult()
    {
        var groupB = _teams.Except(_bestGroupA).ToList();
        
        int sumA = _bestGroupA.Sum(t => t.Rank);
        int sumB = groupB.Sum(t => t.Rank);
        
        Console.WriteLine("=".Repeat(50));
        Console.WriteLine("بهترین گروه‌بندی جام جهانی:");
        Console.WriteLine("=".Repeat(50));
        
        Console.WriteLine("\nگروه A:");
        Console.WriteLine("-".Repeat(30));
        foreach (var team in _bestGroupA.OrderBy(t => t.Rank))
        {
            Console.WriteLine($"  {team}");
        }
        Console.WriteLine($"مجموع رنکینگ: {sumA}");
        
        Console.WriteLine("\nگروه B:");
        Console.WriteLine("-".Repeat(30));
        foreach (var team in groupB.OrderBy(t => t.Rank))
        {
            Console.WriteLine($"  {team}");
        }
        Console.WriteLine($"مجموع رنکینگ: {sumB}");
        
        Console.WriteLine($"\n✅ اختلاف مجموع رنکینگ: {Math.Abs(sumA - sumB)}");
        Console.WriteLine("=".Repeat(50));
    }
}

// اکستنشن برای تکرار رشته
public static class StringExtensions
{
    public static string Repeat(this string str, int count)
    {
        return string.Concat(Enumerable.Repeat(str, count));
    }
}