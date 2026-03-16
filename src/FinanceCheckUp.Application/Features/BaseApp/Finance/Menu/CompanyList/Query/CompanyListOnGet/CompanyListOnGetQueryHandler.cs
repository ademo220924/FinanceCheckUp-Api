using FinanceCheckUp.Application.Models.Requests.Finance.Menu.CompanyList;
using FinanceCheckUp.Application.Models.Responses.Finance.Menu.CompanyList;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Domain.Entities;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Menu.CompanyList.Query.CompanyListOnGet;

public class CompanyListOnGetQueryHandler(IHhvnUsersManager hhvnUsersManager, ICompanyManager companiesManager, IUserTypeManager userTypeManager, ICompanyManager companyManager, ITBLXmlManager tBLXmlManager) : IRequestHandler<CompanyListOnGetQuery, GenericResult<CompanyListOnGetResponse>>
{
 

    public Task<GenericResult<CompanyListOnGetResponse>> Handle(CompanyListOnGetQuery request, CancellationToken cancellationToken)
    {
        var redirectUrl = string.Empty;
        var userId = Convert.ToInt64(request.UserId);
        var responseModel = new CompanyListInitialModel
        {
            UserID = userId,
            mreqList = companyManager.Getby_User(userId)
        };
        
        responseModel.mreqList = new List<Domain.Entities.Company>();
        responseModel.CurrentUser = hhvnUsersManager.GetRow_User(userId);
        responseModel.UserTypeID = responseModel.CurrentUser.UserTypeID;
        if (responseModel.CurrentUser.UserTypeID == 1001)
        {
            responseModel.mreqList = companyManager.Get_All();
        }
        else if (responseModel.CurrentUser.UserTypeID is 4 or 1 or 1005)
        {
            responseModel.mreqList = companyManager.Getby_User(userId);
        }
        else
        {
            redirectUrl="/logout?handler=logout";
        }
        
        return Task.FromResult(GenericResult<CompanyListOnGetResponse>.Success(
            new CompanyListOnGetResponse
            {
                InitialModel = responseModel,
                RedirecrUrl = redirectUrl
            }));
    }
}
