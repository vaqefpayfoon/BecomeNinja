using System;

namespace BecomeNinja
{
    public delegate int MathOperation(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {

            //var ubozhi = new ActionsDelegate();

            //var ubobo = new FuncDelegate();

            //new Delegates().del("woak");
            //new Delegates().del2("second woak");

            //var genericDelegate = new GenericDelegate();

            //var obuji = new PredicateDelegate();


            //var ubobobo =  new AnonymousMethod();


            // Events bl = new Events();
            // bl.ProcessCompleted += bl_ProcessCompleted;
            // bl.StartProcess();


            // ProcessBusinessLogic bl2 = new ProcessBusinessLogic();
            // bl2.ProcessCompletedEventHandler += bl_ProcessCompleted2;
            // bl2.StartProcess();

            // ProcessBusinessLogicWithSuccessParam bl3 = new ProcessBusinessLogicWithSuccessParam();
            // bl3.ProcessCompleted += bl_ProcessCompleted3;
            // bl3.StartProcess();

            // ProcessBusinessLogicCustomEvent bl4 = new ProcessBusinessLogicCustomEvent();
            // bl4.ProcessCompleted += bl_ProcessCompleted4;
            // bl4.StartProcess();

            //var woak = new Covariance();
            int i = 10;

            bool result = i.IsGreaterThanVaqefAge(100);

            Console.WriteLine(result);

            MathOperation addDelegate = (a, b) => a + b;
            MathOperation addDelegate2 = Summer;
            MathOperation multiplyDelegate = (a, b) => a * b;

            // Console.WriteLine($"Delegate Add: {addDelegate(5, 3)}");        // 8
            // Console.WriteLine($"Delegate Multiply: {multiplyDelegate(5, 3)}"); // 15
            Console.WriteLine($"Delegate Multiply: {addDelegate2(1, 1)}"); // 15

            // Same behavior with Func
            Func<int, int, int> addFunc = (a, b) => a + b;
            Func<int, int, int> multiplyFunc = (a, b) => a * b;

            // Console.WriteLine($"Func Add: {addFunc(5, 3)}");        // 8
            // Console.WriteLine($"Func Multiply: {multiplyFunc(5, 3)}"); // 15

            new Delegates();
        }
        public static void bl_ProcessCompleted()
        {
            Console.WriteLine("Process Completed!");
        }
        public static void bl_ProcessCompleted2(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!");
        }
        public static void bl_ProcessCompleted3(object sender, bool IsSuccessful)
        {
            Console.WriteLine("Process " + (IsSuccessful ? "Completed Successfully" : "failed"));
        }
        public static void bl_ProcessCompleted4(object sender, ProcessEventArgs e)
        {
            Console.WriteLine("Process " + (e.IsSuccessful ? "Completed Successfully" : "failed"));
            Console.WriteLine("Completion Time: " + e.CompletionTime.ToLongDateString());
        }

        public static int Summer(int a, int b)
        {
            return a + b;
        }
    }
}
