using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace EF_Subqueries.Entities;

internal class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public bool IsProfessor { get; set; }

    [Required]
    [MaxLength]
    public string Name { get; set; }

    [Required]
    [Column(TypeName = "money")]
    [Range(0.01, double.MaxValue)]
    public decimal Salary { get; set; }

    [Required]
    [MaxLength]
    public string Surname { get; set; }
}
