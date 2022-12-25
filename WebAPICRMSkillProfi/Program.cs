using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            IHost host = CreateHostBuilder(args).Build();
            using (IServiceScope scope = host.Services.CreateScope())
            {
                try
                {
                    await Initializer.InitializerAsync();
                    await InitalizerMainItem.InitializerMainItemAsync();
                }
                catch (Exception)
                {

                }
            }
            host.Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Option.InitLoadTxt();
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                                                     {
                                                         webBuilder.UseStartup<Startup>();
                                                     });
        }

                                                     
    }
}
