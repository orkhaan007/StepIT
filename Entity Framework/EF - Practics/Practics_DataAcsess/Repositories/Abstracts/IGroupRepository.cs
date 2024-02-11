using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface IGroupRepository : IBaseRepository<Group>
{
    string GetFullName(int groupId);
    int GetGroupCountByFacultyId(int facultyId);
    IEnumerable<Group> GetGroupsByFacultyId(int facultyId);
}
