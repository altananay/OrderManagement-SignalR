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

    public async Task SendProductWithMinPrice()
    {
        var value = _entityServices._productService.GetProductNameByMinPriceForSignalR();
        await Clients.All.SendAsync("ReceiveProductWithMinPrice", value);
    }

    public async Task SendAverageHamburgerPrice()
    {
        var value = _entityServices._productService.GetAverageHamburgerPriceForSignalR();
        await Clients.All.SendAsync("ReceiveAverageHamburgerPrice", value);
    }

    public async Task SendOrderCount()
    {
        var value = _entityServices._orderService.GetOrderCountForSignalR();
        await Clients.All.SendAsync("ReceiveOrderCount", value);
    }

    public async Task SendActiveOrderCount()
    {
        var value = _entityServices._orderService.GetActiveOrderCountForSignalR();
        await Clients.All.SendAsync("ReceiveActiveOrderCount", value);
    }

    public async Task SendLastOrderPrice()
    {
        var value = _entityServices._orderService.GetLastOrderPriceForSignalR();
        await Clients.All.SendAsync("ReceiveLastOrderPrice", value.ToString("0.00") + "₺");
    }

    public async Task SendTotalAmountFromMoneyCase()
    {
        var value = _entityServices._moneyCaseService.GetTotalAmountFromMoneyCaseForSignalR();
        await Clients.All.SendAsync("ReceiveTotalAmountFromMoneyCase", value.ToString("0.00") + "₺");
    }

    public async Task SendTodayTotalPrice()
    {
        var value = _entityServices._orderService.GetTodayTotalPriceForSignalR();
        await Clients.All.SendAsync("ReceiveTodayTotalPrice", value.ToString("0.00") + "₺");
    }

    public async Task SendTableCount()
    {
        var value = _entityServices._tableService.GetTableCountForSignalR();
        await Clients.All.SendAsync("ReceiveTableCount", value);
    }

    public async Task GetBookingList()
    {
        var values = _entityServices._bookingService.GetAll();
        await Clients.All.SendAsync("ReceiveBookingList", values);
    }

    public async Task SendNotificationCountWithFalse()
    {
        var values = _entityServices._notificationService.GetNotificationCountWithStatusFalseForSignalR();
        await Clients.All.SendAsync("ReceiveNotificationCountWithFalse", values);
    }

    public async Task SendNotificationListWithFalse()
    {
        var values = _entityServices._notificationService.GetAllNotificationsWithFalse();
        await Clients.All.SendAsync("ReceiveNotificationListWithFalse", values);
    }
}