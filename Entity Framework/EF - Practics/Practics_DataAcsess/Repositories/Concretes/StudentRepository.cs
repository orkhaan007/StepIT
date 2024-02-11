using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class StudentRepository<T> : BaseRepository<Student>, IStudentRepository
{
    public string GetFullName(int studentId)
    {
        var student = GetById(studentId);
        if (student != null)
        {
            return $"{student.FirstName} {student.LastName}";
        }
        return null;
    }

    public int GetStudentCountByGroupId(int groupId)
    {
        return _context.Students.Count(s => s.Id_Group == groupId);
    }

    public IEnumerable<Student> GetStudentsByGroupId(int groupId)
    {
        return _context.Students.Where(s => s.Id_Group == groupId).ToList();
    }
}
