using FinanceCheckUp.Application.Models.Responses.Users;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Users.Query.GetTypes;

public class UserTypesQuery:IRequest<GenericResult< UserTypesResponse>>
{}