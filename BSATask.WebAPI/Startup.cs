using AutoMapper;
using BSATask.WebAPI.MappingProfile;
using CollectionsAndLinq.BL.Context;
using CollectionsAndLinq.BL.Interfaces;
using CollectionsAndLinq.BL.MappingProfiles;
using CollectionsAndLinq.BL.Services.CreateServices;
using CollectionsAndLinq.BL.Services.ReaderServices;
using CollectionsAndLinq.BL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace BSATask.WebAPI
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
            services.AddControllers();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BSATask Web API",
                    Description = "ASP.NET Core 6.0 Web API"
                });
            });
            var config = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new BusionessLayerProfile());
                mc.AddProfile(new ViewsMappingProfile());
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddSingleton<IDataProvider, DataProvider>();
            services.AddTransient<IDataProcessingService, DataProcessingService>();
            services.AddTransient<IProjectReaderService, ProjectReaderService>();
            services.AddTransient<IProjectCreateService, ProjectCreateService>();
            services.AddTransient<ITaskReadService, TaskReadService>();
            services.AddTransient<ITaskCreateService, TaskCreateService>();
            services.AddTransient<ITeamReadService, TeamReadService>();
            services.AddTransient<ITeamCreateService, TeamCreateService>();
            services.AddTransient<IUserReadService, UserReadService>();
            services.AddTransient<IUserCreateService, UserCreateService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSATask Web API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSATask Web API v1");

            });
            DataInitializer.Seed();
        }
    }
}
