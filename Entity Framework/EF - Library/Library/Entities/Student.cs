using Library.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Library.Entities;

internal class Student : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SchoolNumber { get; set; }
    public Gender Gender { get; set; }
    public DateTime BirthDay { get; set; }
    public string PhoneNumber { get; set; }
    public ICollection<Operation> Operations { get; set; }
}
