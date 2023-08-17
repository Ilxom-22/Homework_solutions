namespace Filter_Model_Task.Models;

internal class UserFilterModel : FilterModel
{
    public UserFilterModel(string? firstName, string? lastName, int pageSize, int pageToken)
        : base(pageSize, pageToken)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
