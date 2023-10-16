#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // New import for ****
namespace WeddingPlanner.Models;

public class Participation
{
    // Post Id
    [Key]
    public int ParticipationId { get; set; }

    //!  WeddingID "Foreign key" 

    [Required]
    public int WeddingID { get; set; }

    //!  UserID "Foreign key" 
    [Required]
    public int UserId { get; set; }

    // Created At
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Updated At
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    //! Navigation Properties
    // public Post? Post { get; set; }
    // public User? User { get; set; }
}