using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class TeacherRepository<T> : BaseRepository<Teacher>, ITeacherRepository
{
    public string GetFullName(int teacherId)
    {
        var teacher = GetById(teacherId);
        if (teacher != null)
        {
            return $"{teacher.FirstName} {teacher.LastName}";
        }
        return null;
    }

    public int GetTeacherCountByDepartmentId(int departmentId)
    {
        return _context.Teachers.Count(t => t.Id_Dep == departmentId);
    }

    public IEnumerable<Teacher> GetTeachersByDepartmentId(int departmentId)
    {
        return _context.Teachers.Where(t => t.Id_Dep == departmentId).ToList();
    }
}
