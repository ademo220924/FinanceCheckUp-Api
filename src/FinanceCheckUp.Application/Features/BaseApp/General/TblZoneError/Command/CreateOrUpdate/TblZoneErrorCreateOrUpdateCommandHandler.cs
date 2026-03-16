using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.General.TblZoneError.Command.CreateOrUpdate;

public class TblZoneErrorCreateOrUpdateCommandHandle(ITblerrzoneRepository tblErrorZoneRepository) : IRequestHandler<TblZoneErrorCreateOrUpdateCommand, GenericResult<TblZoneErrorCreateOrUpdateResponse>>
{


    public async Task<GenericResult<TblZoneErrorCreateOrUpdateResponse>> Handle(TblZoneErrorCreateOrUpdateCommand request, CancellationToken cancellationToken)
    {
        var resultModel = new TblZoneErrorCreateOrUpdateResponse();
        var entity = request.DataViewerError;

        entity.MainDescription = entity.MainDescription.Replace(" ", string.Empty);

        var model = new Tblerrzone
        {
            MainDescription = entity.MainDescription,
            ColorDesc = Convert.ToByte(entity.ColorDesc),
            Description = entity.Description,
            ColorDescTax = Convert.ToByte(entity.ColorDescTax),
            DescriptionTax = entity.DescriptionTax,
            ColorDescInside = Convert.ToByte(entity.ColorDescInside),
            DescriptionInside = entity.DescriptionInside
        };

        if (request.DataViewerError.Id == "0" || request.DataViewerError.Id == "null" || string.IsNullOrEmpty(request.DataViewerError.Id))
        {
            var created = await tblErrorZoneRepository.UpdateAsync(model, cancellationToken);
            if (!created)
                throw new CreateOperationException(nameof(Tblerrzone), resultModel.ResponseValue);
        }
        else
        {
            model.Id = Convert.ToInt32(entity.Id);

            var updated = await tblErrorZoneRepository.AddAsync(model, cancellationToken);
            if (!updated)
                throw new UpdateOperationException(nameof(Tblerrzone), resultModel.ResponseValue);
        }

        resultModel.ResponseValue = 1;
        return GenericResult<TblZoneErrorCreateOrUpdateResponse>.Success(resultModel);
    }
}