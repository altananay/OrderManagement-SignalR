using Domain.Entities;

namespace Application.Repositories;

public interface IMoneyCaseRepository : IGenericRepository<MoneyCase>
{
    decimal GetTotalAmountFromMoneyCaseForSignalR();
    Task<decimal> GetTotalAmountFromMoneyCase();
}