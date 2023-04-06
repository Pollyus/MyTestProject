using Coordinator.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestAppData;
using Serilog;
using Serilog.Events;
using Persistence.Options;

namespace Coordinator
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .CreateLogger();

            builder.Host.UseSerilog();

            builder.WebHost.UseUrls("http://localhost:5271");

            // Add services to the container.
            builder.Services.Configure<PostgresOptions>(
                builder.Configuration.GetSection(PostgresOptions.PostgresOptionsString));
            builder.Services.AddControllers();

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<IReportRepository, ReportRepository>();

            //builder.Services.AddDbContext<TestAppContext>(
            //    o => o.UseNpgsql(builder.Configuration.GetConnectionString("NewTest_db")));

           
        

            var app = builder.Build();
            app.MapControllers();
            app.UseSwagger();
            app.UseSwaggerUI();

            await app.RunAsync();


        }
    }
}


