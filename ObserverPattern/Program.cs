using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //publisher instance creation
            var publisher = new Publisher();

            //subscribers setup
            var observerA = new ObserverA();
            publisher.Subscribe(observerA);
            var observerB = new ObserverB();
            publisher.Subscribe(observerB);
            var observerC = new ObserverC();
            publisher.Subscribe(observerC);
            var observerD = new ObserverD();
            publisher.Subscribe(observerD);
            //publishing the event
            publisher.Publish();

            Console.ReadKey();
        }
    }

    public class Publisher
    {
        private IList<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            this._observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            this._observers.Remove(observer);
        }

        public void Publish()
        {
            foreach (var observer in this._observers)
            {
                observer.Update();
            }
        }
    }

    public interface IObserver
    {
        void Update();
    }

    public class ObserverA : IObserver
    {
        public void Update()
        { 
            Console.WriteLine("Updated recieved by Observer A");
        }
    }
    public class ObserverB : IObserver
    {
        public void Update()
        {
            Console.WriteLine(" Updated recieved by Observer B");
        }
    }
    public class ObserverC : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Updated recieved by Observer C");
        }
    }

    public class ObserverD : IObserver
    {
        public void Update()
        {
            Console.WriteLine("Updated recieved by Observer D");
        }
    }
}
