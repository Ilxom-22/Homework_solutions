namespace Shopping;

class Program
{
    static void Main(string[] args)
    {
        var milk = new Product("milk");
        var water = new Product("water");
        var meat = new Product("meat");

        var shoppingCart = new ShoppingCart();
        shoppingCart.Add(milk);
        shoppingCart.Add(milk);
        shoppingCart.Add(milk);
        shoppingCart.Add(water);
        shoppingCart.Add(water);
        shoppingCart.Add(water);
        shoppingCart.Add(water);
        shoppingCart.Add(water);
        shoppingCart.Add(meat);
        shoppingCart.Add(meat);

        shoppingCart.Check();
        Console.WriteLine();

        shoppingCart.Remove(milk);
        shoppingCart.Remove(water);
        shoppingCart.Remove(meat);

        shoppingCart.Check();

    }
}

