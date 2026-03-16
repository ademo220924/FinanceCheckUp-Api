using FinanceCheckUp.Application.Dtos.BgServer;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Domain.Common.Utilities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Common.Query.GetEnumValues;

public class GetEnumValuesQueryHandler : IRequestHandler<GetEnumValuesQuery, GenericResult<List<CodeValueDto>>>
{
    public Task<GenericResult<List<CodeValueDto>>> Handle(GetEnumValuesQuery request, CancellationToken cancellationToken)
    {
        var dto = request.EnumTextName.Split('.').LastOrDefault() switch
        {
            "PaymentType" => EnumExtensions.GetEnumValues<PaymentType>().Select(c => new CodeValueDto(c.ToString(), (int)c)),
            "PeriodType" => EnumExtensions.GetEnumValues<PeriodType>().Select(c => new CodeValueDto(c.ToString(), (int)c)),
            "ControlValueType" => EnumExtensions.GetEnumValues<ControlValueType>().Select(c => new CodeValueDto(c.ToString(), (int)c)),
            "AccountType" => EnumExtensions.GetEnumValues<AccountType>().Select(c => new CodeValueDto(c.ToString(), (int)c)),
            _ => new List<CodeValueDto>()
        };
        return Task.FromResult(GenericResult<List<CodeValueDto>>.Success(dto.ToList()));
    }
}