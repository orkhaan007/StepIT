using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Library.Entities;

internal class Book : BaseEntity
{
    public string Name { get; set; }
    public int PageCount { get; set; }
    public ICollection<Author> Authors { get; set; }
    public int BookTypeId { get; set; }
    public BookType BookType { get; set; }
}
