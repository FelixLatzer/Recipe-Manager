using Microsoft.EntityFrameworkCore;
using RecipeManager.Database;
using RecipeManager.Models;
using RecipeManager.Utils;
using RecipeManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RecipeManager.ViewModels;

public class MyRecipeViewModel : BaseViewModel
{
    private Context _dbContext;

    private Recipe _selectedRecipe;
    public Recipe SelectedRecipe
    {
        get
        {
            return _selectedRecipe;
        }
        set
        {
            _selectedRecipe = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Recipe> Recipes { get; set; } = [];

    public ICommand OpenRecipeCommand { get; set; }
    public ICommand DeleteRecipeCommand { get; set; }

    public MyRecipeViewModel(IDbContextFactory<Context> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        OpenRecipeCommand = new RelayCommand(OpenRecipe, ()=>true);
        DeleteRecipeCommand = new RelayCommand(DeleteRecipe, ()=>true);
    }

    public async void LoadData()
    {
        Recipes.Clear();

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
   
    private void DeleteRecipe(object recipe)
    {
        _dbContext.Recipes.Remove(recipe as Recipe);
        _dbContext.SaveChanges();
        Recipes.Remove(recipe as Recipe);
    }

    private void OpenRecipe(object recipe)
    {
        Shell.Current.GoToAsync($"{nameof(MyRecipeDetailView)}?Id={(recipe as Recipe).Id}");
    }
}
