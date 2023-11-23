namespace EfCore.Interceptors.Domain.Entities;

public class User
{
    public string FirstName { get; set; } = default!;

    public Guid? DeletedByUserId { get; set; }

    public Guid? ModifiedByUserId { get; set; }
}