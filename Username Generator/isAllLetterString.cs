namespace Username_Generator
{
    public static class isAllLetterString
    {
        public static bool isAllLetter(this string s)
        {
            foreach (char letter in s)
            {
                if (!char.IsLetter(letter))
                    return false;
            }
            return true;
        }
    }
}
