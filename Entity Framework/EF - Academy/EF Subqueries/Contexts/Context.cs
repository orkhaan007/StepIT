using Microsoft.EntityFrameworkCore;
using EF_Subqueries.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace EF_Subqueries.Contexts;

internal class EFSubqueriesDBContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string constr = "Data Source=ORKHAN\\SQLEXPRESS01;Initial Catalog=EFSubqueriesDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;";
        optionsBuilder.UseSqlServer(constr);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();
        
        modelBuilder.Entity<Faculty>()
            .HasIndex(f => f.Name)
            .IsUnique();

        modelBuilder.Entity<Subject>()
            .HasIndex(f => f.Name)
            .IsUnique();

        modelBuilder.Entity<Group>()
            .HasIndex(f => f.Name)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Curator> Curators { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupsCurators> GroupCurators { get; set; }
    public DbSet<GroupsLectures> GroupLectures { get; set; }
    public DbSet<GroupsStudents> GroupStudents { get; set; }
    public DbSet<Lecture> Lecturies { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

}
