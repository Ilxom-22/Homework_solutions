using System.Text.RegularExpressions;

public static class ProductValidator
{
    public static bool ValidName(string productName)
    {
        var pattern = @"^(?=[A-Za-z0-9\s\-.,&()/'""]{3,100}$)(?!.*\s{2,})(?=.*[A-Za-z])[A-Za-z][A-Za-z0-9\s\-.,&()/'""]*[A-Za-z0-9]$";
        return Regex.IsMatch(productName, pattern);
    }



    public static bool ValidPrice(decimal price)
    {
        return (price > 0);
    }
}

