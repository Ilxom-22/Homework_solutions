using Product.Models;

namespace Product.Services;

internal class ProductService
{
    public List<IProduct> Inventory;



    public void Add(IProduct product)
    { 
        Inventory.Add(product); 
    }

    public void GetFilterDate()
    {

    }

    public void Get(ProductFiterDataModel filterModel)
    {

    }

    public void Order(int productId)
    {
        var product = FindProduct(productId);
        product.IsOrdered = true;
    }

    public void Return(int productId)
    {
        var product = FindProduct(productId);
        product.IsOrdered = false;
    }

    private IProduct FindProduct(int productId)
    {
        var product = Inventory.FirstOrDefault(item => item.Id == productId);
        if (product is null)
            throw new ArgumentException("Product Not Found!");

        return product;
    }
}
