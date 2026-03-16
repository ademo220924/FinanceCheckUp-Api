using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.General.TblZoneError.Command.CreateOrUpdate;

public class TblZoneErrorCreateOrUpdateCommand : IRequest<GenericResult<TblZoneErrorCreateOrUpdateResponse>>
{
    public DataViewerError DataViewerError { get; set; }
}