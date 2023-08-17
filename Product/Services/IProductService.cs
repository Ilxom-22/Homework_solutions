using Product.Models;

namespace Product.Services;

internal interface IProductService
{
    List<IProduct> Get(ProductFilterModel filterModel);
    IProduct Order(int productId);
    IProduct Return(int productId);
}
