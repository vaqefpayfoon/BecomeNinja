using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProgramming
{
    public class Lesson1
    {
        public Lesson1()
        {
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello World");
            });
            // wait for input before exiting 
            Console.WriteLine("Main method complete. Press enter to finish.");

        }
    }
}