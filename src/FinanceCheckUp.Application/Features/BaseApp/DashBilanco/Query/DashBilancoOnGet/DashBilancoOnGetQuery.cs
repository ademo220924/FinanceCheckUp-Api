using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.DashBilanco;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashBilanco.Query.DashBilancoOnGet;
public class DashBilancoOnGetQuery : IUserIdAssignable , IRequest<GenericResult<DashBilancoOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}