using Practics_Model.Entities.Concretes;

namespace Practics_DataAcsess.Repositories.Abstracts;

public interface IStudentRepository : IBaseRepository<Student>
{
    string GetFullName(int studentId);
    int GetStudentCountByGroupId(int groupId);
    IEnumerable<Student> GetStudentsByGroupId(int groupId);
}
