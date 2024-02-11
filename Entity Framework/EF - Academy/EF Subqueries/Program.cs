using System;
using System.Linq;
using EF_Subqueries.Contexts;
using EF_Subqueries.Entities;
using Microsoft.VisualBasic;
#nullable disable

namespace EF_Subqueries
{
    class Program
    {
        static void Main(string[] args)
        {
            EFSubqueriesDBContext db = new EFSubqueriesDBContext();

            for (int i = 1; i <= 5; i++)
            {
                var sts = new Student
                {
                    Name = $"Student {i}",
                    Rating = i,
                    Surname = $"Student Name {i}",
                };

                db.Students.Add(sts);
            }

            db.SaveChanges();
        }
    }
}