using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class AuthorRepository<T> : BaseRepository<Author>, IAuthorRepository
{
    public IEnumerable<Book> GetBooksByAuthor(int authorId)
    {
        return _context.Books
            .Where(b => b.Id == authorId)
            .ToList();
    }

    public int GetBookCountByAuthor(int authorId)
    {
        return _context.Books
            .Count(b => b.Id == authorId);
    }
}
