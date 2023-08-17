namespace Product.Models;

internal class ProductFiterDataModel
{
    public List<string> ProductTypes;

    public ProductFiterDataModel(List<IProduct> products)
    {
        ProductTypes = products.Select(item => item.GetType().Name).Distinct().ToList();
    }
}

