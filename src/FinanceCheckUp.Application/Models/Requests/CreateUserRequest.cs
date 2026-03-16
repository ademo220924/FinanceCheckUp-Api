using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanceCheckUp.Application.Models.Requests;

public class CreateUserRequest : HhvnUsers,IUserIdAssignable
{
    [JsonIgnore] public  string UserId { get; set; }
}
