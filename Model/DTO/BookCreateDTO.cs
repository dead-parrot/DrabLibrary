using System.ComponentModel.DataAnnotations;

namespace DrabLibrary.Model.DTO;

public class BookCreateDTO
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public int? Year { get; set; }
}
