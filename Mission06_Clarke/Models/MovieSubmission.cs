

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Clarke.Models;

[Table("Movies")]
public class MovieSubmission
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    public int? CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required]
    public string Title { get; set; }
    [Required]
    [Range(1888, 3000, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }
    public bool Edited { get; set; }
    public bool CopiedToPlex { get; set; }
    public string? LentTo { get; set; }
    public string? Notes { get; set; }
}

