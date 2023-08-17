using Product.Models;

namespace Product.Services;

internal class OrderService : IOrderService
{
    private IPaymentService _paymentService;
    private IProductService _productService;

    public OrderService(IPaymentService paymentService, IProductService productService)
    {
        _paymentService = paymentService;
        _productService = productService;
    }

    public bool Order(int id, DebitCard card)
    {
        var product = _productService.Order(id);
        if (product == null)
            return false;

        if (_paymentService.Checkout(product.Price, card))
            return true;

        _productService.Return(product.Id);
        return false;
    }

    public bool Order(ProductFilterModel model, DebitCard card) 
    {
        var products = _productService.Get(model);

        if (!products.Any())
            return false;
    
        foreach (var product in products)
        {
            if (!Order(product.Id, card))
                return false;
        }

        return true;
    }
}
