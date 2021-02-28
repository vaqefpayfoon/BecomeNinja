using System;

namespace BecomeNinja
{
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
    }
}
