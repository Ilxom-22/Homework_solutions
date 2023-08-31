namespace Product_Task;

public class ProductService
{
    private static ProductService? _instance;
    private List<Product> _products;

    private ProductService()
    {
        _products = new List<Product>();
    }

    public static ProductService GetInstance()
    {
        _instance ??= new ProductService();
        return _instance;
    }
    
    public Product Add(Product product)
    {
        _products.Add(product);
        return product;
    }

    public void Clone(Guid id)
    {
        var product = _products.FirstOrDefault(x => x.Id == id);
        if (product != null)
        {
            var newProduct = new Product(product);
            _products.Add(product);
        }
    }

    public void Display()
    {
        _products.ForEach(Console.WriteLine);
    }
}
