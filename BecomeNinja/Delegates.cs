using System;

namespace BecomeNinja
{
    public delegate void MyDelegate(string msg);
    public class Delegates
    {

        public MyDelegate del = new MyDelegate(MethodA);
        public MyDelegate del2 = MethodA;
        MyDelegate del3 = (string msg) => Console.WriteLine(msg);
        static void MethodA(string message)
        {
            Console.WriteLine(message);

        }
        public Delegates()
        {

            MyDelegate del = ClassA.MethodA;
            del("Hello World");

            del = ClassB.MethodB;
            del("Hello World");

            del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            del("Hello World");


            MyDelegate del2 = ClassA.MethodA;
            InvokeDelegate(del2);

            del2 = ClassB.MethodB;
            InvokeDelegate(del2);

            del2 = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
            InvokeDelegate(del2);
        }
        static void InvokeDelegate(MyDelegate del)
        {
            del("Hello World");
        }
    }
    public class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
        }
    }

    public class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
        }
    }
    public delegate T add<T>(T param1, T param2);
    public class GenericDelegate
    {
     public GenericDelegate()
    {
        add<int> sum = Sum;
        Console.WriteLine(sum(10, 20));

        add<string> con = Concat;
        Console.WriteLine(Concat("Hello ","World!!"));
    }

    public static int Sum(int val1, int val2)
    {
        return val1 + val2;
    }

    public static string Concat(string str1, string str2)
    {
        return str1 + str2;
    }
    }
}