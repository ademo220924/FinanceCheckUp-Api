using FinanceCheckUp.Application.Models.Common;

namespace FinanceCheckUp.Application.Models.Requests;

public class CompanyUpdateRequest : CompanyRequest
{
    public long Id { get; set; }
}