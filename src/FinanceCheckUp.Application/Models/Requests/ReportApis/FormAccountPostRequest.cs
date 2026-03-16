using FinanceCheckUp.Application.Models.Responses.ReportApis;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Models.Requests.ReportApis;

public class FormAccountPostRequest : IRequest<GenericResult<FormAccountPostResponse>>
{

}