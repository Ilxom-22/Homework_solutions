namespace Filter_Model_Task.Models;

internal abstract class FilterModel
{
    public FilterModel(int pageSize, int pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }

    public int PageSize { get; set; }
    public int PageToken { get; set; }
}
