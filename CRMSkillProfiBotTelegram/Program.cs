using CRMSkillProfiBotTelegram.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CRMSkillProfiBotTelegram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host=CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Option.InitLoadTxt();
            LogicBot.BotStart();
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
                                                                          {
                                                                              webBuilder.UseStartup<Startup>();
                                                                          });
        }

    }
}
