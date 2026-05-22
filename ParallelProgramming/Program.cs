using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var turkey = new Turkey();
            var mashPotatoes = new MashPotatoes();
            var gravy = new Gravy();
            var stuffing = new Stuffing();

            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            Console.WriteLine("cooking does starting");
            try
            {
                //     await Task.WhenAll(
                //     turkey.Cook(cancellationTokenSource.Token),
                //     gravy.Cook(cancellationTokenSource.Token),
                //     mashPotatoes.Cook(cancellationTokenSource.Token),
                //     stuffing.Cook(cancellationTokenSource.Token)
                // ); or u can do this

                // await Task.WhenAll(
                //     turkey.Cook(),
                //     gravy.Cook(),
                //     mashPotatoes.Cook(),
                //     stuffing.Cook()
                // ).WaitAsync(cancellationTokenSource.Token);

                // Console.WriteLine("dinner is ready");

                // List<Task<string>> cookingTaskList =
                // [
                //     turkey.Cook(),
                //     gravy.Cook(),
                //     mashPotatoes.Cook(),
                //     stuffing.Cook()
                // ];

                //when any of the task are ready returns a result

                // while(cookingTaskList.Count is not 0)
                // {
                //     var completed = await Task.WhenAny(cookingTaskList).WaitAsync(cancellationTokenSource.Token);
                //     cookingTaskList.Remove(completed);

                //     var name = await completed;
                //     Console.WriteLine(name);
                // }


                // await foreach(Task<string> completedCookingTask in Task.WhenEach(cookingTaskList))
                // {
                //     cookingTaskList.Remove(completedCookingTask);
                //     var name = await completedCookingTask;
                //     Console.WriteLine(name);
                // }

                var option = new ParallelOptions
                {
                    MaxDegreeOfParallelism = 30,
                    CancellationToken = cancellationTokenSource.Token
                };

                Parallel.Invoke(option, async () => await turkey.Cook(), async () => await mashPotatoes.Cook(), async () => await gravy.Cook(), async () => await stuffing.Cook());

                // BLOCKS here until ALL tasks finish
                Task.WaitAll(turkey.Cook(), mashPotatoes.Cook(), gravy.Cook(), stuffing.Cook());

                int numberOfOrderTurkey = 10;
                int numberOfOrderMashPotato = 50;
                int numberOfOrderGravy = 50;
                int numberOfOrderStuffing = 20;

                Parallel.For(1, numberOfOrderTurkey, option, (int orderNumber) => turkey.Order(orderNumber));
                Parallel.For(1, numberOfOrderMashPotato, option, (int orderNumber) => mashPotatoes.Order(orderNumber));
                Parallel.For(1, numberOfOrderGravy, option, (int orderNumber) => gravy.Order(orderNumber));
                Parallel.For(1, numberOfOrderStuffing, option, (int orderNumber) => stuffing.Order(orderNumber));


                await Parallel.ForEachAsync(Enumerable.Range(1, numberOfOrderTurkey), option, async (orderNumber, token) => await turkey.OrderAsync(orderNumber));

                await Parallel.ForEachAsync(Enumerable.Range(1, numberOfOrderMashPotato), option, async (orderNumber, token) => await mashPotatoes.OrderAsync(orderNumber));

                await Parallel.ForEachAsync(Enumerable.Range(1, numberOfOrderGravy), option, async (orderNumber, token) => await gravy.OrderAsync(orderNumber));

                await Parallel.ForEachAsync(Enumerable.Range(1, numberOfOrderStuffing), option, async (orderNumber, token) => await stuffing.OrderAsync(orderNumber));


                //         using (var countdown = new CountdownEvent(
                //    numberOfOrderTurkey + numberOfOrderMashPotato + numberOfOrderGravy + numberOfOrderStuffing))
                //         {
                //             Console.WriteLine("Starting orders with ThreadPool...");

                //             // Queue Turkey orders
                //             for (int i = 1; i <= numberOfOrderTurkey; i++)
                //             {
                //                 int orderNum = i;
                //                 ThreadPool.QueueUserWorkItem(_ =>
                //                 {
                //                     turkey.Order(orderNum);
                //                     countdown.Signal();
                //                 });
                //             }

                //             // Queue Mash Potato orders
                //             for (int i = 1; i <= numberOfOrderMashPotato; i++)
                //             {
                //                 int orderNum = i;
                //                 ThreadPool.QueueUserWorkItem(_ =>
                //                 {
                //                     mashPotatoes.Order(orderNum);
                //                     countdown.Signal();
                //                 });
                //             }

                //             // Queue Gravy orders
                //             for (int i = 1; i <= numberOfOrderGravy; i++)
                //             {
                //                 int orderNum = i;
                //                 ThreadPool.QueueUserWorkItem(_ =>
                //                 {
                //                     gravy.Order(orderNum);
                //                     countdown.Signal();
                //                 });
                //             }

                //             // Queue Stuffing orders
                //             for (int i = 1; i <= numberOfOrderStuffing; i++)
                //             {
                //                 int orderNum = i;
                //                 ThreadPool.QueueUserWorkItem(_ =>
                //                 {
                //                     stuffing.Order(orderNum);
                //                     countdown.Signal();
                //                 });
                //             }

                //             // Wait for all orders to complete
                //             countdown.Wait();
                //             Console.WriteLine("\nAll orders completed!");
                //         }


                var turkeyItem = new FoodItem { Name = "Turkey" };
                var mashPotatoesItem = new FoodItem { Name = "MashPotato" };
                var gravyItem = new FoodItem { Name = "Gravy" };
                var stuffingItem = new FoodItem { Name = "Stuffing" };

                var allOrders = new List<(FoodItem, int)>();

                for (int i = 1; i <= numberOfOrderTurkey; i++)
                    allOrders.Add((turkeyItem, i));

                for (int i = 1; i <= numberOfOrderMashPotato; i++)
                    allOrders.Add((mashPotatoesItem, i));

                for (int i = 1; i <= numberOfOrderGravy; i++)
                    allOrders.Add((gravyItem, i));

                for (int i = 1; i <= numberOfOrderStuffing; i++)
                    allOrders.Add((stuffingItem, i));

                var processor = new ControlledThreadPool(maxConcurrency: 10);

                Console.WriteLine($"Starting {allOrders.Count} orders with controlled concurrency...");
                await processor.ProcessOrdersAsync(allOrders);

                Console.WriteLine("\nAll orders completed!");

            }
            catch
            {
                Console.WriteLine("cooking takes too mutch time");
            }
        }
    }
}