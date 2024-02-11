using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface IThemeRepository : IBaseRepository<Theme>
{
    Theme GetThemeByName(string name);
    int GetThemeCount();
}
