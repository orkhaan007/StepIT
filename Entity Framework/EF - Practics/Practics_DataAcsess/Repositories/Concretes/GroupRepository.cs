using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class GroupRepository<T> : BaseRepository<Group>, IGroupRepository
{
    public string GetFullName(int groupId)
    {
        var group = GetById(groupId);
        if (group != null)
        {
            return $"{group.Name} - {group.Faculty?.Name}";
        }
        return null;
    }

    public int GetGroupCountByFacultyId(int facultyId)
    {
        return _context.Groups.Count(g => g.Id_Faculty == facultyId);
    }

    public IEnumerable<Group> GetGroupsByFacultyId(int facultyId)
    {
        return _context.Groups.Where(g => g.Id_Faculty == facultyId).ToList();
    }
}
