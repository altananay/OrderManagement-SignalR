namespace Application.Abstractions.Base;

public interface IGenericService<T> where T : class
{
    Task<T> AddAsync(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
}