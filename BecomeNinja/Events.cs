using System;

namespace BecomeNinja
{
    public delegate void Notify();
    public class Events
    {
        public event Notify ProcessCompleted;
        public Events()
        {

        }
        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            OnProcessCompleted();
        }

        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke();
        }
    }
    public class ProcessBusinessLogic
    {
        public event EventHandler ProcessCompletedEventHandler;

        public void StartProcess()
        {
            Console.WriteLine("Process Started!");
            OnProcessCompletedEvent(EventArgs.Empty);
        }

        protected virtual void OnProcessCompletedEvent(EventArgs e)
        {
            ProcessCompletedEventHandler?.Invoke(this, e);
        }
    }
    public class ProcessBusinessLogicWithSuccessParam
    {
        public event EventHandler<bool> ProcessCompleted;

        public void StartProcess()
        {
            try
            {
                Console.WriteLine("Process Started!");

                // some code here..

                OnProcessCompleted(true);
            }
            catch
            {
                OnProcessCompleted(false);
            }
        }

        protected virtual void OnProcessCompleted(bool IsSuccessful)
        {
            ProcessCompleted?.Invoke(this, IsSuccessful);
        }
    }
   public class ProcessEventArgs : EventArgs
{
    public bool IsSuccessful { get; set; }
    public DateTime CompletionTime { get; set; }
}
    public class ProcessBusinessLogicCustomEvent
    {
        // declaring an event using built-in EventHandler
        public event EventHandler<ProcessEventArgs> ProcessCompleted;

        public void StartProcess()
        {
            var data = new ProcessEventArgs();

            try
            {
                Console.WriteLine("Process Started!");

                // some code here..

                data.IsSuccessful = true;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
            catch
            {
                data.IsSuccessful = false;
                data.CompletionTime = DateTime.Now;
                OnProcessCompleted(data);
            }
        }

        protected virtual void OnProcessCompleted(ProcessEventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}