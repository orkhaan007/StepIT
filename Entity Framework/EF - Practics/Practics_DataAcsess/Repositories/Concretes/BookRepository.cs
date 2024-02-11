using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class BookRepository<T> : BaseRepository<Book>, IBookRepository
{
    public IEnumerable<Author> GetAuthorsOfBook(int bookId)
    {
        return _context.Authors
            .Include(a => a.Books)
            .Where(a => a.Books.Any(b => b.Id == bookId))
            .ToList();
    }
    public int GetBookCount()
    {
        return _context.Books.Count();
    }
}
