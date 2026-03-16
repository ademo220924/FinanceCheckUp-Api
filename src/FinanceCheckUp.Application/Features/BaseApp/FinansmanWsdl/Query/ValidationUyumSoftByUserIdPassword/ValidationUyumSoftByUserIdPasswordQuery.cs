using FinanceCheckUp.Application.Models.Requests;
using FinanceCheckUp.Application.Models.Responses;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.FinansmanWsdl.Query.ValidationUyumSoftByUserIdPassword;

public class ValidationUyumSoftByUserIdPasswordQuery : IRequest<FinansmanEntegrasyonResponse>
{
    public FinansmanEntegrasyonRequest FinansmanEntegrasyonRequest { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public int BranchId { get; set; } = default;
}