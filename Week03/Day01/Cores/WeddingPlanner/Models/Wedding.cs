#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace WeddingPlanner.Models;
public class FuturDate : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if ((DateTime)value < DateTime.Now)
            return new ValidationResult("Date must be in the Futur");
        return ValidationResult.Success;
    }
}

public class Wedding
{
    // User Id
    [Key]
    public int WeddingId { get; set; }

    [Required]
    public int UserId { get; set; }
    public User? Creator { get; set; }
    [Required(ErrorMessage = "Please enter your WeddingOne.")]
    [MinLength(3, ErrorMessage = "Please enter a valid WeddingOne .")]
    public string WeddingOne { get; set; }
    [Required(ErrorMessage = "Please enter your WeddingTwo.")]
    [MinLength(3, ErrorMessage = "Please enter a valid WeddingTwo .")]
    public string WeddingTwo { get; set; }


    [Required]
    [FuturDate]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Please enter your Adress.")]

    public string Adress { get; set; }

    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //! Navigation Property
    public List<Participation> WeddingParticipation { get; set; } = new List<Participation>();

}