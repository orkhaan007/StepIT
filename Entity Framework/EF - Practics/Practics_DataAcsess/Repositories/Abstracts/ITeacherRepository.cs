using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface ITeacherRepository : IBaseRepository<Teacher>
{
    string GetFullName(int teacherId);
    int GetTeacherCountByDepartmentId(int departmentId);
    IEnumerable<Teacher> GetTeachersByDepartmentId(int departmentId);
}
