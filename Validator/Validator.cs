using System.Text.RegularExpressions;

namespace Validation;

public class Validator
{
    public static bool Age(string age)
    {
        byte realAge;

        if (!byte.TryParse(age, out realAge))
            return false;

        if (realAge >= 100)
            return false;

        return true;
    }



    public static bool FirstName(string name)
    {
        string pattern = @"^(?=.{2,40}$)(?!.*--)[A-Z][a-zA-Z-]*[A-Za-z]$";

        return Regex.IsMatch(name, pattern);
    }



    public static bool LastName(string lastName)
    {
        string pattern = @"^(?!.*(?:  |-|'| {2,}))[A-Z][A-Za-z-' ]{0,38}[A-Za-z]$";

        return Regex.IsMatch(lastName, pattern);
    }



    public static bool IsEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$";

        return Regex.IsMatch(email, pattern);
    }



    public static bool PhoneNumber(string phone)
    {
        string pattern = @"^\+998(90|91|50|93|94|95|97|88|98|77|78|99|33)\d{7}$";

        return Regex.IsMatch(phone, pattern);
    }
}