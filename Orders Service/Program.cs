var orders = new OrderManagementService();

orders.Add(100);
orders.Add(154);
orders.Add(2422);
orders.Add(12);
orders.Add(234);

Console.WriteLine($"Max: {orders.Max()}");
Console.WriteLine($"Min: {orders.Min()}");
Console.WriteLine($"Sum: {orders.Sum()}");
Console.WriteLine();

Console.WriteLine($"Sum: {orders.Sum()}");
Console.WriteLine($"Min: {orders.Min()}");
Console.WriteLine();

orders.Add(624);
orders.Add(11);

Console.WriteLine($"Max: {orders.Max()}");
Console.WriteLine($"Min: {orders.Min()}");
Console.WriteLine($"Sum: {orders.Sum()}");
Console.WriteLine();

Console.WriteLine($"Max: {orders.Max()}");



