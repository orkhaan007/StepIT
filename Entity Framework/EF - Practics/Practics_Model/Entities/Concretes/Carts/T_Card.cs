using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practics_Model.Entities.Abstracts;
#nullable disable

namespace Practics_Model.Entities.Concretes.Carts;

public class T_Card : BaseEntity
{
    public int Id_Teacher { get; set; }

    public int Id_Book { get; set; }

    public DateTime DateOut { get; set; }

    public DateTime? DateIn { get; set; }

    public int Id_Lib { get; set; }

    [ForeignKey(nameof(Id_Teacher))]
    public virtual Teacher Teacher { get; set; }

    [ForeignKey(nameof(Id_Book))]
    public virtual Book Book { get; set; }

    [ForeignKey(nameof(Id_Lib))]
    public virtual Lib Lib { get; set; }
}