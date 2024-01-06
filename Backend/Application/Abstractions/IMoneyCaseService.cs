using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMoneyCaseService : IGenericService<MoneyCase>
{
    Task<decimal> GetTotalAmountFromMoneyCase();
}