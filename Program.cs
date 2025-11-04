using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace TaskTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // 🔧 Ajuste para Replit (ou qualquer ambiente que defina variável de porta)
                    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
                    webBuilder.UseUrls($"http://0.0.0.0:{port}");
                    
                    // Carrega a classe Startup.cs normalmente
                    webBuilder.UseStartup<Startup>();
                });
    }
}
