using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using static Advanced.DelegateEvent;

namespace Advanced
{
    class Program
    {
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null) PriceChanged(this, e);
        }

        static void Main(string[] args)
        {
            DelegateEvent stock = new DelegateEvent("THPW");
            stock.Price = 27.10M;
            // Register with the PriceChanged event
            stock.PriceChanged += stock_PriceChanged;
            stock.Price = 37.59M;
            // new ProgressDelegate().Consumer();
            // ObservableCollection<Person> people = new ObservableCollection<Person>()
            // {
            //     new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
            //     new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            // };
            // // Wire up the CollectionChanged event.
            // people.CollectionChanged += people_CollectionChanged;
            // people.Add(new Person { FirstName = "Kevin", LastName = "Key", Age = 48 });


            // // Point using double.
            // Point<double> p2 = new Point<double>(5.4, 3.3);
            // Console.WriteLine("p2.ToString()={0}", p2.ToString());
            // p2.ResetPoint();
            // Console.WriteLine("p2.ToString()={0}", p2.ToString());
            // Console.WriteLine();
            // // Point using strings.
            // Point<string> p3 = new Point<string>("i", "3i");
            // Console.WriteLine("p3.ToString()={0}", p3.ToString());
            // p3.ResetPoint();
            // Console.WriteLine("p3.ToString()={0}", p3.ToString());
            // Console.ReadLine();
        }
        static void stock_PriceChanged(object sender, PriceChangedEventArgs e)
        {
            if ((e.NewPrice - e.LastPrice) / e.LastPrice > 0.1M)
                Console.WriteLine("Alert, 10% stock price increase!");
        }

        static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("changed");
        }
    }
}