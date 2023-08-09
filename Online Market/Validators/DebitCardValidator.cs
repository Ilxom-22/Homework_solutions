using System.Text.RegularExpressions;

public static class DebitCardValidator
{
    public static bool ValidCardNumber(string cardNumber)
    {
        // checks if card number contains only numbers and the length is exactly 16 numbers.
        var pattern = @"^\d{16}$"; 
        return Regex.IsMatch(cardNumber, pattern);
    }



    public static bool ValidBankName(string bankName)
    {
        // Contains only letters and whitespaces. Restricts consecutive whitespaces and the min length should be 3 characters
        // and the max length should not be over 30.

        var pattern = @"^(?!.*\s{2,})[A-Za-z][A-Za-z\s]{1,28}[A-Za-z]$";
        return Regex.IsMatch(bankName, pattern);
    }
}
