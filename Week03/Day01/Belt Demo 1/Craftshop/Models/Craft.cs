#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Craftshop.Models;

public class Craft {
    [Key]
    public int CraftId {get;set;}

    [Required]
    public int UserId { get; set; }
    public User? Owner { get; set; } // OTM Users Crafts

    [Required(ErrorMessage ="Please Enter Image Url.")]
    [DataType(dataType:DataType.Url,ErrorMessage ="Please enter a valid url.")]
    public string ImageUrl { get; set; }
    [Required(ErrorMessage ="Please Enter Price In $.")]
    [Range(0,double.MaxValue,ErrorMessage ="Please Enter a Valid Price.")]
    public double ? Price { get; set; }
    [Required(ErrorMessage ="Please Enter Craft Title.")]
    public string Title { get; set; }
    [Required(ErrorMessage ="Please Enter Craft Quantity.")]
    [Range(0,Int32.MaxValue,ErrorMessage ="Please Enter a Valid Quantity.")]
    public int Quntity { get; set; }
    [Required(ErrorMessage ="Please Enter Craft Description.")]
    [MinLength(10,ErrorMessage ="Please Enter a Valid Description.")]
    public string Description { get; set; }


        // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //! Navigation Property
    public List<Order> OrderedCrafts { get; set; } = new List<Order>{}; // OTM Crafts Orders
}