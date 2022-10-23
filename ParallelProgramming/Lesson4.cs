using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Lesson4
    {
        public Lesson4()
        {
            string[] messages = { "First task", "Second task",
 "Third task", "Fourth task" };
            foreach (string msg in messages)
            {
                Task myTask = new Task(obj => printMessage((string)obj), msg);
                myTask.Start();
            }
            // wait for input before exiting 
            Console.WriteLine("Main method complete. Press enter to finish.");
            Console.ReadLine();
        }
        static void printMessage(string message)
        {
            Console.WriteLine("Message: {0}", message);
        }
    }
}