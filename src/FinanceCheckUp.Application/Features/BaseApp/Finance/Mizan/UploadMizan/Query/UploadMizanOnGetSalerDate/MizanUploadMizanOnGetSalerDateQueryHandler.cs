using DevExtreme.AspNet.Data;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.UploadMizan;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using System.Security.Claims;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.UploadMizan.Query.UploadMizanOnGetSalerDate
{
    public class MizanUploadMizanOnGetSalerDateQueryHandler(
        IMainDashManager mainDashManager,
        IUploadMainManager uploadMainManager,
        IHhvnUsersManager hhvnUsersManager,
        ICompanyManager companyManager)
        : IRequestHandler<MizanUploadMizanOnGetSalerDateQuery, GenericResult<MizanUploadMizanOnGetSalerDateResponse>>
    {
        public Task<GenericResult<MizanUploadMizanOnGetSalerDateResponse>> Handle(MizanUploadMizanOnGetSalerDateQuery request, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt64(request.UserId);
            request.InitialModel.UserID = (int)userId;
            request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User(request.InitialModel.UserID);

            request.InitialModel.curcomID = companyManager.Getby_User(request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;
            List<int> chkErrormonthID = mainDashManager.Get_DatabyError(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID).Where(x => x.TErrorRowCount == 0).Select(x => x.MainMonth).ToList();
            var currentUploadM = uploadMainManager.Get_Data(request.InitialModel.CurrentUser.SelectedYear, request.InitialModel.curcomID);

            currentUploadM = currentUploadM.Where(x => chkErrormonthID.Contains(x.MainMonth)).Select(c =>
            {
                c.ErrorCount = -1;
                return c;
            }).OrderBy(x => x.MainMonth).ToList();


                        return Task.FromResult(GenericResult<MizanUploadMizanOnGetSalerDateResponse>.Success(
                new MizanUploadMizanOnGetSalerDateResponse
                {
                    InitialModel = request.InitialModel,
                    Response = DataSourceLoader.Load(currentUploadM, request.Request.options)
                }));
        }
    }
}