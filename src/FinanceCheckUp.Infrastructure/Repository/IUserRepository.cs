using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceCheckUp.Infrastructure.Repository;

 

public interface IUserRepository : IGenericRepository<User, long>
{ }
