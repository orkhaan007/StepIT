using Microsoft.EntityFrameworkCore;
using PracticsDataAccess.Contexts;
using PracticsDataAccess.Repositories.Abstracts;
using PracticsDomainLayer.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticsDataAccess.Repositories.Concretes;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    protected readonly DebtorContext _context;
    protected readonly DbSet<T> _table;

    public BaseRepository()
    {
        _context = new DebtorContext();
        _table = _context.Set<T>();
    }

    public void Add(T entity)
    {
        if (entity is null) throw new ArgumentNullException("NULL");
        _table.Add(entity);
    }

    public ICollection<T>? GetAll()
    {
        return _table.ToList();
    }

    public T? GetById(int id)
    {
        if (id <= 0) throw new ArgumentException("NULL");
        return _context?.Set<T>().FirstOrDefault(a => a.Id == id);
    }

    public void Remove(T entity)
    {
        if (entity is null) throw new ArgumentNullException("NULL");
        var aut = _context?.Set<T>().FirstOrDefault(a => a.Id == entity.Id);
        if (aut is null) throw new ArgumentNullException("NULL");

        _context?.Set<T>().Remove(aut);
    }

    public void Remove(int id)
    {
        if (id <= 0) throw new ArgumentNullException("NULL");
        var aut = _context?.Set<T>().FirstOrDefault(a => a.Id == id);
        if (aut is null) throw new ArgumentNullException("NULL");

        _context?.Set<T>().Remove(aut);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        if (entity is null) throw new ArgumentNullException("NULL");
        _context?.Set<T>().Update(entity);
    }
}
