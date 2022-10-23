using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Lesson3
    {
        public Lesson3()
        {
            // use an Action delegate and a named method 
            Task task1 = new Task(new Action<object>(printMessage),
            "First task");
            // use a anonymous delegate 
            Task task2 = new Task(delegate (object obj)
            {
                printMessage(obj);
            }, "Second Task");
            // use a lambda expression and a named method 
            // note that parameters to a lambda don’t need 
            // to be quoted if there is only one parameter 
            Task task3 = new Task((obj) => printMessage(obj), "Third task");
            // use a lambda expression and an anonymous method 
            task1.Start();
            task2.Start();
            task3.Start();
            // wait for input before exiting 
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
        }
        public void printMessage(object message)
        {
            Console.WriteLine("Message: {0}", message);
        }
    }
}