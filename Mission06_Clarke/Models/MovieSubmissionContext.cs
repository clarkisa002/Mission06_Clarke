using Microsoft.EntityFrameworkCore;

namespace Mission06_Clarke.Models;

public class MovieSubmissionContext : DbContext
{
    public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
    {
    }
    
    public DbSet<MovieSubmission> MovieSubmissions { get; set;}
}
