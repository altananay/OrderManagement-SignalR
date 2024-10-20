﻿using Application.Abstractions;
using Application.Aspects;
using Application.Repositories;
using Application.Validations.Validators;
using Domain.Entities;

namespace Persistence.Concretes;

public class BookingManager(IBookingRepository repository) : IBookingService
{
    [ValidationAspect(typeof(CreateBookingValidator))]
    public async Task<Booking> AddAsync(Booking entity)
    {
        return await repository.AddAsync(entity);
    }

    public void Delete(Booking entity)
    {
        repository.Delete(entity);
    }

    public List<Booking> GetAll()
    {
        return repository.GetAll();
    }

    public async Task<List<Booking>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<Booking> GetByIdAsync(Guid id)
    {
        return await repository.GetByIdAsync(id);
    }

    public void Update(Booking entity)
    {
        repository.Update(entity);
    }

    public async Task BookingStatusApproved(Guid id)
    {
        await repository.BookingStatusApproved(id);
    }

    public void BookingStatusCancelled(Guid id)
    {
        repository.BookingStatusCancelled(id);
    }
}