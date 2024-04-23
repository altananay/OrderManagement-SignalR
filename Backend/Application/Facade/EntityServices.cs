using Application.Abstractions;

namespace Application.Facade;

public class EntityServices
{
    public readonly IProductService _productService;
    public readonly IOrderService _orderService;
    public readonly IOrderDetailService _orderDetailService;
    public readonly IMoneyCaseService _moneyCaseService;
    public readonly ICategoryService _categoryService;
    public readonly ITableService _tableService;
    public readonly IBookingService _bookingService;

    public EntityServices(IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService, IMoneyCaseService moneyCaseService, ICategoryService categoryService, ITableService tableService, IBookingService bookingService)
    {
        _productService = productService;
        _orderService = orderService;
        _orderDetailService = orderDetailService;
        _moneyCaseService = moneyCaseService;
        _categoryService = categoryService;
        _tableService = tableService;
        _bookingService = bookingService;

    }
}