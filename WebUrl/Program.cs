using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using WebUrl;

namespace MyWindowsService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<MyService>();
                });
    }



    public class MyService : IHostedService
    {
        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service starting...");

            foreach (Process process in Process.GetProcessesByName("chrome"))
            {
                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                string url = ServiceListener.GetBrowserUrl(process);
                if (url == null)
                    continue;
                Console.WriteLine($"chrome active tab: {url}");
            }

            foreach (Process process in Process.GetProcessesByName("firefox"))
            {
                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                string url = ServiceListener.GetBrowserUrl(process);
                if (url == null)
                    continue;
                Console.WriteLine($"firefox active tab: {url}");
            }

            foreach (Process process in Process.GetProcessesByName("msedge"))
            {
                if (process.MainWindowHandle == IntPtr.Zero)
                {
                    continue;
                }

                string url = ServiceListener.GetBrowserUrl(process);
                if (url == null)
                    continue;
                Console.WriteLine($"edge active tab: {url}");
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service stopping...");
            return Task.CompletedTask;
        }
    }
}
