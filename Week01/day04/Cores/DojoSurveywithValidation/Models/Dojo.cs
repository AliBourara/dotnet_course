#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace DojoSurveywithValidation.Models;
public enum Loc
{
    Konoha,
    Tatuine,
    Durotar
}
public enum Lang
{
    Klingon,
    Japanese,
    Orcish
}
public class Dojo
{
    [Required(ErrorMessage = "Please add a Name .")]
    [MinLength(2, ErrorMessage = "Name must be at least 2 .")]
    public string Name { get; set; }
    [Required]
    public Loc Location { get; set; }
    [Required]
    public Lang Language { get; set; }
    [Required]
    [Range(1, 20, ErrorMessage = "Please enter a valid comment .")]
    public string  Comment { get; set; }

}