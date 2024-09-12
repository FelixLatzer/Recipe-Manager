using Microsoft.Extensions.Logging;
using RecipeManager.Database;
using RecipeManager.ViewModels;
using RecipeManager.Views;
using SQLitePCL;

namespace RecipeManager
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            Batteries_V2.Init();

            builder.Services.AddDbContextFactory<Context>(lifetime: ServiceLifetime.Transient);
            builder.Services.AddTransient<AddRecipeViewModel>();
            builder.Services.AddTransient<AddRecipeView>();
            builder.Services.AddTransient<MyRecipeViewModel>();
            builder.Services.AddTransient<MyRecipesView>();

            var dbContext = new Context();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
