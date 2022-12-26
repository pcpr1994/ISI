using ISIParkAPI.Data;
using ISIParkAPI.Data.Repositories;
using ISIParkAPI.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ISIParkAPI", Version = "v1" });
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
