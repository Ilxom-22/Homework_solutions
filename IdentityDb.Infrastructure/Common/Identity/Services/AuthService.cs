using AutoMapper;
using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Application.Common.Identity.Models;
using IdentityDb.Application.Common.Identity.Services;
using IdentityDb.Domain.Constants;
using IdentityDb.Domain.Entities;

namespace IdentityDb.Infrastructure.Common.Identity.Services;

public class AuthService : IAuthService
{
    private readonly IAccountService _accountService;
    private readonly IAccessTokenGeneratorService _accessTokenGeneratorService;
    private readonly IPasswordHasherService _passwordHasherService;
    private readonly IMapper _mapper;
    private readonly IRoleService _roleService;
    private readonly IUserService _userService;

    public AuthService(
        IAccountService accountService, 
        IMapper mapper, 
        IAccessTokenGeneratorService accessTokenGeneratorService,
        IPasswordHasherService passwordHasherService,
        IRoleService roleService,
        IUserService userService
    )
    {
        _accountService = accountService;
        _mapper = mapper;
        _accessTokenGeneratorService = accessTokenGeneratorService;
        _passwordHasherService = passwordHasherService;
        _roleService = roleService;
        _userService = userService;
    }

    public async ValueTask<bool> SignUpAsync(
        SignUpDetails signUpDetails, 
        CancellationToken cancellationToken = default
    )
    {
        var user = _mapper.Map<User>(signUpDetails);
        user.PasswordHash = _passwordHasherService.HashPassword(signUpDetails.Password);

        var defaultRole = await _roleService.GetByTypeAsync(RoleType.Guest, true, cancellationToken)
            ?? throw new InvalidOperationException("Role of this type does not exist!");

        user.RoleId = defaultRole.Id;

        return await _accountService.CreateUserAsync(user, cancellationToken: cancellationToken);
    }

    public async ValueTask<string> SignInAsync(
        SignInDetails signInDetails, 
        CancellationToken cancellationToken = default
    )
    {
        var foundUser = await _accountService.GetUserByEmailAddress(signInDetails.EmailAddress) 
            ?? throw new InvalidOperationException();

        if (!_passwordHasherService.VerifyPassword(signInDetails.Password, foundUser.PasswordHash))
            throw new InvalidOperationException();

        var token = _accessTokenGeneratorService.GetToken(foundUser);

        return token;
    }

    public async ValueTask<bool> GrantRole(
        Guid userId, 
        string roleType,
        Guid actionUserId, 
        CancellationToken cancellationToken = default
    )
    {
        var user = await _userService.GetByIdAsync(userId, cancellationToken: cancellationToken) 
            ?? throw new InvalidOperationException();

        _ = await _userService.GetByIdAsync(actionUserId, true, cancellationToken)
            ?? throw new InvalidOperationException();

        if (!Enum.TryParse(roleType, out RoleType type))
            throw new InvalidOperationException();

        var role = await _roleService.GetByTypeAsync(type, true, cancellationToken) 
            ?? throw new InvalidOperationException();

        user.RoleId = role.Id;

        await _userService.UpdateAsync(user, cancellationToken: cancellationToken);

        return true;
    }
}