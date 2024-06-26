using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ToDoListApp.Data;
using ToDoListApp.Services;

namespace ToDoListApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            //var connectionString = $"Server={Environment.MachineName}\\{Environment.UserName};Database=MobileStore;Trusted_Connection=True;TrustServerCertificate=True;";
            string connectionString = "Server=DESKTOP-F1RTV5Q\\RAMI;Database=ToDoListApp;Trusted_Connection=True;TrustServerCertificate=True;";
            
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddTransient<ITaskAppService, TaskAppService>();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
