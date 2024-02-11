using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes.Carts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Practics_Model.Entities.Concretes;

public class Student : BaseEntity
{
    [Required]
    [StringLength(15)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(25)]
    public string LastName { get; set; }

    public int Id_Group { get; set; }

    public int Term { get; set; }

    [ForeignKey(nameof(Id_Group))]
    public virtual Group Group { get; set; }
}
