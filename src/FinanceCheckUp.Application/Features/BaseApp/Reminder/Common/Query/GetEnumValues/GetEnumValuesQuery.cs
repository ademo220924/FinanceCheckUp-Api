using FinanceCheckUp.Application.Dtos.BgServer;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Reminder.Common.Query.GetEnumValues;

public class GetEnumValuesQuery : IRequest<GenericResult<List<CodeValueDto>>>
{
    public string EnumTextName { get; set; }
}