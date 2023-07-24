namespace Shopping;

public class ShoppingCart
{
    private readonly Dictionary<Product, int> _items = new();



    public void Add(Product product)
    {
        if (_items.ContainsKey(product))
            _items[product]++;
        
        else
            _items.Add(product, 1);
    }



    public bool Remove(Product product)
    {
        if (!_items.ContainsKey(product)) return false;

        if (_items[product] > 1)
            _items[product]--;
        else
            _items.Remove(product);

        return true;
    }



    public void Check()
    {
        foreach (var item in _items)
            Console.WriteLine($"{item.Key} - {item.Value}");
    }
}