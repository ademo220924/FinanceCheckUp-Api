namespace FinanceCheckUp.Infrastructure.Repository;

public interface IUserCompanyRepository
{
    bool UserCompanyDefinition(long userId, IReadOnlyCollection<long> companyList, CancellationToken cancellationToken);
}
