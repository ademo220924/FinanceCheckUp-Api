using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Bultens.Command.Create;

public class BultenCreateCommandHandle(IBultenRepository bultenRepository) : IRequestHandler<BultenCreateCommand, GenericResult<BultenCreateResponse>>
{
    public async Task<GenericResult<BultenCreateResponse>> Handle(BultenCreateCommand request, CancellationToken cancellationToken)
    {
        var ide = 0;
 
        var bulten = new Bulten
        {
            Title = request.Title,
            SubTitle = request.SubTitle,
            Kapsam = request.Kapsam,
            YururlulukTarih = request.YururlulukTarih,
            DuzenleyenKurum = request.DuzenleyenKurum,
            Description = request.Description,
            CreatedUser = request.CreatedUser,
            CreatedDate = request.CreatedDate
        };

        await bultenRepository.AddAsync(bulten, cancellationToken);
        ide = bulten.Id;

        return await Task.FromResult(GenericResult<BultenCreateResponse>.Success(new BultenCreateResponse { Id = ide }));
    }
}