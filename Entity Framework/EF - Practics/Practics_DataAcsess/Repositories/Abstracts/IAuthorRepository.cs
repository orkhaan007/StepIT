using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface IAuthorRepository : IBaseRepository<Author>
{
    IEnumerable<Book> GetBooksByAuthor(int authorId);
    int GetBookCountByAuthor(int authorId);
}
