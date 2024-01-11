using Domain.Entities;

namespace Application.Repositories;

public interface IMoneyCaseRepository : IGenericDal<MoneyCase>
{
    decimal GetTotalAmountFromMoneyCaseForSignalR();
    Task<decimal> GetTotalAmountFromMoneyCase();
}