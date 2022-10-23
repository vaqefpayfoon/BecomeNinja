using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace Advanced
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Person> people = new ObservableCollection<Person>()
            {
                new Person{ FirstName = "Peter", LastName = "Murphy", Age = 52 },
                new Person{ FirstName = "Kevin", LastName = "Key", Age = 48 },
            };
            // Wire up the CollectionChanged event.
            people.CollectionChanged += people_CollectionChanged;
            people.Add(new Person { FirstName = "Kevin", LastName = "Key", Age = 48 });


            // Point using double.
            Point<double> p2 = new Point<double>(5.4, 3.3);
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            p2.ResetPoint();
            Console.WriteLine("p2.ToString()={0}", p2.ToString());
            Console.WriteLine();
            // Point using strings.
            Point<string> p3 = new Point<string>("i", "3i");
            Console.WriteLine("p3.ToString()={0}", p3.ToString());
            p3.ResetPoint();
            Console.WriteLine("p3.ToString()={0}", p3.ToString());
            Console.ReadLine();
        }
        static void people_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("changed");
        }
    }
}