List<int> nums = new List<int>()
{
    322, -1, 11, 3, 6, 10
};


bool isAllPositive = nums.All(n => n > 0);
bool containsOdds = nums.Any(n => n % 2 == 1);
bool hasThreeAndNine = nums.Contains(3) && nums.Contains(9);

Console.WriteLine($"All Positive Numbers: {isAllPositive}");
Console.WriteLine($"Contains Odd Numbers: {containsOdds}");
Console.WriteLine($"Has 3 and 9:  {hasThreeAndNine}");