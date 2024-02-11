using Practics_Model.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practics_Model.Entities.Concretes.Carts;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Practics_Model.Entities.Concretes;

public class Teacher : BaseEntity
{
    [Required]
    [StringLength(15)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(25)]
    public string LastName { get; set; }

    public int Id_Dep { get; set; }

    [ForeignKey(nameof(Id_Dep))]
    public virtual Department Department { get; set; }
}
