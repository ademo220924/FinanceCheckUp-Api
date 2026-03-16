using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Company.Command.Create;

public class CompanyCreateCommand : IRequest<GenericResult<CompanyCreateResponse>>
{
    public CompanyCreateRequest CompanyCreateRequest { get; set; }
}