using Practics_Model.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Practics_Model.Entities.Concretes;

public class Group : BaseEntity
{
    [Required]
    [StringLength(10)]
    public string Name { get; set; }

    public int Id_Faculty { get; set; }

    [ForeignKey(nameof(Id_Faculty))]
    public virtual Faculty Faculty { get; set; }
}
