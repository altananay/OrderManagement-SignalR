using Application.Facade;
using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs;

public class SignalRHub: Hub
{
    private readonly EntityServices _entityServices;

    public SignalRHub(EntityServices entityServices)
    {
        _entityServices = entityServices;
    }

    public async Task SendCategoryCount()
    {
        var value = _entityServices._categoryService.GetCategoryCount();
        await Clients.All.SendAsync("ReceiveCategoryCount", value);
    }

    public async Task SendProductCount()
    {
        var value = _entityServices._productService.GetProductCount();
        await Clients.All.SendAsync("ReceiveProductCount", value);
    }

    public async Task SendActiveCategoryCount()
    {
        var value = _entityServices._categoryService.GetActiveCategoryCount();
        await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
    }

    public async Task SendPassiveCategoryCount()
    {
        var value = _entityServices._categoryService.GetPassiveCategoryCount();
        await Clients.All.SendAsync("ReceivePassiveCategoryCount", value);
    }

    public async Task SendProductCountByCategoryNameHamburger()
    {
        var value = _entityServices._productService.GetProductCountByCategoryNameHamburger();
        await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value);
    }

    public async Task SendProductCountByCategoryNameDrink()
    {
        var value = _entityServices._productService.GetProductCountByCategoryNameDrink();
        await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value);
    }

    public async Task SendProductPriceAverage()
    {
        var value = _entityServices._productService.GetProductPriceAverageForSignalR();
        await Clients.All.SendAsync("ReceiveProductPriceAverage", value.ToString("0.00") + "₺");
    }

    public async Task SendProductWithHighestPrice()
    {
        var value = _entityServices._productService.GetProductNameByMaxPriceForSignalR();
        await Clients.All.SendAsync("ReceiveProductWithHighestPrice", value);
    }
}