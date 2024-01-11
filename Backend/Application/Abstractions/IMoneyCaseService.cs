using Application.Abstractions.Base;
using Domain.Entities;

namespace Application.Abstractions;

public interface IMoneyCaseService : IGenericService<MoneyCase>
{
    decimal GetTotalAmountFromMoneyCaseForSignalR();
    Task<decimal> GetTotalAmountFromMoneyCase();
}