using Identity.Domain.Entities;
using Identity.Application.Foundations;
using Identity.Persistence.DataContext;
using System.Linq.Expressions;

namespace Identity.Infrastructure.Foundations;

public class VerificationCodeService : IEntityBaseService<VerificationCode>
{
    private readonly IDataContext _appDataContext;

    public VerificationCodeService(IDataContext appDataContext)
        => _appDataContext = appDataContext;

    public IQueryable<VerificationCode> Get(Expression<Func<VerificationCode, bool>> predicate)
        => _appDataContext.VerificationCodes.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<VerificationCode> GetByIdAsync(Guid id)
        => await _appDataContext.VerificationCodes.FindAsync(id) ?? throw new ArgumentException("Invalid Verifcation Code ID");

    public async ValueTask<VerificationCode> CreateAsync(VerificationCode code)
    {
        await _appDataContext.VerificationCodes.AddAsync(code);

        await _appDataContext.SaveChangesAsync();

        return code;
    }

    // Non-Updatable Entity
    public ValueTask<VerificationCode> UpdateAsync(VerificationCode entity)
        => throw new InvalidOperationException();   
}