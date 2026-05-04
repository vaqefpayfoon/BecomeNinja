// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Xml.XPath;
using algorithm.Models;

namespace algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var duplicate = new DuplicatePatterns().FindDuplicates();
            foreach(var item in duplicate)
                Console.WriteLine(item);
        }
    }
}