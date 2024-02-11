using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface IBookRepository : IBaseRepository<Book>
{
    IEnumerable<Author> GetAuthorsOfBook(int bookId);
    int GetBookCount();
}
