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

            services.AddTransient<IUserValidator<User>, CustomUserValidator>();//��������� ���������
            services.AddTransient<IValuesModelRepozitory<User>, ValuesUserRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<Messange>, ValuesMessangeRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<ProjectItem>, ValuesProjectRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<ServiceItem>, ValuesServiceRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<BlogItem>, ValuesBlogRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<ContactItem>, ValuesContactRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<LinkItem>, ValuesLinkRepozitory>();//��������� ����������� � �����
            services.AddTransient<IValuesModelRepozitory<MainItem>, ValuesMainRepozitory>();//��������� ����������� � �����

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.RequireHttpsMetadata = false;
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                            // ��������, ����� �� �������������� �������� ��� ��������� ������
                            ValidateIssuer = true,
                            // ������, �������������� ��������
                            ValidIssuer = Option.ISSUER,
                            // ����� �� �������������� ����������� ������
                            ValidateAudience = true,
                            // ��������� ����������� ������
                            ValidAudience = Option.AUDIENCE,
                            // ����� �� �������������� ����� �������������
                            ValidateLifetime = true,
                            // ��������� ����� ������������
                            IssuerSigningKey = Option.GetSymmetricSecurityKey(),
                            // ��������� ����� ������������
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
