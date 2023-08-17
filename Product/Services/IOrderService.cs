using Product.Models;

namespace Product.Services;

internal interface IOrderService
{
    bool Order(int id, DebitCard card);
    bool Order(ProductFilterModel model, DebitCard card);
}
