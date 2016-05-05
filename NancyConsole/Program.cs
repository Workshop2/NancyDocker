using System;
using Mono.Unix;
using Mono.Unix.Native;
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

                if (Type.GetType("Mono.Runtime") != null)
                {
                    // on mono, processes will usually run as daemons - this allows you to listen
                    // for termination signals (ctrl+c, shutdown, etc) and finalize correctly
                    UnixSignal.WaitAny(new[] {
                        new UnixSignal(Signum.SIGINT),
                        new UnixSignal(Signum.SIGTERM),
                        new UnixSignal(Signum.SIGQUIT),
                        new UnixSignal(Signum.SIGHUP)
                    });
                }
                else
                {
                    Console.ReadLine();
                }

            }

            Console.WriteLine("Closing");
        }
    }
}
