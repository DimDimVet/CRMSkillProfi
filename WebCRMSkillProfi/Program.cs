using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebCRMSkillProfi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
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
