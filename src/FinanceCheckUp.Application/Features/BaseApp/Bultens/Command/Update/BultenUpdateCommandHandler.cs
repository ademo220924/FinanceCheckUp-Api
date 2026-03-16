using FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Create;
using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Update;

public class BultenUpdateCommandHandle(IBultenRepository bultenRepository)
    : IRequestHandler<BultenUpdateCommand, GenericResult<BultenUpdateResponse>>
{
    public async Task<GenericResult<BultenUpdateResponse>> Handle(BultenUpdateCommand request,
        CancellationToken cancellationToken)
    {
        int ide = 0;

        //var currentUser = int.Parse(request.UserId);
        if (request.Id > 0)
        {
            var updated = await bultenRepository.UpdateAsync(new Bulten
            {
                Title = request.Title,
                SubTitle = request.SubTitle,
                Kapsam = request.Kapsam,
                YururlulukTarih = request.YururlulukTarih,
                DuzenleyenKurum = request.DuzenleyenKurum,
                Description = request.Description,
                CreatedUser = request.CreatedUser,
                CreatedDate = request.CreatedDate
            }, cancellationToken);

            ide = updated ? request.Id : 0;
        }

        return await Task.FromResult(GenericResult<BultenUpdateResponse>.Success(new BultenUpdateResponse { Id = ide }));
    }
}