using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.DashRasyo;
using FinanceCheckUp.Application.Models.Responses.DashRasyo;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.DashRasyo.Query.DashRasyoOnGetDashRasyo;
public class DashRasyoOnGetDashRasyoQuery : IUserIdAssignable , IRequest<GenericResult<DashRasyoOnGetDashRasyoResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public DashRasyoOnGetDashRasyoRequest Request { get; set; }

}