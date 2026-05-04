using System.Diagnostics;

namespace ParallelProgramming;

public abstract class Food
{
    readonly TimeSpan _cooktime;
    public string? Name { get; }
    protected Food(TimeSpan cookTime)
    {
        _cooktime = cookTime;
        Name = GetType().Name;
    }

    public async Task<string> Cook(CancellationToken token = default)
    {
        Console.WriteLine(Name);
        await Task.Delay(_cooktime, token);
        Console.WriteLine($"{Name}, Completed");
        return Name ?? "problem";
    }

    public string Order(int orderNumber)
    {
        Thread.Sleep(TimeSpan.FromSeconds(2));
        Console.WriteLine($"{orderNumber} for {Name}, on thread {Environment.CurrentManagedThreadId}");
        return Name ?? "problem";
    }

    public async Task<string> OrderAsync(int orderNumber, CancellationToken token = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(2));
        Console.WriteLine($"{orderNumber} for {Name}, on thread {Environment.CurrentManagedThreadId}");
        return Name ?? "problem";
    }
}

public class Turkey(): Food(TimeSpan.FromSeconds(5));
public class MashPotatoes(): Food(TimeSpan.FromSeconds(2));
public class Gravy(): Food(TimeSpan.FromSeconds(1));
public class Stuffing(): Food(TimeSpan.FromSeconds(2));