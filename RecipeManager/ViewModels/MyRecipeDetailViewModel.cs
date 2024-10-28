using Microsoft.EntityFrameworkCore;
using RecipeManager.Database;
using RecipeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.ViewModels;

public class MyRecipeDetailViewModel : BaseViewModel
{
    private Context _context;

    private Recipe _recipe;
    public Recipe Recipe
    {
        get 
        {
            return _recipe; 
        }
        set 
        { 
            _recipe = value;
            OnPropertyChanged();
        }
    }

    public MyRecipeDetailViewModel(IDbContextFactory<Context> dbContextFactory, int id)
    {
        _context = dbContextFactory.CreateDbContext();
        LoadDataAsync(id).ConfigureAwait(false);
    }

    private async Task LoadDataAsync(int id)
    {
        var recipe = await _context.Recipes.Include(r => r.Steps)
                                           .SingleOrDefaultAsync(x => x.Id == id);

        if (recipe is null)
        {
            return;
        }

        Recipe = recipe;
    }
}
