using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class ThemeRepository<T> : BaseRepository<Theme>, IThemeRepository
{
    public Theme GetThemeByName(string name)
    {
        return _context.Themes.FirstOrDefault(t => t.Name == name);
    }
    public int GetThemeCount()
    {
        return _context.Themes.Count();
    }
}
