using Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {
            var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddDbContext<MyDbContext>(options
                      => options.UseSqlServer(connectionString));
                })
                .Build();

            host.Run();
        }
    }
}