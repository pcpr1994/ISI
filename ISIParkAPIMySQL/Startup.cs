//using ISIParkAPIMySQL.Data;
//using ISIParkAPIMySQL.Data.Repositories;
//using Microsoft.OpenApi.Models;

//namespace ISIParkAPIMySQL
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            var mySQLConnectionConfig = new MySQLConfiguration(Configuration.GetConnectionString("MySqlConnection"));
//            services.AddSingleton(mySQLConnectionConfig);

//            services.AddScoped<IPersonalDataRepository, PersonalDataRepository>();

//            services.AddControllers();
//            services.AddSwaggerGen();
//        }

//        public void Configure(WebApplication app, IWebHostEnvironment env)
//        {
//            if (!app.Environment.IsDevelopment())
//            {
//                app.UseExceptionHandler("/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            app.UseHttpsRedirection();
//            app.UseStaticFiles();
//            app.UseRouting();
//            app.UseAuthorization();
//            app.Run();
//        }
//    }
//}
