using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Requests.Upload;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerDate;
public class UploadOnGetSalerDateQuery : IUserIdAssignable , IRequest<GenericResult<UploadOnGetSalerDateResponse>>
{
    [JsonIgnore] public  string UserId { get; set; }
    public UploadOnGetSalerDateRequest Request { get; set; }

}