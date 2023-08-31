using Product_Task;


List<Product> products = new List<Product>
{
    new Product("Smartphone", "A high-end smartphone with advanced features."),
    new Product("Laptop", "Powerful laptop for gaming and productivity."),
    new Product("Headphones", "Noise-cancelling headphones with superb audio quality."),
    new Product("Fitness Tracker", "Track your daily activity and health metrics."),
    new Product("Coffee Machine", "Brew your favorite coffee with ease at home.")
};



var service = ProductService.GetInstance();

foreach (var product in products)
    service.Add(product);

service.Clone(products[0].Id);
service.Display();