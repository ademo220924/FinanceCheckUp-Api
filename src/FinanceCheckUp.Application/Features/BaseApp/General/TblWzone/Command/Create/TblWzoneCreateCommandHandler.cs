using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.General.TblWzone.Command.Create;

public class TblWzoneCreateCommandHandle(ITblwzoneRepository tblwzoneRepository) : IRequestHandler<TblWzoneCreateCommand, GenericResult<TblWzoneCreateResponse>>
{ 

    public async Task<GenericResult<TblWzoneCreateResponse>> Handle(TblWzoneCreateCommand request, CancellationToken cancellationToken)
    {
        var resultModel = new TblWzoneCreateResponse();
        var model = request.DataViewerCheck;
        var numxhwxk = model.MainDescription.Replace(" ", string.Empty);
        if (numxhwxk.Length > 3)
        {
            var nList = numxhwxk.Split(',').Select(x => Convert.ToInt32(x));
            var uniqueItems = nList.Distinct().OrderBy(x => x);
            var setChk = uniqueItems.Select(s => s.ToString()).ToList();
            model.MainDescription = string.Join(",", setChk);

            var entity = new Tblwzone
            {
                MainDescription = model.MainDescription,
                MainDescriptionId = Convert.ToInt32(model.DescriptionInfo)
            };

            var created = await tblwzoneRepository.AddAsync(entity, cancellationToken);
            if (!created)
                throw new CreateOperationException(nameof(Tblerrzone), resultModel.ResponseValue);

            resultModel.ResponseValue = "1";
            return GenericResult<TblWzoneCreateResponse>.Success(resultModel);
        }

        resultModel.ResponseValue = "Ok";
        return GenericResult<TblWzoneCreateResponse>.Success(resultModel);
    }
}