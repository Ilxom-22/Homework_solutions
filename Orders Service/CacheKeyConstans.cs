public static class CacheKeyConstans
{
    public static string Sum(List<int> values) =>
        Convert.ToString(GetListElementsHash(values)) + "-sum";



    public static string Max(List<int> values) =>
        Convert.ToString(GetListElementsHash(values)) + "-max";



    public static string Min(List<int> values) =>
        Convert.ToString(GetListElementsHash(values)) + "-min";



    private static int GetListElementsHash(List<int> values)
    {
        var hash = 0;
        foreach (var value in values)
            hash += value;

        return hash.GetHashCode();
    }
}