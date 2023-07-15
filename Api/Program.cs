using Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiIsolated
{
    public class Program
    {
        public static void Main()
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PtSLManager_db-2023-7-13;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

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