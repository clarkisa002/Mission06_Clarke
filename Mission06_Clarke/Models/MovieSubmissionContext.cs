using Microsoft.EntityFrameworkCore;

namespace Mission06_Clarke.Models;

public class MovieSubmissionContext : DbContext //Liaison from the app to the database
{
    public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options)
    {
    }
    
    public DbSet<MovieSubmission> MovieSubmissions { get; set; }
    public DbSet<Category> Categories { get; set; }
}
