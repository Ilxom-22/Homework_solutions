using Order_Task;
using Newtonsoft.Json;

var random = new Random();

List<User> userList = new List<User>
{
    new User("John"),
    new User("Alice"),
    new User("Bob"),
    new User("Eva"),
    new User("Mike")
};

List<Product> productList = new List<Product>
{
    new Product("Widget", 19.99m),
    new Product("Gadget", 29.99m),
    new Product("Tool", 39.99m),
    new Product("Toy", 9.99m),
    new Product("Book", 14.99m)
};

var ordersList = new List<Order>();

for (int i = 0; i < 10; i++)
{
    var amount = random.Next(10);
    var id = userList[random.Next(productList.Count)].Id;

    ordersList.Add(new Order(amount, id));
}

var orderProductList = new List<OrderProduct>();

for (int i = 0; i < 10; i++)
{
    var productId = productList[random.Next(productList.Count)].Id;
    var orderId = ordersList[random.Next(ordersList.Count)].Id;

    orderProductList.Add(new OrderProduct(productId, orderId));
}

var userId = userList[4].Id;

var query =
    from user in userList
    join orders in ordersList on user.Id equals orders.UserId
    join orderProduct in orderProductList on orders.Id equals orderProduct.OrderId
    join product in productList on orderProduct.ProductId equals product.Id
    group product.Name by user into groupedProducts
    where groupedProducts.Key.Id == userId
    select new
    {
        FirstName = groupedProducts.Key.FirstName,
        Products = groupedProducts.Distinct().ToList()
    };

var result = JsonConvert.SerializeObject(query.ToList(), Formatting.Indented);
Console.WriteLine(result);