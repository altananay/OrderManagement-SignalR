using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class TestimonialManager(ITestimonialRepository repository) : ITestimonialService
{
    public async Task<Testimonial> AddAsync(Testimonial entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Testimonial entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Testimonial>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Testimonial> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Testimonial entity)
    {
        repository.Update(entity);
    }
}