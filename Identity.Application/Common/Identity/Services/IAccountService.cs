using Identity.Application.Common.Identity.Models;
using Identity.Domain.Entities;

namespace Identity.Application.Common.Identity.Services;

public interface IAccountService
{
    ValueTask<User> CreateAsync(User user);

    ValueTask<bool> VerificateAsync(string token);

    ValueTask<bool> MarkEmailAsVerified(Guid userId);

    ValueTask<User> GetUserByUsername(string username);
}