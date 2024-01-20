using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class SliderManager(ISliderRepository _repository) : ISliderService
{
    public async Task<Slider> AddAsync(Slider entity)
    {
       return await _repository.AddAsync(entity);
    }

    public void Delete(Slider entity)
    {
        _repository.Delete(entity);
    }

    public async Task<List<Slider>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Slider> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public void Update(Slider entity)
    {
        _repository.Update(entity);
    }
}