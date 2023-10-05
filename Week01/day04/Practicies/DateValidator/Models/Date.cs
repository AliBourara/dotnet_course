#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Type cast 'value' into a DateTime:
        DateTime InputDate = Convert.ToDateTime(value);

        if (InputDate >= DateTime.Now)
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Date needs to be in the future.");
        }
    }
}
    public class Choice
    {
        [Required]
        [Display(Name = "Choose Date:")]
        [DataType(DataType.Date)]
        [FutureDateAttribute] // use custom validation here
        public DateTime ChosenDate { get; set; }

    }