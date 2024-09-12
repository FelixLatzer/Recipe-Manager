using RecipeManager.ViewModels;

namespace RecipeManager.Views;

public partial class MyRecipesView : ContentPage
{
	private MyRecipeViewModel _recipeViewModel;

	public MyRecipesView(MyRecipeViewModel viewModel)
	{
		InitializeComponent();
		_recipeViewModel = viewModel;
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

		_recipeViewModel.LoadData();
    }
}