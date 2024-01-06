using Domain.Entities;

namespace Application.Repositories;

public interface IMoneyCaseRepository : IGenericDal<MoneyCase>
{
    Task<decimal> GetTotalAmountFromMoneyCase();
}