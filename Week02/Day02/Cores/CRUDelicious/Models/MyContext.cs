#pragma warning disable CS8618
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;
namespace CRUDelicious.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions options) : base(options) { }
    //Add  All Tables Here
    //-access modifier  type DbSet<Model> table name getter setter
    public DbSet<Dish> Dishes { get; set; }
}