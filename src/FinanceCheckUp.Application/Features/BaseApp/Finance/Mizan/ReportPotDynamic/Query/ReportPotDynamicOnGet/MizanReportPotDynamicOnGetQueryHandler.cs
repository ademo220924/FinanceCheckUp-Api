using System.Drawing;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Requests.Finance.Mizan.ReportPotDynamic;
using FinanceCheckUp.Application.Models.Responses.Finance.Mizan.ReportPotDynamic;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Mizan.ReportPotDynamic.Query.ReportPotDynamicOnGet
{
    public class MizanReportPotDynamicOnGetQueryHandler(
        IMainDashManager mainDashManager,
        IHhvnUsersManager hhvnUsersManager, 
        ICompanyManager companyManager) : IRequestHandler<MizanReportPotDynamicOnGetQuery, GenericResult<MizanReportPotDynamicOnGetResponse>>
    {
        
        public Task<GenericResult<MizanReportPotDynamicOnGetResponse>> Handle(MizanReportPotDynamicOnGetQuery request, CancellationToken cancellationToken)
        {
            
            var userId = Convert.ToInt64(request.UserId);
            var responseModel = new MizanReportPotDynamicRequestInitialModel
            {
                UserID = (int)userId,
                mreqListCompany = companyManager.Getby_User(userId)
            };
            
            
            
            
            List<string> result = request.Request.nyeara.Split(',').ToList();
            List<int> resultint = result.Select(int.Parse).ToList();
            int[] resultintList = resultint.ToArray();
            int nyear = resultint.Max();
            responseModel.YearCount = resultint.Count;
            var fields = new List<string>() { "GroupName" };
            fields.AddRange(result);
            
            responseModel.fieldsHeader = new List<string>() { "  " };
            responseModel.fieldsHeader.AddRange(result);

            responseModel.Isfailed = false; 
            

            responseModel.mreqListCompany = companyManager.Getby_User(responseModel.UserID);
            responseModel.CCompanies = responseModel.mreqListCompany.Where(x => x.IsDefault == 1).FirstOrDefault();

            responseModel.companyID = responseModel.CCompanies.Id;
            var compnacecode = 2790;
            if (!string.IsNullOrEmpty(responseModel.CCompanies.NaceCode) && !string.IsNullOrWhiteSpace(responseModel.CCompanies.NaceCode))
            {
                if (responseModel.CCompanies.NaceCode.Length == 3)
                {
                    compnacecode = Convert.ToInt32(responseModel.CCompanies.NaceCode.Replace(".", "").Substring(0, 3));
                }
                else
                {
                    compnacecode = Convert.ToInt32(responseModel.CCompanies.NaceCode.Replace(".", "").Substring(0, 4));

                }
            }

            responseModel.CurrentUser = hhvnUsersManager.GetRow_User(responseModel.UserID);
            responseModel.repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
            responseModel.header = responseModel.CCompanies.CompanyName;
            responseModel.nccode = responseModel.CCompanies.NaceCode;
            try
            {
                responseModel.ncheckKapak = ReportKapak.setKapak(mainDashManager.DataReportMainKapakDynamic(nyear, responseModel.companyID));
                if (responseModel.ncheckKapak == null)
                {
                    responseModel.ncheckKapak = new ReportKapak();
                }
                if (responseModel.ncheckKapak.nitemAltmanz.TumYil > 7)
                {
                    responseModel.ncheckKapak.nitemAltmanz.TumYil = 7;
                }
                if (responseModel.ncheckKapak.nitemCariOran.IsFailed > 0) { responseModel.shape1 = Color.FromArgb(182, 33, 45); } else { responseModel.shape1 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemLikitideOran.IsFailed > 0) { responseModel.shape2 = Color.FromArgb(182, 33, 45); } else { responseModel.shape2 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemNakitOran.IsFailed > 0) { responseModel.shape3 = Color.FromArgb(182, 33, 45); } else { responseModel.shape3 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemAlacakDevir.IsFailed > 0) { responseModel.shape4 = Color.FromArgb(182, 33, 45); } else { responseModel.shape4 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemTicariBorcDevir.IsFailed > 0) { responseModel.shape5 = Color.FromArgb(182, 33, 45); } else { responseModel.shape5 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemStokDevir.IsFailed > 0) { responseModel.shape6 = Color.FromArgb(182, 33, 45); } else { responseModel.shape6 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemBorcOzsermaye.IsFailed > 0) { responseModel.shape7 = Color.FromArgb(182, 33, 45); } else { responseModel.shape7 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0) { responseModel.shape8 = Color.FromArgb(182, 33, 45); } else { responseModel.shape8 = Color.FromArgb(23, 127, 117); };
                if (responseModel.ncheckKapak.nitemOzkaynakAktif.IsFailed > 0) { responseModel.shape9 = Color.FromArgb(182, 33, 45); } else { responseModel.shape9 = Color.FromArgb(23, 127, 117); };
                responseModel.ncheck = mainDashManager.DataReportMainDynamic(resultintList, responseModel.companyID);
                responseModel.nchecka = mainDashManager.DataReportMainADynamic(resultintList, responseModel.companyID);

                responseModel.ncheck1 = mainDashManager.DataReportMainBDynamic(resultintList, responseModel.companyID);
                responseModel.ncheck1a = mainDashManager.DataReportMainCDynamic(resultintList, responseModel.companyID);

                responseModel.ncheckd = mainDashManager.DataReportMainDDynamic(resultintList, responseModel.companyID);
                responseModel.nchecke = mainDashManager.DataReportMainEDynamic(resultintList, responseModel.companyID);
                responseModel.ncheckf = mainDashManager.DataReportMainFDynamic(resultintList, responseModel.companyID);
                responseModel.ncheckg = mainDashManager.DataReportMainGDynamic(resultintList, responseModel.companyID);
                responseModel.nchecklast = mainDashManager.DataReportMainTDynamic(resultintList, responseModel.companyID);
                responseModel.ncheckb = new List<ReportMainItem>();
                //ncheckb.Add(nchecka.Where(x=>x.CounterZone==44).First());
                responseModel.ncheckb.AddRange(responseModel.ncheck.Where(x => x.CounterZone == 11).ToList());
                responseModel.ncheckchart = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheckb.OrderBy(x => x.Year));
                responseModel.ncheckc = new List<ReportMainItem>();
                responseModel.ncheckc.AddRange(responseModel.ncheck.Where(x => x.CounterZone == 1011).ToList());
                responseModel.ncheckchartb = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheckc.OrderBy(x => x.Year));

                responseModel.ncheck1_ = mainDashManager.DataReportMain1Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck2 = mainDashManager.DataReportMain2Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck3 = mainDashManager.DataReportMain3Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck4 = mainDashManager.DataReportMain4Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck5 = mainDashManager.DataReportMain5Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck6 = mainDashManager.DataReportMain6Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck7 = mainDashManager.DataReportMain7Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck8 = mainDashManager.DataReportMain8Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck9 = mainDashManager.DataReportMain9Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck10 = mainDashManager.DataReportMain10Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck11 = mainDashManager.DataReportMain11Dynamic(resultintList, responseModel.companyID, compnacecode);
                responseModel.ncheck12 = mainDashManager.DataReportMain12Dynamic(resultintList, responseModel.companyID, compnacecode);

                responseModel.ncheckchart1 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck1_.OrderBy(x => x.Year));
                responseModel.ncheckchart2 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck2.OrderBy(x => x.Year));
                responseModel.ncheckchart3 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck3.OrderBy(x => x.Year));
                responseModel.ncheckchart4 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck4.OrderBy(x => x.Year));
                responseModel.ncheckchart5 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck5.OrderBy(x => x.Year));
                responseModel.ncheckchart6 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck6.OrderBy(x => x.Year));
                responseModel.ncheckchart7 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck7.OrderBy(x => x.Year));
                responseModel.ncheckchart8 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck8.OrderBy(x => x.Year));
                responseModel.ncheckchart9 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck9.OrderBy(x => x.Year));
                responseModel.ncheckchart10 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck10.OrderBy(x => x.Year));
                responseModel.ncheckchart11 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck11.OrderBy(x => x.Year));
                responseModel.ncheckchart12 = mainDashManager.DataReportMainChartMainMulti(responseModel.ncheck12.OrderBy(x => x.Year));

            }
            catch
            {

                responseModel.Isfailed = true;
            } 
            
            return Task.FromResult(GenericResult<MizanReportPotDynamicOnGetResponse>.Success(
                new MizanReportPotDynamicOnGetResponse
                {
                    InitialModel = responseModel
                }));
        }
    }
}
