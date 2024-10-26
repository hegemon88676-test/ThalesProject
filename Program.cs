using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using SoldierMovementTracking.Data;
using SoldierMovementTracking.Services;

namespace SoldierMovementTracking
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<MilitaryContext>();
                    // Initialize the database or perform any required setup
                }
                catch (Exception)
                {
                    // Handle exceptions
                }
            }

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<MilitaryContext>(options =>
                        options.UseSqlServer(hostContext.Configuration.GetConnectionString("DefaultConnection")));
                    services.AddScoped<ISoldierService, SoldierService>();
                    services.AddScoped<IPositionService, PositionService>();
                });
    }
}
