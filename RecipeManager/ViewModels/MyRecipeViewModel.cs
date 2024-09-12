using Microsoft.EntityFrameworkCore;
using RecipeManager.Database;
using RecipeManager.Models;
using RecipeManager.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeManager.ViewModels;

public class MyRecipeViewModel : BaseViewModel
{
    private Context _dbContext;

    public ObservableCollection<Recipe> Recipes { get; set; } = [];

    public ICommand OpenRecipeCommand { get; set; }

    public MyRecipeViewModel(IDbContextFactory<Context> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        OpenRecipeCommand = new RelayCommand(OpenRecipe, ()=>true);
    }

    public async void LoadData()
    {
        var recipes = await _dbContext.Recipes.ToListAsync();

        if (recipes is null)
        {
            return;
        }

        foreach(var recipe in recipes)
        {
            Recipes.Add(recipe);
        }
    }

    private void OpenRecipe()
    {
        
    }
}
