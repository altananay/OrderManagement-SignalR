using Application.Abstractions;
using Application.Repositories;
using Domain.Entities;

namespace Persistence.Concretes;

public class TestimonialManager(ITestimonialRepository repository) : ITestimonialService
{
    public void Add(Testimonial entity)
    {
        repository.Add(entity);
    }

    public void Delete(Testimonial entity)
    {
        repository.Delete(entity);
    }

    public async Task<List<Testimonial>> GetAll()
    {
        return await repository.GetAll();
    }

    public Testimonial GetById(Guid id)
    {
        return repository.GetById(id);
    }

    public void Update(Testimonial entity)
    {
        repository.Update(entity);
    }
}