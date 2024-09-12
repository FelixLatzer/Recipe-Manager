using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using RecipeManager.Models;

namespace RecipeManager.Database;

public class Context : DbContext
{
    public DbSet<Step> Steps { get; set; }
    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //TODO: differenzieren ob Android oder IOS
        //string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //path = Path.Combine(path, "RecipeManager.db3");
        //optionsBuilder.UseSqlite($"Filename={path}");
        var dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        dbPath = Path.Combine(dbPath, "mydatabase.db");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
}
