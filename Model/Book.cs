using System.ComponentModel.DataAnnotations;

namespace DrabLibrary.Model;

public class Book
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public int? Year { get; set; }
}
