using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager;


public interface IUserTypeManager : IGenericDapperRepository
{
    public List<UserType> Get_Types();

    public UserType Get_Types(int id);
}

public class UserTypeManager(FinanceCheckUpDbContext _dbContext) : GenericDapperRepositoryBase(_dbContext), IUserTypeManager
{
    public List<UserType> Get_Types()
    {
        return StaticQuery<UserType>("Select * From   [dbo].[UserType]").ToList();
    }

    public UserType Get_Types(int id)
    {
        return StaticQuery<UserType>("Select * From   [dbo].[UserType] where ID=@ide", new { ide = id }).FirstOrDefault();
    }
}
