using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class MessageManager(IMessageRepository repository) : IMessageService
{
    public async Task<Message> AddAsync(Message entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Message entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Message>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Message> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Message entity)
    {
        repository.Update(entity);
    }
}