var numbers = new List<int> { 1, 2, 3, 4, 5 };

// Deferred
var query = numbers.Where(n => n % 2 == 0); 

foreach (var num in query)
    Console.WriteLine(num);


// Immediate
var immediateQuery = numbers.Where(n => n % 2 == 0).ToList();

// Mixed

var mixedQuery = numbers
    .Where(n => n % 2 == 0)  // Deferred execution, filtering is deferred
    .Select(n => n * 2)      // Immediate execution, projection is executed immediately
    .ToList();                  // Immediate execution