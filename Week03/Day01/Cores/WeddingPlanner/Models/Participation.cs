#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // new import for ***

namespace WeddingPlanner.Models;

public class Participation
{
    //Post Id
    [Key]
    public int ParticipationId {get;set;}

    //! Foreign key for user

    [Required]
    public int WeddingId { get; set; }

    [Required]
    public int UserId { get; set; }
    


    public DateTime CreatedAt {get;set;} = DateTime.Now;
    public DateTime UpdatedAt {get;set;} = DateTime.Now;

    // //! Navigation Property
    public Wedding? Wedding { get; set; }
    public User? Participant {get;set;}
    
}
