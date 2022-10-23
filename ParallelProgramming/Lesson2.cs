using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Lesson2
    {
        public Lesson2()
        {
            // use an Action delegate and a named method 
            Task task1 = new Task(new Action(printMessage));
            // use a anonymous delegate 
            Task task2 = new Task(delegate
            {
                printMessage();
            });
            // use a lambda expression and a named method 
            Task task3 = new Task(() => printMessage());
            task1.Start();
            task2.Start();
            task3.Start();
            // wait for input before exiting 
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
            void printMessage()
            {
                Console.WriteLine("Hello World");
            }
        }
    }
}