using Practics_Model.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Practics_Model.Entities.Concretes;

public class Book : BaseEntity
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [Required]
    public int Pages { get; set; }

    [Required]
    public int YearPress { get; set; }

    [ForeignKey(nameof(Theme))]
    public int ThemeId { get; set; }
    public virtual Theme Theme { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    [ForeignKey(nameof(Author))]
    public int AuthorId { get; set; }
    public virtual Author Author { get; set; }

    [ForeignKey(nameof(Press))]
    public int PressId { get; set; }
    public virtual Press Press { get; set; }

    [StringLength(50)]
    public string Comment { get; set; }

    [Required]
    public int Quantity { get; set; }
}
