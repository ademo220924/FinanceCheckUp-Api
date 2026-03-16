using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetType;

public class UserTypeQuery:IRequest<GenericResult< UserTypeResponse>>
{
    public int Id { get; set; }
}