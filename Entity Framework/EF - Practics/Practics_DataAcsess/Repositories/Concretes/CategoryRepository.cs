using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class CategoryRepository<T> : BaseRepository<Category>, ICategoryRepository
{
    public IEnumerable<Book> GetBooksInCategory(int categoryId)
    {
        return _context.Books
            .Where(b => b.Id == categoryId)
            .ToList();
    }
    public int GetCategoryCount()
    {
        return _context.Categories.Count();
    }
}
