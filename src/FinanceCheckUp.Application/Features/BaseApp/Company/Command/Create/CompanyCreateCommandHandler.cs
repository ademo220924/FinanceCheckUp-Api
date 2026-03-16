using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Company.Command.Create;

public class CompanyCreateCommandHandle(ICompanyRepository companyRepository) : IRequestHandler<CompanyCreateCommand, GenericResult<CompanyCreateResponse>>
{
    public async Task<GenericResult<CompanyCreateResponse>> Handle(CompanyCreateCommand request, CancellationToken cancellationToken)
    {
        var model = request.CompanyCreateRequest;
        var company = new Domain.Entities.Company
        {
            CompanyName = model.CompanyName,
            ContactName = model.ContactName,
            ContactMail = model.ContactMail,
            ContactGsm = model.ContactGsm,
            CityId = model.CityId,
            State = model.State,
            Adress = model.Address,
            TaxId = model.TaxId,
            TaxOffice = model.TaxOffice,
            Notes = model.Notes,
            XmlSourceId = model.XmlSourceId,
            NaceCode = model.NaceCode
        };

        var created = await companyRepository.AddAsync(company, cancellationToken);
        if (!created)
            throw new CreateOperationException(nameof(Domain.Entities.Company), nameof(model));

        return GenericResult<CompanyCreateResponse>.Success(new CompanyCreateResponse { Id = company.Id });
    }
}