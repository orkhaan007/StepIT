using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace EF_Subqueries.Entities;

internal class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Range(1, 5)]
    public int Building { get; set; }

    [Required]
    [Column(TypeName = "money")]
    [Range(0, double.MaxValue)]
    public decimal Financing { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int FacultyId { get; set; }

    [ForeignKey("FacultyId")]
    public Faculty Faculty { get; set; }
}
