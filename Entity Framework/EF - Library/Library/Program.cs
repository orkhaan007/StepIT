#nullable disable
using Library.Contexts;
namespace Library;

class Program
{
    static void Main(string[] args)
    {
        EFLibraryDBContext db = new EFLibraryDBContext();

        db.SaveChanges();
    }
}