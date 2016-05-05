using System;
using Nancy.Hosting.Self;

namespace NancyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new NancyHost(new Uri("http://localhost:8001")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:8001");
                Console.ReadLine();
            }
        }
    }
}
