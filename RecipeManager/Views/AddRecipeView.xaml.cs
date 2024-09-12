using RecipeManager.Database;
using RecipeManager.ViewModels;

namespace RecipeManager.Views;

public partial class AddRecipeView : ContentPage
{
	public AddRecipeView(AddRecipeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}