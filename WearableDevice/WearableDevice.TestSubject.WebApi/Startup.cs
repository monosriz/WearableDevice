using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WearableDevice.AppServices;
using WearableDevice.Model;
using WearableDevice.Model.Authentication;
using WearableDevice.Model.Interface;
using WearableDevice.Repository;
using WearableDevice.Repository.Context;

namespace WearableDevice.TestSubject.WebApi
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
            services.AddControllers();

            services.AddDbContext<WearableDeviceDBContext>(options =>
                     options.UseInMemoryDatabase("WearableDevice"));
            services.AddTransient<IActivationRepository, ActivationRepository>();
            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
            services.AddTransient<IAccelerationRepository, AccelerationRepository>();
            services.AddTransient<ActivationService>();
            services.AddTransient<UserProfileService>();
            services.AddTransient<AccelerationService>();
            services.AddTransient<Authentication>();
            services.AddTransient<ApplicationActivationService>();
            services.AddTransient<ApplicationProfileService>();
            services.AddTransient<ApplicationAccelerationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Dawn Health Backend Developer Case",
                    Description = "Dawn Health Backend Developer Case.",

                    Contact = new OpenApiContact
                    {
                        Name = "Monosriz Dutta",
                        Email = "monosrizdutta@gmail.com",

                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",

                    }
                });


            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dawn Health Backend Developer Case");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
