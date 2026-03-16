using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.General.TblWzone.Command.Create;

public class TblWzoneCreateCommand : IRequest<GenericResult<TblWzoneCreateResponse>>
{
    public DataViewerCheck DataViewerCheck { get; set; }
}