using Product.Models;

namespace Product.Services;

internal class ProductService : IProductService
{
    public List<IProduct> Inventory;

    public ProductService() => Inventory = new List<IProduct>();
    

    public void Add(IProduct product)
        => Inventory.Add(product); 
    

    public ProductFiterDataModel GetFilterDate()
        => new ProductFiterDataModel(Inventory); 

    public List<IProduct> Get(ProductFilterModel filterModel) 
        => Inventory
            .Where(product => (filterModel.Name is null || product.Name == filterModel.Name) 
                    && (filterModel.Type is null || product.GetType().Name.ToString() == filterModel.Type))
            .ToList();
    

    public IProduct Order(int productId)
    {
        var product = FindProduct(productId);
        product.IsOrdered = true;
        return product.Copy();
    }

    public IProduct Return(int productId)
    {
        var product = FindProduct(productId);
        product.IsOrdered = false;
        return product.Copy();
    }

    private IProduct FindProduct(int productId)
    {
        var product = Inventory.FirstOrDefault(item => item.Id == productId);
        if (product is null)
            throw new ArgumentException("Product Not Found!");

        return product;
    }
}
