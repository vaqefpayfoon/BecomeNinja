using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelProgramming;
public class ControlledThreadPool
{
    private readonly SemaphoreSlim _semaphore;
    private int _completedCount = 0;
    private int _totalOrders;
    
    public ControlledThreadPool(int maxConcurrency)
    {
        _semaphore = new SemaphoreSlim(maxConcurrency);
    }
    
    public async Task ProcessOrdersAsync(List<(FoodItem food, int orderNumber)> orders)
    {
        _totalOrders = orders.Count;
        var tasks = new List<Task>();
        
        foreach (var order in orders)
        {
            await _semaphore.WaitAsync();
            
            tasks.Add(Task.Run(() =>
            {
                try
                {
                    order.food.Order(order.orderNumber);
                }
                finally
                {
                    _semaphore.Release();
                    int completed = Interlocked.Increment(ref _completedCount);
                    Console.WriteLine($"Progress: {completed}/{_totalOrders} orders completed");
                }
            }));
        }
        
        await Task.WhenAll(tasks);
    }
}