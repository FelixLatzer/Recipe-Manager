using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using RecipeManager.Database;
using RecipeManager.Models;
using RecipeManager.Utils;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace RecipeManager.ViewModels;

public class AddRecipeViewModel : BaseViewModel
{
    private Context _dbContext;

    private string? _name = default;
    public string? Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    private Step _currentStep = new() { StepNumber = 1};
    public Step CurrentStep
    {
        get
        {
            return _currentStep;
        }
        set
        {
            _currentStep = value;
            OnPropertyChanged();
        }
    }

    public ObservableCollection<Step> Steps { get; set; }

    public ICommand AddStepCommand { get; private set; }
    public ICommand SaveRecipeCommand { get; private set; }

    public AddRecipeViewModel(IDbContextFactory<Context> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
        Steps = [];
        AddStepCommand = new RelayCommand(AddStep, ()=>true);
        SaveRecipeCommand = new RelayCommand(SaveRecipe, ()=>true);
    }

    private void AddStep()
    {
        Steps.Add(CurrentStep);
        CurrentStep = new() { StepNumber = Steps.Count + 1};
    }

    private async void SaveRecipe()
    {
        await _dbContext.Recipes.AddAsync(new Recipe{Name = Name, Steps = Steps.ToList()});
        await _dbContext.SaveChangesAsync();

        Name = string.Empty;
        Steps.Clear();
        CurrentStep = new() { StepNumber = 1};
    }
}
