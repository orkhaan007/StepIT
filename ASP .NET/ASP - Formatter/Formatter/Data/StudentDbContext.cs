using Microsoft.EntityFrameworkCore;
using Formatter.Entities;

namespace Formatter.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            :base(options) { }

        public DbSet<Student>  Students { get; set; }
    }
}
