using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;

namespace FinanceCheckUp.Application.Repository;

public class UserCompanyRepository(
    FinanceCheckUpDbContext dbContext, 
    ICompanyManager companyManager,
    IUserCompanyManager userCompanyManager) : GenericBaseRepository<UserCompany, long>(dbContext), IUserCompanyRepository
{
    public bool UserCompanyDefinition(long userId, IReadOnlyCollection<long> companyList, CancellationToken cancellationToken)
    {
        var userCompanies = companyManager.Getby_User(userId);
        var existingCompanyIds = userCompanies.Select(c => c.Id).ToList();
        var newCompanies = companyList.Except(existingCompanyIds).ToList();
        var nonCompanies = existingCompanyIds.Except(companyList).ToList();

        if (companyList.Count != 0 && userId > 0 && (newCompanies.Count != 0 || nonCompanies.Count != 0))
        {
            var deletedUserCompanies = userCompanyManager.DeleteUser(userId.ToString());

            var newUserCompanies = companyList.Select(c => new UserCompany { CompanyId = c, UserId = (int)userId, IsDefault = 0 }).ToList();
            newUserCompanies.FirstOrDefault()!.IsDefault = 1;

            foreach (var newUserCompany in newUserCompanies)
            {
                var created = userCompanyManager.Save_User(newUserCompany);
                if (created == 0)
                    throw new CreateOperationException(nameof(UserCompany), nameof(newUserCompanies));
            }
        }

        return true;
    }
}
