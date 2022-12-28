using ISIParkAPI.Data;
using ISIParkAPI.Data.Repositories;
using ISIParkAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using System.Reflection;
using System;

namespace ISIParkAPI
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
            var mySQLConnectionConfig = new MySQLConfiguration(Configuration.GetConnectionString("MySqlConnection"));
            services.AddSingleton(mySQLConnectionConfig);

            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
            services.AddScoped<IUserTypeRepository, UserTypeRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IPlaceTypeRepository, PlaceTypeRepository>();
            services.AddScoped<IAdminMessageRepository, AdminMessageRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserHistoryRepository, UserHistoryRepository>();
            services.AddScoped<IUserVechicleTypeRepository, UserVechicleTypeRepository>();
            services.AddScoped<IUserContactTypeRepository, UserContactTypeRepository>();
            services.AddScoped<IUserMessageRepository, UserMessageRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ISIParkAPI", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ISIParkAPI v1"));
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
