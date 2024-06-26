﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace EF_Subqueries.Entities;

internal class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength]
    public string Name { get; set; }

    [Required]
    [Range(0, 5)]
    public int Rating { get; set; }

    [Required]
    [MaxLength]
    public string Surname { get; set; }
}
