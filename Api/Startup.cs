using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Contracts;
using Infrastructure.Base;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            #region Heroku
            string _connectionString = Environment.GetEnvironmentVariable("DATABSE_URL");
            _connectionString.Replace("//", "");
            char[] delimiterChars = { '/', ':', '@', '?' };

            string[] strConn = _connectionString.Split(delimiterChars);
            strConn = strConn.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string user = strConn[1];
            string pass = strConn[2];
            string server = strConn[3];
            string database = strConn[5];
            string port = strConn[4];
            string connectionString = "host=" + server + ";port=" + port + ";database=" + database + ";uid=" + user + ";pwd=" + pass + ";sslmode=Require;Trust Server Certificate=true;Timeout=1000";

            #endregion

            services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.IgnoreNullValues = false);

            // services.AddDbContext<KlarensContext>(opt => opt.UseNpgsql("Host=localhost;Database=klarens;Username=postgres;Password=Ramiroe123"));
            services.AddDbContext<KlarensContext>(opt => opt.UseNpgsql(connectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDbContext, KlarensContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Api REST - Klarens",
                    Version = "v1"
                });
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api - Klarens");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
