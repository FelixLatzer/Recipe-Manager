using FirstMauiApp.Views;

namespace FirstMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddRecipeView), typeof(AddRecipeView));
        }
    }
}
