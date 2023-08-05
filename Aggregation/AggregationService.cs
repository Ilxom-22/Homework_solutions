public static class AggregationService
{
    public static int Sum(params int[] values)
    {
        int sum = 0;
        foreach (var value in values)
            sum += value;

        return sum;
    }



    public static double Average(params int[] values)
    {
        return Math.Round((double)Sum(values) / values.Length, 2);
    }




    public static int Min(params int[] values)
    {
        var min = int.MaxValue;

        foreach (var value in values)
            if (value < min)
                min = value;

        return min;
    }




    public static int Max(params int[] values)
    {
        var max = int.MinValue;

        foreach (var value in values)
            if (value > max)
                max = value;

        return max;
    }




    public static void Increment(ref int value)
    {
        if (value < int.MaxValue)
            value++;
    }



    public static void Decrement(ref int value)
    {
        if (value > int.MinValue)
            value--;
    }
}