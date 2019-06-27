using GuanatosSoft.Api.Data.Entities;
using GuanatosSoft.Api.Data.Repositories;
using GuanatosSoft.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GuanatosSoft.Api
{
    public class Startup
    {
        public const string CORS_POLICYNAME = "GuanatosSoftApiCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICYNAME,
                    builder =>
                        builder.WithOrigins(
                            "http://localhost:4200", // Front end local/dev/prod url (depending on settings)
                            "https://guanatos-soft-web2.azurewebsites.net" // Should be set in env settings
                        ) 
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // We could use other IOC providers or to configure a assembly scan for them
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IRepositoryRestaurant, RestaurantRepository>();

            this.SetupDbcontext(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(CORS_POLICYNAME);

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public void SetupDbcontext(IServiceCollection services)
        {
            services.AddLogging((lb) => lb.AddDebug().AddConsole());

            var connection = Configuration.GetConnectionString("GuanatosSoftDb");
            services.AddDbContext<guanatossoftdbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            //// Blob Storage Configuration
            //var cloudStorageAccount = CloudStorageAccount.Parse(configuration.GetConnectionString("StorageAccountConnectionString"));
            //services.AddSingleton(cloudStorageAccount);
        }
    }
}
