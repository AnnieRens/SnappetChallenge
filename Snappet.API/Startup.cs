using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Snappet.Core;
using Snappet.Core.Repository;

namespace Snappet.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            ConfigureDataLayer(services);

            // Configure Students
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IStudentsService, StudentsService>();

            // Configure Exercises and Statistic
            services.AddScoped<IExercisesSubmitAnswersRepository, ExercisesSubmitAnswersRepository>();
            services.AddScoped<IClassWorkStatisticService, ClassWorkStatisticService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void ConfigureDataLayer(IServiceCollection services)
        {
            // Initialize repository with dataset
            var currentProjectPath = Directory.GetCurrentDirectory();
            var datasetFileName = "work.json"; // todo replace to json config
            var datasetPath = Path.Combine(currentProjectPath, datasetFileName);

            services.AddScoped<ClassContext, ClassContext>(x => new ClassContext(datasetPath));
        }
    }
}
