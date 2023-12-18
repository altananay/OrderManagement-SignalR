namespace Application.Repositories;

public interface IGenericDal<T> where T : class
{
    void Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    T GetById(Guid id);
    Task<List<T>> GetAll();
}