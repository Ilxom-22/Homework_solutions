using System.Text.RegularExpressions;

public static class Validator
{
    public static bool IsValidName(string name, out string formattedName)
    {
        var checker = new Regex("^[A-Za-z'-]{1,50}$");
        formattedName = name.Trim();

        if (checker.IsMatch(name))
            return true;

        
        if (checker.IsMatch(formattedName))
            return true;

        formattedName = null;
        return false;
    }



    public static bool IsValidEmail(string email, out string formattedEmail)
    {
        var checker = new Regex(@"^[a-zA-Z0-9.]+@[a-zA-Z0-9]+\.[a-zA-Z0-9]+$");
        formattedEmail = email.Trim();

        if (checker.IsMatch(email))
            return true;

        if (checker.IsMatch(formattedEmail))
            return true;

        formattedEmail = null;
        return false;
    }



    public static bool IsValidAge(in int age)
    {
        if (age < 0 || age > 120)
            return false;

        return true;
    }



    public static bool IsValidPhoneNumber(in string phoneNumber, out string formattedPhoneNumber)
    {
        var checker = new Regex(@"^\+998(90|91|50|93|94|95|97|88|98|77|78|99|33)\d{7}$");
        formattedPhoneNumber = phoneNumber.Trim();

        if (checker.IsMatch(phoneNumber))
            return true;

        if (checker.IsMatch(formattedPhoneNumber))
            return true;

        formattedPhoneNumber = null;
        return false;
    }
}