using Microsoft.EntityFrameworkCore;
using Practics_DataAcsess.Contexts;
using Practics_DataAcsess.Repositories.Abstracts;
using Practics_Model.Entities.Abstracts;
using Practics_Model.Entities.Concretes;
#nullable disable

namespace Practics_DataAcsess.Repositories.Concretes;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    internal readonly PracticsContext _context;
    internal readonly DbSet<T> _table;

    public BaseRepository()
    {
        _context = new PracticsContext();
        _table = _context.Set<T>();
    }

    public void Add(T entity)
    {
        if (entity is null) throw new ArgumentNullException("Author is NULL");
        _table.Add(entity);
    }

    public ICollection<T>? GetAll()
    {
        return _table.ToList();
    }

    public T? GetById(int id)
    {
        if (id <= 0) throw new ArgumentException("Id is not valid");
        return _context?.Set<T>().FirstOrDefault(a => a.Id == id);
    }

    public void Remove(T entity)
    {
        if (entity is null) throw new ArgumentNullException("Author is NULL");
        var aut = _context?.Set<T>().FirstOrDefault(a => a.Id == entity.Id);
        if (aut is null) throw new ArgumentNullException("Author is NULL");

        _context?.Set<T>().Remove(aut);
    }

    public void Remove(int id)
    {
        if (id <= 0) throw new ArgumentNullException("Author is NULL");
        var aut = _context?.Set<T>().FirstOrDefault(a => a.Id == id);
        if (aut is null) throw new ArgumentNullException("Author is NULL");

        _context?.Set<T>().Remove(aut);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity is null) throw new ArgumentNullException("Author is NULL");
        _context?.Set<T>().Update(entity);
    }
}
