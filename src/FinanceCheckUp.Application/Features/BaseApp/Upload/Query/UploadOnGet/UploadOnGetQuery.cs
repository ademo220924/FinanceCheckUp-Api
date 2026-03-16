using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Text.Json.Serialization;


namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGet;
public class UploadOnGetQuery : IUserIdAssignable , IRequest<GenericResult<UploadOnGetResponse>>
{

    [JsonIgnore] public  string UserId { get; set; }

}