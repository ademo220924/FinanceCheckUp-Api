using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Company.Command.Update;

public class CompanyUpdateCommand : IRequest<GenericResult<CompanyUpdateResponse>>
{
    public CompanyUpdateRequest CompanyUpdateRequest { get; set; }
}