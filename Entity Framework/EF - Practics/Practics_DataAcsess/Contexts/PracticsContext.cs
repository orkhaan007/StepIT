using Microsoft.EntityFrameworkCore;
using Practics_Model.Entities.Concretes;
using Practics_Model.Entities.Concretes.Carts;
using Microsoft.Extensions.Configuration;
#nullable disable

namespace Practics_DataAcsess.Contexts;

internal class PracticsContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var ConStr = new ConfigurationManager()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetConnectionString("DefaultConnection");

        optionsBuilder
            .UseLazyLoadingProxies()
            .UseSqlServer(ConStr);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Faculty> Faculties { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Lib> Libs { get; set; }
    public virtual DbSet<Press> Presses { get; set; }
    public virtual DbSet<S_Card> StudentCarts { get; set; }
    public virtual DbSet<T_Card> TeacherCarts { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Teacher> Teachers { get; set; }
    public virtual DbSet<Theme> Themes { get; set; }
}
