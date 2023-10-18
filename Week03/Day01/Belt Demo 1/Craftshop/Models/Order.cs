#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace Craftshop.Models;

public class Order
{
    [Key]
    public int OrderId { get; set; }

    [Required]
    public int UserId { get; set; }
    public User? Buyer { get; set; } // OTM Crafts Orders
    [Required]
    public int CraftId { get; set; }
    public Craft? Craft { get; set; } // OTM Orders Crafts

    [Required(ErrorMessage = "Please Enter Quantity Ordered.")]
    [Range(1, Int32.MaxValue, ErrorMessage = "Please Enter a Valid Quantity.")]
    public int Quantity { get; set; }

    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
