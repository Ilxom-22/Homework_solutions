﻿using BlogSite.Domain.Common;

namespace BlogSite.Domain.Entities;

public class User : IEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string EmailAddress { get; set; } = default!;

    public string PasswordHash { get; set; } = default!;    

    public bool IsEmailAddressVerified { get; set; }

    public Guid RoleId { get; set; }

    public virtual Role Role { get; set; }
}