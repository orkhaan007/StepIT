using Microsoft.EntityFrameworkCore;
using Movie_Worker.Entities;

namespace Movie_Worker.Contexts
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
    }

}
