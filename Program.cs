using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NetCore_Platzi.Models;
using System;

namespace NetCore_Platzi
{
   public class Program
    {
        public static void Main(string[] args)
        {
            //CreateHostBuilder(args).Build().Run();
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
               var services = scope.ServiceProvider;
               try
               {
                  var context = services.GetRequiredService<EscuelaContext>();
                  context.Database.EnsureCreated();               
               }
               catch (Exception ex)
               {
                  var logger = services.GetRequiredService<ILogger<Program>>();
                  logger.LogError(ex, "Ocurrió un error");
               }
               finally
               {
                  host.Run();
               }
            }                        
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
