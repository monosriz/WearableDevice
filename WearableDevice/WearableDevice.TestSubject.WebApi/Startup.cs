using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
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

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
