using Application.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories.Base;

public class GenericRepository<T>(SignalRContext _context) : IGenericDal<T> where T : class
{
    public void Add(T entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Remove(entity);
        _context.SaveChanges();
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T GetById(Guid id)
    {
        return _context.Set<T>().Find(id);
    }

    public void Update(T entity)
    {
        _context.Update(entity);
        _context.SaveChanges();
    }
}