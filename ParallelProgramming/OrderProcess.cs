namespace ParallelProgramming;

public class FoodItem
{
    public string? Name { get; set; }
    
    public string Order(int orderNumber)
    {
        Thread.Sleep(2000); // Simulate work
        Console.WriteLine($"{orderNumber} for {Name}, on thread {Thread.CurrentThread.ManagedThreadId}");
        return Name ?? "problem";
    }
}
public class OrderProcessor
{
    private readonly CountdownEvent _countdown;
    private readonly object _lock = new object();
    private List<string> _results = new List<string>();
    
    public OrderProcessor(int totalOrders)
    {
        _countdown = new CountdownEvent(totalOrders);
    }
    
    public void ProcessOrder(FoodItem food, int orderNumber)
    {
        //The ThreadPool manages and reuses threads efficiently. Here's exactly what it's doing in your food ordering  with QueueUserWorkItem
        ThreadPool.QueueUserWorkItem(_ =>
        {
            string result = food.Order(orderNumber);
            lock (_lock)
            {
                _results.Add($"Order {orderNumber} for {food.Name}: {result}");
            }
            _countdown.Signal();
        });
    }
    
    public void WaitForCompletion()
    {
        _countdown.Wait();
    }
    
    public void DisplayResults()
    {
        lock (_lock)
        {
            foreach (var result in _results)
            {
                Console.WriteLine(result);
            }
        }
    }
}