using Albergue.Administrator.HostedServices;
using Albergue.Administrator.Repository;
using Albergue.Administrator.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            services.AddScoped<IAuthorizeService, AuthorizeService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddCors();

            services.AddDbContext<AdministrationConsoleDbContext>(options =>
                options
                    .UseSqlite(Configuration.GetConnectionString("AdministrationConsoleDbContext"),
                b => b.MigrationsAssembly(typeof(AdministrationConsoleDbContext).Assembly.FullName)));

            //services.AddDbContext<AdministrationConsoleDbContext>(options =>
            //    options
            //        .UseSqlServer(Configuration.GetConnectionString("MSSQLAdministrationConsoleDbContext"),
            //    b => b.MigrationsAssembly(typeof(AdministrationConsoleDbContext).Assembly.FullName)));
            ////SuppressForeignKeyEnforcement

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AdministrationConsoleDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Tokens:Key"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    //TODO: false to true invetigate twhat needs to be corrected
                    IssuerSigningKey = signingKey,
                    ValidateAudience = false,
                    ValidAudience = Configuration["Tokens:Audience"],
                    ValidateIssuer = false,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false
                };
                //config.Events = new JwtBearerEvents()
                //{
                //    OnAuthenticationFailed = c =>
                //    {
                //        c.NoResult();
                //        c.Response.StatusCode = 401;
                //        c.Response.ContentType = "text/plain";
                //        Console.WriteLine(c.Exception.ToString());
                //        return c.Response.WriteAsync(c.Exception.ToString());
                //    }
                //};
            });

            services.AddControllers();
                //p => p.Filters.Add(typeof(NotAuthorizedExceptionFilterAttribute)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Albergue.Administrator", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {new OpenApiSecurityScheme{Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }}, new List<string>()}
                });
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
            {
                p.AllowAnyOrigin();
                p.AllowAnyHeader();
                p.AllowAnyMethod();
            });

            app.UseAuthentication();
            app.UseAuthorization();

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
