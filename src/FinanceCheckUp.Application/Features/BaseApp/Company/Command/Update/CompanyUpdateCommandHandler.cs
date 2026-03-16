using FinanceCheckUp.Application.Models.Responses;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Infrastructure.Repository;
using MediatR;
namespace FinanceCheckUp.Application.Features.BaseApp.Company.Command.Update;

public class CompanyUpdateCommandHandle(ICompanyRepository companyRepository) : IRequestHandler<CompanyUpdateCommand, GenericResult<CompanyUpdateResponse>>
{
    public async Task<GenericResult<CompanyUpdateResponse>> Handle(CompanyUpdateCommand request, CancellationToken cancellationToken)
    {
        var model = request.CompanyUpdateRequest;
        var company = await companyRepository.GetAsync(c => c.Id.Equals(model.Id), cancellationToken);
        if (company == null)
            throw new NotFoundException(nameof(Domain.Entities.Company), model.Id.ToString());

        company.CompanyName = model.CompanyName;
        company.ContactName = model.ContactName;
        company.ContactMail = model.ContactMail;
        company.ContactGsm = model.ContactGsm;
        company.CityId = model.CityId;
        company.State = model.State;
        company.Adress = model.Address;
        company.TaxId = model.TaxId;
        company.TaxOffice = model.TaxOffice;
        company.Notes = model.Notes;
        company.XmlSourceId = model.XmlSourceId;
        company.NaceCode = model.NaceCode;

        var updated = await companyRepository.UpdateAsync(company, cancellationToken);
        if (!updated)
            throw new UpdateOperationException(nameof(Domain.Entities.Company), nameof(model));

        return GenericResult<CompanyUpdateResponse>.Success(new CompanyUpdateResponse { Id = company.Id });
    }
}