using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using RecipeManager.Database;
using RecipeManager.ViewModels;

namespace RecipeManager.Views;

[QueryProperty(nameof(RecipeId), "Id")]
public partial class MyRecipeDetailView : ContentPage
{
	public int RecipeId 
    {
        set
        {
            BindingContext = new MyRecipeDetailViewModel(_dbContextFactory, (int)value);
        }
    }
    private IDbContextFactory<Context> _dbContextFactory;

	public MyRecipeDetailView(IDbContextFactory<Context> dbContextFactory)
	{
		InitializeComponent();
        _dbContextFactory = dbContextFactory;
    }
}