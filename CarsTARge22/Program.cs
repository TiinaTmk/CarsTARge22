using CarsTARge22.ApplicationServices.Services;
using CarsTARge22.Core.ServiceInterface;
using CarsTARge22.Data;
using Microsoft.EntityFrameworkCore;


namespace CarsTARge22
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Add services to the container.
            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            }

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<CarContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ICarsServices, CarsServices>();

            var app = builder.Build();

            // Configure logging here if needed

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                CreateDbIfNotExists(services);
            }

            app.Run();
        }

        private static void CreateDbIfNotExists(IServiceProvider services)
        {
            try
            {
                var context = services.GetRequiredService<CarContext>();

                // Consider using migrations in a production environment
                context.Database.EnsureCreated();

                // Consider using migrations in a production environment
                DbInitializer.Initialize(context);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred creating the DB.");
                // Handle the exception based on your application's requirements
            }
        }
    }
}
