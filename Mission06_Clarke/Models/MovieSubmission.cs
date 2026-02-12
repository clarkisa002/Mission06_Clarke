

using System.ComponentModel.DataAnnotations;

namespace Mission06_Clarke.Models;

public class MovieSubmission
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Year { get; set; }
    [Required]
    public string Director { get; set; }
    [Required]
    public string Rating { get; set; }
    public bool Edited { get; set; }
    public string LentTo { get; set; }
    public string Notes { get; set; }
}

