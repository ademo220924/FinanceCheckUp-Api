using System.Drawing;
using DevExpress.DataAccess.ObjectBinding;
using DevExpress.XtraCharts;
using DevExpress.XtraReports.UI;
using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using fincheckup.Report;

namespace FinanceCheckUp.Application.Managers.StaticManagers;



public interface IComReportManager : IGenericDapperRepository
{
    public ReportFinancialOverview Getreport(int nyear, Company comp);
}

public class ComReportManager( FinanceCheckUpDbContext _dbContext,IMainDashManager mainDashManager): GenericDapperRepositoryBase(_dbContext), IComReportManager
{
    public ReportFinancialOverview Getreport(int nyear, Company comp)
    {
        var comReport = new ComReport();
        
        long companyID = comp.Id;
        comReport.compnacecode = 2790;
        if (!string.IsNullOrEmpty(comp.NaceCode) && !string.IsNullOrWhiteSpace(comp.NaceCode))
        {
            if (comp.NaceCode.Length == 3)
            {
                comReport.compnacecode = Convert.ToInt32(comp.NaceCode.Replace(".", "").Substring(0, 3));
            }
            else
            {
                comReport.compnacecode = Convert.ToInt32(comp.NaceCode.Replace(".", "").Substring(0, 4));
            }
        }


        comReport.repchakec = "Kayıtlarda Bir Sorunla Karşılaşıldı";
        comReport.header = comp.CompanyName;
        comReport.nccode = comp.NaceCode;
        comReport.ncheckKapak = ReportKapak.setKapak(mainDashManager.DataReportMainKapak(nyear, companyID));
        if (comReport.ncheckKapak == null)
        {
            comReport.ncheckKapak = new ReportKapak();
        }

        if (comReport.ncheckKapak.nitemCariOran.IsFailed > 0)
        {
            comReport.shape1 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape1 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemLikitideOran.IsFailed > 0)
        {
            comReport.shape2 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape2 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemNakitOran.IsFailed > 0)
        {
            comReport.shape3 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape3 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemAlacakDevir.IsFailed > 0)
        {
            comReport.shape4 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape4 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemTicariBorcDevir.IsFailed > 0)
        {
            comReport.shape5 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape5 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemStokDevir.IsFailed > 0)
        {
            comReport.shape6 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape6 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemBorcOzsermaye.IsFailed > 0)
        {
            comReport.shape7 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape7 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemTpolamBankaBorc.IsFailed > 0)
        {
            comReport.shape8 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape8 = Color.FromArgb(23, 127, 117);
        }

        ;
        if (comReport.ncheckKapak.nitemOzkaynakAktif.IsFailed > 0)
        {
            comReport.shape9 = Color.FromArgb(182, 33, 45);
        }
        else
        {
            comReport.shape9 = Color.FromArgb(23, 127, 117);
        }

       
        comReport.ncheck = mainDashManager.DataReportMain(nyear, companyID);
        comReport.nchecka = mainDashManager.DataReportMainA(nyear, companyID); 
        comReport.ncheck1 = mainDashManager.DataReportMainB(nyear, companyID);
        comReport.ncheck1a = mainDashManager.DataReportMainC(nyear, companyID); 
        comReport.ncheckd = mainDashManager.DataReportMainD(nyear, companyID);
        comReport.nchecke = mainDashManager.DataReportMainE(nyear, companyID);
        comReport.ncheckf = mainDashManager.DataReportMainF(nyear, companyID);
        comReport.ncheckg = mainDashManager.DataReportMainG(nyear, companyID);
        comReport.nchecklast = mainDashManager.DataReportMainT(nyear, companyID);
        comReport.ncheckb = new List<ReportMainItem>(); 
        comReport.ncheckb.Add(comReport.ncheck.Where(x => x.CounterZone == 11).First());
        comReport.ncheckchart = mainDashManager.DataReportMainChartMain(comReport.ncheckb);
        comReport.ncheckc = new List<ReportMainItem>();
        comReport.ncheckc.Add(comReport.ncheck.Where(x => x.CounterZone == 1011).First());
        comReport.ncheckchartb = mainDashManager.DataReportMainChartMain(comReport.ncheckc); 
        comReport.ncheck1_ = mainDashManager.DataReportMain1(nyear, companyID, comReport.compnacecode);
        comReport.ncheck2 = mainDashManager.DataReportMain2(nyear, companyID, comReport.compnacecode);
        comReport.ncheck3 = mainDashManager.DataReportMain3(nyear, companyID, comReport.compnacecode);
        comReport.ncheck4 = mainDashManager.DataReportMain4(nyear, companyID, comReport.compnacecode);
        comReport.ncheck5 = mainDashManager.DataReportMain5(nyear, companyID, comReport.compnacecode);
        comReport.ncheck6 = mainDashManager.DataReportMain6(nyear, companyID, comReport.compnacecode);
        comReport.ncheck7 = mainDashManager.DataReportMain7(nyear, companyID, comReport.compnacecode);
        comReport.ncheck8 = mainDashManager.DataReportMain8(nyear, companyID, comReport.compnacecode);
        comReport.ncheck9 = mainDashManager.DataReportMain9(nyear, companyID, comReport.compnacecode);
        comReport.ncheck10 = mainDashManager.DataReportMain10(nyear, companyID, comReport.compnacecode);
        comReport.ncheck11 = mainDashManager.DataReportMain11(nyear, companyID, comReport.compnacecode);
        comReport.ncheck12 = mainDashManager.DataReportMain12(nyear, companyID, comReport.compnacecode); 
        comReport.ncheckchart1 = mainDashManager.DataReportMainChartMain(comReport.ncheck1_);
        comReport.ncheckchart2 = mainDashManager.DataReportMainChartMain(comReport.ncheck2);
        comReport.ncheckchart3 = mainDashManager.DataReportMainChartMain(comReport.ncheck3);
        comReport.ncheckchart4 = mainDashManager.DataReportMainChartMain(comReport.ncheck4);
        comReport.ncheckchart5 = mainDashManager.DataReportMainChartMain(comReport.ncheck5);
        comReport.ncheckchart6 = mainDashManager.DataReportMainChartMain(comReport.ncheck6);
        comReport.ncheckchart7 = mainDashManager.DataReportMainChartMain(comReport.ncheck7);
        comReport.ncheckchart8 = mainDashManager.DataReportMainChartMain(comReport.ncheck8);
        comReport.ncheckchart9 = mainDashManager.DataReportMainChartMain(comReport.ncheck9);
        comReport.ncheckchart10 = mainDashManager.DataReportMainChartMain(comReport.ncheck10);
        comReport.ncheckchart11 = mainDashManager.DataReportMainChartMain(comReport.ncheck11);
        comReport.ncheckchart12 = mainDashManager.DataReportMainChartMain(comReport.ncheck12);
        ReportFinancialOverview report = new ReportFinancialOverview();
        ObjectDataSource objectDataSource = new ObjectDataSource();
        objectDataSource.Name = "DataViewer";
        objectDataSource.DataSource = comReport.ncheck;

        objectDataSource.Fill();

        ObjectDataSource objectDataSourceA = new ObjectDataSource();
        objectDataSourceA.Name = "DataViewerA";
        objectDataSourceA.DataSource = comReport.nchecka;

        objectDataSourceA.Fill();

        ObjectDataSource objectDataSourceB = new ObjectDataSource();
        objectDataSourceB.Name = "DataViewerB";
        objectDataSourceB.DataSource = comReport.ncheck1;

        objectDataSourceB.Fill();

        ObjectDataSource objectDataSourceC = new ObjectDataSource();
        objectDataSourceC.Name = "DataViewerC";
        objectDataSourceC.DataSource = comReport.ncheck1a;

        objectDataSourceC.Fill();


        ObjectDataSource objectDataSourceD = new ObjectDataSource();
        objectDataSourceD.Name = "DataViewerD";
        objectDataSourceD.DataSource = comReport.ncheckd;

        objectDataSourceD.Fill();

        ObjectDataSource objectDataSourceE = new ObjectDataSource();
        objectDataSourceE.Name = "DataViewerE";
        objectDataSourceE.DataSource = comReport.nchecke;

        objectDataSourceE.Fill();

        ObjectDataSource objectDataSourceF = new ObjectDataSource();
        objectDataSourceF.Name = "DataViewerF";
        objectDataSourceF.DataSource = comReport.ncheckf;

        objectDataSourceF.Fill();


        ObjectDataSource objectDataSourceG = new ObjectDataSource();
        objectDataSourceG.Name = "DataViewerG";
        objectDataSourceG.DataSource = comReport.ncheckg;
        objectDataSourceG.Fill();

        ObjectDataSource objectDataSourceT = new ObjectDataSource();
        objectDataSourceT.Name = "DataViewerT";
        objectDataSourceT.DataSource = comReport.nchecklast;
        objectDataSourceT.Fill();

        comReport.checkSeries = new LineSeriesView();
        DetailReportBand detailReport = report.Bands["DetailReport"] as DetailReportBand;
        DetailReportBand detailReport1 = report.Bands["DetailReport1"] as DetailReportBand;
        DetailReportBand detailReport2 = report.Bands["DetailReport2"] as DetailReportBand;
        DetailReportBand detailReport3 = report.Bands["DetailReport4"] as DetailReportBand;


        DetailReportBand detailReport11 = report.Bands["DetailReport11"] as DetailReportBand;
        DetailReportBand detailReport12 = report.Bands["DetailReport12"] as DetailReportBand;
        DetailReportBand detailReport13 = report.Bands["DetailReport13"] as DetailReportBand;
        DetailReportBand detailReport14 = report.Bands["DetailReport14"] as DetailReportBand;
        DetailReportBand detailReport15 = report.Bands["DetailReport15"] as DetailReportBand;

        detailReport.DataSource = objectDataSource;
        detailReport1.DataSource = objectDataSourceA;
        detailReport2.DataSource = objectDataSourceB;
        detailReport3.DataSource = objectDataSourceC;

        detailReport11.DataSource = objectDataSourceD;
        detailReport12.DataSource = objectDataSourceE;
        detailReport13.DataSource = objectDataSourceF;
        detailReport14.DataSource = objectDataSourceG;
        detailReport15.DataSource = objectDataSourceT;

        var chart = (XRChart)report.FindControl("xrChart1", false);
        chart.Series.Clear();
        chart.DataSource = comReport.ncheckchart; //Method from documentation you reffered
        chart.SeriesTemplate.SeriesDataMember = "GroupName";

        chart.SeriesTemplate.Label.TextPattern = "{V:n0}";
        chart.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart.SeriesTemplate.ValueDataMembers.AddRange("Value");

        var chart1 = (XRChart)report.FindControl("xrChart2", false);
        chart1.Series.Clear();
        chart1.DataSource = comReport.ncheckchartb; //Method from documentation you reffered
        chart1.SeriesTemplate.SeriesDataMember = "GroupName";
        chart1.SeriesTemplate.Label.TextPattern = "{V:n0}";
        chart1.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart1.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart3 = (XRChart)report.FindControl("xrChart3", false);
        chart3.Series.Clear();
        chart3.DataSource = comReport.ncheckchart1; //Method from documentation you reffered
        chart3.SeriesTemplate.SeriesDataMember = "GroupName";
        chart3.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart3.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart3.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart4 = (XRChart)report.FindControl("xrChart4", false);
        chart4.Series.Clear();
        chart4.DataSource = comReport.ncheckchart2; //Method from documentation you reffered
        chart4.SeriesTemplate.SeriesDataMember = "GroupName";
        chart4.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart4.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart4.SeriesTemplate.ValueDataMembers.AddRange("Value");

        var chart5 = (XRChart)report.FindControl("xrChart5", false);
        chart5.Series.Clear();
        chart5.DataSource = comReport.ncheckchart3; //Method from documentation you reffered
        chart5.SeriesTemplate.SeriesDataMember = "GroupName";
        chart5.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart5.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart5.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart6 = (XRChart)report.FindControl("xrChart6", false);
        chart6.Series.Clear();
        chart6.DataSource = comReport.ncheckchart4; //Method from documentation you reffered
        chart6.SeriesTemplate.SeriesDataMember = "GroupName";
        chart6.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart6.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart6.SeriesTemplate.ValueDataMembers.AddRange("Value");

        report.xrLabel31.Text = comReport.header;
        report.xrLabel29.Text = comReport.nccode;
        var chart7 = (XRChart)report.FindControl("xrChart7", false);
        chart7.Series.Clear();
        chart7.DataSource = comReport.ncheckchart5; //Method from documentation you reffered
        chart7.SeriesTemplate.SeriesDataMember = "GroupName";
        chart7.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart7.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart7.SeriesTemplate.ValueDataMembers.AddRange("Value");

        var chart8 = (XRChart)report.FindControl("xrChart8", false);
        chart8.Series.Clear();
        chart8.DataSource = comReport.ncheckchart6; //Method from documentation you reffered
        chart8.SeriesTemplate.SeriesDataMember = "GroupName";
        chart8.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart8.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart8.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart9 = (XRChart)report.FindControl("xrChart9", false);
        chart9.Series.Clear();
        chart9.DataSource = comReport.ncheckchart7; //Method from documentation you reffered
        chart9.SeriesTemplate.SeriesDataMember = "GroupName";
        chart9.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart9.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart9.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart10 = (XRChart)report.FindControl("xrChart10", false);
        chart10.Series.Clear();
        chart10.DataSource = comReport.ncheckchart8; //Method from documentation you reffered
        chart10.SeriesTemplate.SeriesDataMember = "GroupName";
        chart10.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart10.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart10.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart11 = (XRChart)report.FindControl("xrChart11", false);
        chart11.Series.Clear();
        chart11.DataSource = comReport.ncheckchart9; //Method from documentation you reffered
        chart11.SeriesTemplate.SeriesDataMember = "GroupName";
        chart11.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart11.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart11.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart12 = (XRChart)report.FindControl("xrChart12", false);
        chart12.Series.Clear();
        chart12.DataSource = comReport.ncheckchart10; //Method from documentation you reffered
        chart12.SeriesTemplate.SeriesDataMember = "GroupName";
        chart12.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart12.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart12.SeriesTemplate.ValueDataMembers.AddRange("Value");


        var chart13 = (XRChart)report.FindControl("xrChart13", false);
        chart13.Series.Clear();
        chart13.DataSource = comReport.ncheckchart11; //Method from documentation you reffered
        chart13.SeriesTemplate.SeriesDataMember = "GroupName";
        chart13.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart13.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart13.SeriesTemplate.ValueDataMembers.AddRange("Value");

        //Color.FromArgb(182,33,45) red
        //Color.FromArgb(23, 127, 117) greeen
        var chart14 = (XRChart)report.FindControl("xrChart14", false);
        chart14.Series.Clear();
        chart14.DataSource = comReport.ncheckchart12; //Method from documentation you reffered
        chart14.SeriesTemplate.SeriesDataMember = "GroupName";
        chart14.SeriesTemplate.ArgumentDataMember = "GroupText";
        chart14.SeriesTemplate.Label.TextPattern = "{V:n2}";
        chart14.SeriesTemplate.ValueDataMembers.AddRange("Value");

        var xrlbl1 = (XRLabel)report.FindControl("xrLblOzkaynak", false);
        xrlbl1.Text = comReport.ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

        var xrlbl2 = (XRLabel)report.FindControl("xrlblCarioran", false);
        xrlbl2.Text = comReport.ncheckKapak.nitemCariOran.TumYil.ToString("N2");


        var xrlbl3 = (XRLabel)report.FindControl("xrlblROA", false);
        xrlbl3.Text = (comReport.ncheckKapak.nitemROAAktifKarlilik.TumYil * 100).ToString("N2") + "%";

        //var xrlbl4 = (XRLabel)report.FindControl("xrlblNetsatbuyume", false);
        //xrlbl4.Text = ncheckKapak.nitemNetSatisBuyumeOran.TumYil.ToString("N2");

        var xrlbl5 = (XRLabel)report.FindControl("xrlblAltmanZ", false);
        xrlbl5.Text = comReport.ncheckKapak.nitemAltmanz.TumYil.ToString("N2");


        var xrlbl6 = (XRLabel)report.FindControl("xrlblNetIsletmeSerm", false);
        xrlbl6.Text = comReport.ncheckKapak.nitemNetIsletmeSermaye.TumYil.ToString("N0");


        var xrlbl7 = (XRLabel)report.FindControl("xrlblFaizVeVergi", false);
        xrlbl7.Text = comReport.ncheckKapak.nitemFaizVergiOncesiKarZarar.TumYil.ToString("N2");


        var xrlbl8 = (XRLabel)report.FindControl("xrCaritablo", false);
        xrlbl8.Text = comReport.ncheckKapak.nitemCariOran.TumYil.ToString("N2");


        var xrlbl9 = (XRLabel)report.FindControl("xrLikiditetablo", false);
        xrlbl9.Text = comReport.ncheckKapak.nitemLikitideOran.TumYil.ToString("N2");

        var xrlbl10 = (XRLabel)report.FindControl("xrNakittablo", false);
        xrlbl10.Text = comReport.ncheckKapak.nitemNakitOran.TumYil.ToString("N2");


        var xrlbl14 = (XRLabel)report.FindControl("xrtoplamborcsermtablo", false);
        xrlbl14.Text = comReport.ncheckKapak.nitemBorcOzsermaye.TumYil.ToString("N2");

        var xrlbl15 = (XRLabel)report.FindControl("xrtoplambankaborcdevirtablo", false);
        xrlbl15.Text = comReport.ncheckKapak.nitemTpolamBankaBorc.TumYil.ToString("N2");

        var xrlbl16 = (XRLabel)report.FindControl("xrOzaynakaktifktablo", false);
        xrlbl16.Text = comReport.ncheckKapak.nitemOzkaynakAktif.TumYil.ToString("N2");

        var gauget = (XRGauge)report.FindControl("xrGauge1", false);
        gauget.TargetValue = comReport.ncheckKapak.nitemAltmanz.TumYil;

        var rShape1 = (XRShape)report.FindControl("xrShape1", false);
        rShape1.BackColor = comReport.shape1;

        var rShape2 = (XRShape)report.FindControl("xrShape2", false);
        rShape2.BackColor = comReport.shape2;

        var rShape3 = (XRShape)report.FindControl("xrShape3", false);
        rShape3.BackColor = comReport.shape3;


        var rShape7 = (XRShape)report.FindControl("xrShape7", false);
        rShape7.BackColor = comReport.shape7;

        var rShape8 = (XRShape)report.FindControl("xrShape8", false);
        rShape8.BackColor = comReport.shape8;

        var rShape9 = (XRShape)report.FindControl("xrShape9", false);
        rShape9.BackColor = comReport.shape9;

        return report;
    }

}