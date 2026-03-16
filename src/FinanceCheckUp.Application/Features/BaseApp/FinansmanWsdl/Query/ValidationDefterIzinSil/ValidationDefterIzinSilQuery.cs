using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinSil;

public class ValidationDefterIzinSilQuery : IRequest<FinansmanEntegrasyonResponse>
{
    public FinansmanEntegrasyonRequest FinansmanEntegrasyonRequest { get; set; }
}