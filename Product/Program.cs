using Product.Models;
using Product.Services;


var productService = new ProductService();
var paymentService = new PaymentService();

var orderService = new OrderService(paymentService, productService);

var card = new DebitCard("7538239812844823", 5000);


// Products
List<IProduct> products = new List<IProduct>()
{
    new Monitors(1, "Monitor 1", "A high-quality monitor", 299.99, 27.0, 144),
    new Monitors(2, "Monitor 2", "Affordable display", 159.99, 24.0, 60),
    new Monitors(3, "Monitor 3", "Professional-grade monitor", 599.99, 32.0, 240),
    new Chair(4, "Ergonomic Chair", "Supportive and comfortable", 199.99, 250, "Mesh"),
    new Chair(5, "Executive Chair", "Luxurious design", 299.99, 300, "Leather"),
    new Chair(6, "Student Chair", "Compact and lightweight", 79.99, 150, "Plastic"),
    new Laptop(7, "Performance Laptop", "High-end computing power", 1299.99, "Intel", "Core i7"),
    new Laptop(8, "Gaming Laptop", "Designed for gaming enthusiasts", 1999.99, "AMD", "Ryzen 9"),
    new Laptop(9, "Budget Laptop", "Affordable computing solution", 599.99, "Intel", "Pentium Gold"),   
    new Laptop(10, "Convertible Laptop", "Flexible 2-in-1 design", 899.99, "Intel", "Core i5")
};


foreach (var product in products)
    productService.Add(product);

var catalog = productService.GetFilterDate();
catalog.ProductTypes.ForEach(Console.WriteLine);

Console.WriteLine($"Order Laptop: {orderService.Order(8, card)}");

var filterModel = new ProductFilterModel(null, "Monitors");
Console.WriteLine($"Order multiple monitors: {orderService.Order(filterModel, card)}");