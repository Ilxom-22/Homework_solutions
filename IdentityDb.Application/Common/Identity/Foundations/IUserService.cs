﻿using IdentityDb.Domain.Entities;
using System.Linq.Expressions;

namespace IdentityDb.Application.Common.Identity.Foundations;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);
}