using FinanceCheckUp.Domain.Common;
using DevExtreme.AspNet.Mvc;
using FinanceCheckUp.Application.Models.Responses.DashCpmNew;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;

namespace FinanceCheckUp.Application.Features.BaseApp.DashCpmNew.Query.DashCpmNewOnGetCasino;
public class DashCpmNewOnGetCasinoQuery : IUserIdAssignable , IRequest<GenericResult<DashCpmNewOnGetCasinoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DataSourceLoadOptions Options { get; set; }

}