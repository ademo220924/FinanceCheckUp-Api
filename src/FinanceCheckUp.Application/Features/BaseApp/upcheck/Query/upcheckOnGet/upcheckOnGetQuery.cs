using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.upcheck;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.upcheck.Query.upcheckOnGet;
public class upcheckOnGetQuery : IUserIdAssignable , IRequest<GenericResult<upcheckOnGetResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }

}