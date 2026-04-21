using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraReports.UI;
using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Responses.Finance.Reports;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Models.ViewModel.Reports;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface ICompanyReportManager : IGenericDapperRepository
    {
        public CompanyReport Get_CompanyReport(long reportide);
        public List<CompanyReport> Get_CompanyReportList(long comide);

        public int Set_Report(long compide, long useride, string reportname, byte filetype_, byte reporttype_, int mainmonth_, int mainyear_, int maincount_);

        public KontrolRaporu getKontrolRaporu(int _year, long _compID, int monthid_, List<DataViewer> ncheck);
        public IcDenetimVergi getDenetimRaporu(int _year, long _compID, int monthid_, List<DataViewer> ncheck);
        public BalanceReport getMizanRaporu(int _year, Company CCompanies);
        public BalanceReport getMizanRaporuMizan(int _year, Company CCompanies);
        public BalanceReportAktarma getMizanRaporuMizanAkt(int _year, Company CCompanies);

        List<DataViewer> BuildKontrolDenetimNcheckList(List<DataViewer> ncheck);

        CompanyReportHelperMizanRaporuResponse BuildMizanRaporuApiPayload(int year, Company company);

        CompanyReportHelperMizanRaporuMizanResponse BuildMizanRaporuMizanApiPayload(int year, Company company);

        CompanyReportHelperMizanRaporuMizanAktResponse BuildMizanRaporuMizanAktApiPayload(int year, Company company);
    }


    public class CompanyReportManager(
    FinanceCheckUpDbContext _dbContext,
IReportSetMainSqlOperationManager reportSetMainSqlOperationManager,
IMizanResultManager mizanResultManager,
IReportMizanCheckManager reportMizanCheckManager) : GenericDapperRepositoryBase(_dbContext), ICompanyReportManager
    {
        public CompanyReport Get_CompanyReport(long reportide)
        {

            return StaticQuery<CompanyReport>("SELECT * FROM CompanyReport  where   ID=@ID", new { ID = reportide }).FirstOrDefault();
        }
        public List<CompanyReport> Get_CompanyReportList(long comide)
        {

            return StaticQuery<CompanyReport>("SELECT * FROM CompanyReport  where   CompanyID=@ID", new { ID = comide }).ToList();
        }

        public int Set_Report(long compide, long useride, string reportname, byte filetype_, byte reporttype_, int mainmonth_, int mainyear_, int maincount_)
        {
            return StaticQuery<int>("EXEC SPP_SaveComReportDocument @CompID,@UserID,@fileName,@filetype  ,@reporttype  ,@mainmonth ,@mainyear  ,@maincount ", new { CompID = compide, UserID = useride, fileName = reportname, filetype = filetype_, reporttype = reporttype_, mainmonth = mainmonth_, mainyear = mainyear_, maincount = maincount_ }).FirstOrDefault();
        }

        public KontrolRaporu getKontrolRaporu(int _year, long _compID, int monthid_, List<DataViewer> ncheck)
        {
            ncheck = ncheck.Distinct().OrderBy(c => c.EntryNumber).ThenBy(n => n.Description).ToList();
            var report = new KontrolRaporu();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource = ncheck;

            objectDataSource.Fill();
            report.DataSource = objectDataSource;
            return report;
        }
        public IcDenetimVergi getDenetimRaporu(int _year, long _compID, int monthid_, List<DataViewer> ncheck)
        {

            ncheck = ncheck.Distinct().OrderBy(c => c.EntryNumber).ThenBy(n => n.Description).ToList();
            var report = new IcDenetimVergi();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource = ncheck;

            objectDataSource.Fill();
            report.DataSource = objectDataSource;
            return report;
        }
        public BalanceReport getMizanRaporu(int _year, Company CCompanies)
        {
            string header = CCompanies.CompanyName + " " + _year.ToString() + " Yılı Kümülatif Mizan Raporu";
            List<ReportSet> ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilanco(_year, CCompanies.Id);
            List<DashMizanResult> ncheck1 = mizanResultManager.Get_MizanResult(_year, CCompanies.Id);
            List<DashDonukView> ncheck2 = mizanResultManager.Get_DonuChk(_year, CCompanies.Id);
            List<DashMizanResult> ncheck3 = mizanResultManager.Get_TicariAlıcı(_year, CCompanies.Id);
            List<DashMizanResult> ncheck4 = mizanResultManager.Get_TicariBorclu(_year, CCompanies.Id);
            ReportMizan mainreporttext = reportMizanCheckManager.GetComapanyCumulative(_year, CCompanies.Id);

            BalanceReport report = new BalanceReport();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource = ncheck;

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer1";
            objectDataSource1.DataSource = ncheck1;


            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck2;


            ObjectDataSource objectDataSource4 = new ObjectDataSource();
            objectDataSource4.Name = "DataViewer4";
            objectDataSource4.DataSource = ncheck3;



            ObjectDataSource objectDataSource5 = new ObjectDataSource();
            objectDataSource5.Name = "DataViewer5";
            objectDataSource5.DataSource = ncheck4;

            //objectDataSource.Fill();
            DetailReportBand detailReport1 = report.Bands["DetailReport"] as DetailReportBand;
            DetailReportBand detailReport2 = report.Bands["DetailReport1"] as DetailReportBand;
            DetailReportBand detailReport3 = report.Bands["DetailReport2"] as DetailReportBand;
            DetailReportBand detailReport4 = report.Bands["DetailReport3"] as DetailReportBand;
            DetailReportBand detailReport5 = report.Bands["DetailReport4"] as DetailReportBand;

            report.FindControl("xrLabel1", true).Text = mainreporttext.TotalAssets.ToString("N0");
            report.FindControl("xrLabel1l", true).Text = mainreporttext.TotalLiability.ToString("N0");
            report.FindControl("xrLabel1e", true).Text = mainreporttext.TotalEquity.ToString("N0");
            report.FindControl("xrLabel1p", true).Text = mainreporttext.ProfitOrLoss.ToString("N0");
            report.xrLabel21rpt.Text = header;

            if (mainreporttext.TrialBalance == 0)
            {
                report.FindControl("xrShape2", true).Visible = false;
            }
            else
            {
                report.FindControl("xrShape1", true).Visible = false;
            }
            report.xrResultbalance.Text = mainreporttext.TrialBalance.ToString();
            //report.DataSource = objectDataSource;
            detailReport1.DataSource = objectDataSource;
            detailReport2.DataSource = objectDataSource1;
            detailReport3.DataSource = objectDataSource3;
            detailReport4.DataSource = objectDataSource4;
            detailReport5.DataSource = objectDataSource5;
            return report;
        }
        public BalanceReport getMizanRaporuMizan(int _year, Company CCompanies)
        {
            string header = CCompanies.CompanyName + " " + _year.ToString() + " Yılı Kümülatif Mizan Raporu";


     

            List<ReportSet> ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilanco(_year, CCompanies.Id);
            List<DashMizanResult> ncheck1 = mizanResultManager.Get_MizanResult(_year, CCompanies.Id);
            List<DashDonukView> ncheck2 = mizanResultManager.Get_DonuChk(_year, CCompanies.Id);
            List<DashMizanResult> ncheck3 = mizanResultManager.Get_TicariAlıcıMizan(_year, CCompanies.Id);
            List<DashMizanResult> ncheck4 = mizanResultManager.Get_TicariBorcluMizan(_year, CCompanies.Id);
            ReportMizan mainreporttext = reportMizanCheckManager.GetComapanyCumulativeMizan(_year, CCompanies.Id);

            BalanceReport report = new BalanceReport();

            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource = ncheck;

            ObjectDataSource objectDataSource1 = new ObjectDataSource();
            objectDataSource1.Name = "DataViewer1";
            objectDataSource1.DataSource = ncheck1;


            ObjectDataSource objectDataSource3 = new ObjectDataSource();
            objectDataSource3.Name = "DataViewer3";
            objectDataSource3.DataSource = ncheck2;


            ObjectDataSource objectDataSource4 = new ObjectDataSource();
            objectDataSource4.Name = "DataViewer4";
            objectDataSource4.DataSource = ncheck3;



            ObjectDataSource objectDataSource5 = new ObjectDataSource();
            objectDataSource5.Name = "DataViewer5";
            objectDataSource5.DataSource = ncheck4;

            //objectDataSource.Fill();
            DetailReportBand detailReport1 = report.Bands["DetailReport"] as DetailReportBand;
            DetailReportBand detailReport2 = report.Bands["DetailReport1"] as DetailReportBand;
            DetailReportBand detailReport3 = report.Bands["DetailReport2"] as DetailReportBand;
            DetailReportBand detailReport4 = report.Bands["DetailReport3"] as DetailReportBand;
            DetailReportBand detailReport5 = report.Bands["DetailReport4"] as DetailReportBand;

            report.FindControl("xrLabel1", true).Text = mainreporttext.TotalAssets.ToString("N0");
            report.FindControl("xrLabel1l", true).Text = mainreporttext.TotalLiability.ToString("N0");
            report.FindControl("xrLabel1e", true).Text = mainreporttext.TotalEquity.ToString("N0");
            report.FindControl("xrLabel1p", true).Text = mainreporttext.ProfitOrLoss.ToString("N0");
            report.xrLabel21rpt.Text = header;

            if (mainreporttext.TrialBalance == 0)
            {
                report.FindControl("xrShape2", true).Visible = false;
            }
            else
            {
                report.FindControl("xrShape1", true).Visible = false;
            }
            report.xrResultbalance.Text = mainreporttext.TrialBalance.ToString();
            //report.DataSource = objectDataSource;
            detailReport1.DataSource = objectDataSource;
            detailReport2.DataSource = objectDataSource1;
            detailReport3.DataSource = objectDataSource3;
            detailReport4.DataSource = objectDataSource4;
            detailReport5.DataSource = objectDataSource5;
            return report;
        }
        public BalanceReportAktarma getMizanRaporuMizanAkt(int _year, Company CCompanies)
        {
            string header = CCompanies.CompanyName + " " + _year.ToString() + " Yılı Aktarma Karşılaştırmalı Mizan Raporu";
            List<ReportSet> ncheck = reportSetMainSqlOperationManager.Get_ReportSetBilancoAkt(_year, CCompanies.Id);
            BalanceReportAktarma report = new BalanceReportAktarma();
            ObjectDataSource objectDataSource = new ObjectDataSource();
            objectDataSource.Name = "DataViewer";
            objectDataSource.DataSource =  ncheck;

            objectDataSource.Fill();
            DetailReportBand detailReport1 = report.Bands["DetailReport"] as DetailReportBand;

            report.xrLabelheader.Text =  header; 
            detailReport1.DataSource = objectDataSource;
            // report.DataSource = objectDataSource;
            report.PrintingSystem.Document.Name = "Balance_raporlar";
            return report;
        }

        public List<DataViewer> BuildKontrolDenetimNcheckList(List<DataViewer> ncheck)
        {
            if (ncheck == null || ncheck.Count == 0)
            {
                return ncheck ?? new List<DataViewer>();
            }

            return ncheck.Distinct().OrderBy(c => c.EntryNumber).ThenBy(n => n.Description).ToList();
        }

        public CompanyReportHelperMizanRaporuResponse BuildMizanRaporuApiPayload(int year, Company company)
        {
            string header = company.CompanyName + " " + year.ToString() + " Yılı Kümülatif Mizan Raporu";
            List<ReportSet> bilanco = reportSetMainSqlOperationManager.Get_ReportSetBilanco(year, company.Id);
            List<DashMizanResult> mizanResult = mizanResultManager.Get_MizanResult(year, company.Id);
            List<DashDonukView> donukChk = mizanResultManager.Get_DonuChk(year, company.Id);
            List<DashMizanResult> ticariAlici = mizanResultManager.Get_TicariAlıcı(year, company.Id);
            List<DashMizanResult> ticariBorclu = mizanResultManager.Get_TicariBorclu(year, company.Id);
            ReportMizan mainreporttext = reportMizanCheckManager.GetComapanyCumulative(year, company.Id);

            return new CompanyReportHelperMizanRaporuResponse
            {
                Header = header,
                MainReportText = mainreporttext,
                Bilanco = bilanco,
                MizanResult = mizanResult,
                DonukChk = donukChk,
                TicariAlici = ticariAlici,
                TicariBorclu = ticariBorclu
            };
        }

        public CompanyReportHelperMizanRaporuMizanResponse BuildMizanRaporuMizanApiPayload(int year, Company company)
        {
            string header = company.CompanyName + " " + year.ToString() + " Yılı Kümülatif Mizan Raporu";
            List<ReportSet> bilanco = reportSetMainSqlOperationManager.Get_ReportSetBilanco(year, company.Id);
            List<DashMizanResult> mizanResult = mizanResultManager.Get_MizanResult(year, company.Id);
            List<DashDonukView> donukChk = mizanResultManager.Get_DonuChk(year, company.Id);
            List<DashMizanResult> ticariAlici = mizanResultManager.Get_TicariAlıcıMizan(year, company.Id);
            List<DashMizanResult> ticariBorclu = mizanResultManager.Get_TicariBorcluMizan(year, company.Id);
            ReportMizan mainreporttext = reportMizanCheckManager.GetComapanyCumulativeMizan(year, company.Id);

            return new CompanyReportHelperMizanRaporuMizanResponse
            {
                Header = header,
                MainReportText = mainreporttext,
                Bilanco = bilanco,
                MizanResult = mizanResult,
                DonukChk = donukChk,
                TicariAlici = ticariAlici,
                TicariBorclu = ticariBorclu
            };
        }

        public CompanyReportHelperMizanRaporuMizanAktResponse BuildMizanRaporuMizanAktApiPayload(int year, Company company)
        {
            string header = company.CompanyName + " " + year.ToString() + " Yılı Aktarma Karşılaştırmalı Mizan Raporu";
            List<ReportSet> bilanco = reportSetMainSqlOperationManager.Get_ReportSetBilancoAkt(year, company.Id);

            return new CompanyReportHelperMizanRaporuMizanAktResponse
            {
                Header = header,
                BilancoAktarma = bilanco
            };
        }
    }
}
