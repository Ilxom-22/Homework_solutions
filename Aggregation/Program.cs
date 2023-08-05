var array = new int[] { 12, 22, 55, 7, 20 };
Console.WriteLine($"Sum: {AggregationService.Sum(array)}");
Console.WriteLine($"Average: {AggregationService.Average(array)}");
Console.WriteLine($"Min: {AggregationService.Min(array)}");
Console.WriteLine($"Max: {AggregationService.Max(array)}");


var n1 = 6;
var n2 = int.MaxValue;
var n3 = -10;
var n4 = int.MinValue;

Console.Write($"Increment -> {n1} = ");
AggregationService.Increment(ref n1);
Console.WriteLine(n1);

Console.Write($"Increment -> {n2} = ");
AggregationService.Increment(ref n2);
Console.WriteLine(n2);

Console.Write($"Decrement -> {n3} = ");
AggregationService.Decrement(ref n3);
Console.WriteLine(n3);

Console.Write($"Decrement -> {n4} = ");
AggregationService.Decrement(ref n4);
Console.WriteLine(n4);