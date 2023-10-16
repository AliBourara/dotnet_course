#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace ChefNDishes.Models;

public class Dish 
{
    [Key]
    public int DishId { get; set; }

[Required]
    public int ChefId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Range(1,5)]
    public int Tastiness { get; set; }

    [Required]
    
    [Range(1, Int32.MaxValue)]
    public int Calories { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Chef? Poster { get; set; }
}