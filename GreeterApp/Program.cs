using System;

namespace GreeterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name :");
            var greeter = new Greeter(new DateTimeService());
            var userName = Console.ReadLine();
            var greetMsg = greeter.Greet(userName);
            Console.WriteLine(greetMsg);
            Console.ReadKey();
        }
    }

    public interface IDateTimeService
    {
        DateTime GetCurrentTime();
    }
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }

    public class Greeter
    {
        private IDateTimeService _dateTimeService;

        public Greeter(IDateTimeService dateTimeService)
        {
            this._dateTimeService = dateTimeService;
        }

        public string Greet(string userName)
        {
            

            if (this._dateTimeService.GetCurrentTime().Hour < 12)
            {
                return string.Format("Hi {0}, Good Morning!", userName);
            } else
            {
                return string.Format("Hi {0}, Have a Good Day!", userName);
            }
        }
    }


}
