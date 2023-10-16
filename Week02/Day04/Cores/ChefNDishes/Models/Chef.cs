#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace ChefNDishes.Models;

public class PastDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value > DateTime.Now)
            return new ValidationResult("Date must be in the past");
        else if ((DateTime.Now.Subtract((DateTime)value)).TotalDays / 365 < 18)
            return new ValidationResult("Chef must be at least 18");
        return ValidationResult.Success;
    }
}

public class Chef
{
    // Chef Id
    [Key]
    public int ChefId { get; set; }

    //Chef First Name 
    [Required]
    [MinLength(2, ErrorMessage = "First Name must be at least 3 characters")]
    public string FirstName { get; set; }
    //Chef Last Name 
    [Required]
    [MinLength(2, ErrorMessage = "Last Name must be at least 3 characters")]
    public string LastName { get; set; }

    [Required]
    [PastDate]
    [Display(Name = "Date of Birth")]
    public DateTime DateOfBirth { get; set; }
            public int Age() 
        {
            TimeSpan interval = DateTime.Now.Subtract(this.DateOfBirth);
            int currentage = (int) Math.Floor(interval.TotalDays / 365);
            return currentage;
        } 


    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> ChefDiches { get; set; } = new List<Dish> { };

}