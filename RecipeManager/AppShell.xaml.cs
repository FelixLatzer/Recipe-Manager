using RecipeManager.Views;

namespace RecipeManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddRecipeView), typeof(AddRecipeView));
            Routing.RegisterRoute(nameof(MyRecipesView), typeof(MyRecipesView));
        }
    }
}
