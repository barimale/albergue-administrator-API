using Albergue.Administrator.HostedServices;
using Albergue.Administrator.Repository;
using Albergue.Administrator.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Linq;

namespace Albergue.Administrator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileUploader, FileUploader>();
            services.AddScoped<ILocalesGenerator, LocalesGenerator>();
            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddDbContext<AdministrationConsoleDbContext>(options =>
                options
                    .UseSqlite(Configuration.GetConnectionString("AdministrationConsoleDbContext"),
                b => b.MigrationsAssembly(typeof(AdministrationConsoleDbContext).Assembly.FullName)));
            //SuppressForeignKeyEnforcement
            //});
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AdministrationConsoleDbContext>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Albergue.Administrator", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddHostedService<LocalesHostedService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdministrationConsoleDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdministrationConsoleDbContext v1"));
            }

            app.UseRouting();
            //app.UseHsts();

            app.UseCors(p =>
                p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
            );

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
