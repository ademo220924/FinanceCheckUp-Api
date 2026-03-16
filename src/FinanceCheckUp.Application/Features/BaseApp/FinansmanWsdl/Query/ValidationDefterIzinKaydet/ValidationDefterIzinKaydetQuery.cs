using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationDefterIzinKaydet;

public class ValidationDefterIzinKaydetQuery : IRequest<FinansmanEntegrasyonResponse>
{
    public FinansmanEntegrasyonRequest FinansmanEntegrasyonRequest { get; set; }
}