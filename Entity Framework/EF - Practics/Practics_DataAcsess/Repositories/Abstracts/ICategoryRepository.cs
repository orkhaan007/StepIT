using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface ICategoryRepository : IBaseRepository<Category>
{
    IEnumerable<Book> GetBooksInCategory(int categoryId);
    int GetCategoryCount();
}
