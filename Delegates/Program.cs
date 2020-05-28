using System;

namespace Delegates
{
    class Program
    {
        public delegate void ParentEventHandler();
        static void Main(string[] args)
        {
            ParentEventHandler s = ShowName;
            s(); // s.Invoke()

            var child = new Child();
            child.MyEvent += Child_MyEvent;
            child.MyEvent += () => Console.WriteLine("I'm also subscribed at " + DateTime.Now.ToString());
            child.Counter();
        }


        /// <summary>
        /// this method subscribed to child event 
        /// </summary>
        private static void Child_MyEvent()
        {
            Console.WriteLine("executed at "+ DateTime.Now.ToString());
        }

        public static void ShowName()
        {
            Console.WriteLine("Sachith Sujeewa at:"+DateTime.Now.ToString());
        }

        
    }

    public class Child
    {
        public delegate void EventHandler();

        public event EventHandler MyEvent;
        public void Counter()
        {
            var mseconds = new Random().Next(3, 10) * 1000;
            System.Threading.Thread.Sleep(mseconds);
            MyEvent();

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(i);
            //    if (i == 5)
            //    {
            //        MyEvent();
            //        break;
            //    }
            //}
        }
    }
}
