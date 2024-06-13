using System;

namespace Location
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Services myLocation = new Services();
            myLocation.GetLocationEvent();
            Console.WriteLine("Enter to exit.");
            Console.ReadLine();
        }
    }
}
