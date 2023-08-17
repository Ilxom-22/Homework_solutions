using Product.Models;

namespace Product.Services;

internal class OrederService
{
    private PaymentService _paymentService;
    private ProductService _productService;

    public OrederService(PaymentService paymentService, ProductService productService)
    {
        _paymentService = paymentService;
        _productService = productService;
    }

    public void Order(int id, DebitCard card)
    {

    }

    public void Order(ProductFiterDataModel model, DebitCard card) 
    {
        
    }
}
