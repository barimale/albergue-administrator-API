using Albergue.Administrator.HostedServices;
using Albergue.Administrator.HostedServices.Hub;
using Albergue.Administrator.Repository;
using Albergue.Administrator.Services;
using Albergue.Administrator.SQLite.Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        private string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<ILocalesStatusHub, LocalesStatusHub>();
            services.AddScoped<IImageExtractor, ImageExtractor>();
            services.AddScoped<ILocalesGenerator, LocalesGenerator>();
            services.AddScoped<IAuthorizeService, AuthorizeService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();

            services.AddAutoMapper(typeof(Startup));
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                      builder =>
                                      {
                                          builder.WithOrigins("*",
                                                                "https://administrator-albergue-porto.web.app",
                                                                "https://shop-albergue-porto.web.app",
                                                              "http://localhost:3006",
                                                              "http://localhost:3008")
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod();
                                      });
            });


            services.AddDbContext<AdministrationConsoleDbContext>(options =>
                options
                    .UseSqlite(Configuration.GetConnectionString("AdministrationConsoleDbContext"),
                b => b.MigrationsAssembly(typeof(AdministrationConsoleDbContext).Assembly.FullName)));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<AdministrationConsoleDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Tokens:Key"]));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = false,
                    ValidAudience = Configuration["Tokens:Audience"],
                    ValidateIssuer = false,
                    ValidIssuer = Configuration["Tokens:Issuer"],
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = false
                };
            });

            services.AddSignalR();

            services.AddControllers();

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
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }}, new List<string>()}
                });
            });

            services.AddHostedService<LocalesHostedService>();

            services.AddDirectoryBrowser();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AdministrationConsoleDbContext dbContext)
        {
            try
            {
                dbContext.Database.Migrate();
            }
            catch (System.Exception)
            {
                Console.WriteLine("On Migrate error");
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AdministrationConsoleDbContext v1"));
            }

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            var destinationFolder = Configuration.GetValue<string>("LocalesDir");

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
           Path.Combine(destinationFolder)),
                RequestPath = "/locales"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                  Path.Combine(destinationFolder)),
                RequestPath = new PathString("/locales")
            });
            //app.UseHsts();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<LocalesStatusHub>("/localesHub");
            });
        }
    }
}
