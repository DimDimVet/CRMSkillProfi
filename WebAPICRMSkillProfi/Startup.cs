using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebAPICRMSkillProfi.Data;
using WebAPICRMSkillProfi.Interface;
using WebAPICRMSkillProfi.Models;

namespace WebAPICRMSkillProfi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbSqlContext>();

            services.AddTransient<IUserValidator<User>, CustomUserValidator>();//кастомный валидатор
            services.AddTransient<IValuesModelRepozitory<User>, ValuesUserRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<Messange>, ValuesMessangeRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<ProjectItem>, ValuesProjectRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<ServiceItem>, ValuesServiceRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<BlogItem>, ValuesBlogRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<ContactItem>, ValuesContactRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<LinkItem>, ValuesLinkRepozitory>();//Добавляем подключение с базой
            services.AddTransient<IValuesModelRepozitory<MainItem>, ValuesMainRepozitory>();//Добавляем подключение с базой

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                            // укзывает, будет ли валидироваться издатель при валидации токена
                            ValidateIssuer = true,
                            // строка, представляющая издателя
                            ValidIssuer = Option.ISSUER,
                            // будет ли валидироваться потребитель токена
                            ValidateAudience = true,
                            // установка потребителя токена
                            ValidAudience = Option.AUDIENCE,
                            // будет ли валидироваться время существования
                            ValidateLifetime = true,
                            // установка ключа безопасности
                            IssuerSigningKey = Option.GetSymmetricSecurityKey(),
                            // валидация ключа безопасности
                            ValidateIssuerSigningKey = true,
                       };
                   });
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
