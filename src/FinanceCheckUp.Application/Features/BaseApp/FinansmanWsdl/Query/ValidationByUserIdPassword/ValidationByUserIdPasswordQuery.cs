using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationByUserIdPassword;

public class ValidationByUserIdPasswordQuery : IRequest<FinansmanEntegrasyonResponse>
{
    public FinansmanEntegrasyonRequest FinansmanEntegrasyonRequest { get; set; }
}