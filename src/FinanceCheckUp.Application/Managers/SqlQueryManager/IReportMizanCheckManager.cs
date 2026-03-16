using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;

namespace FinanceCheckUp.Application.Managers.SqlQueryManager
{
    public interface IReportMizanCheckManager : IGenericDapperRepository
    {
        public ReportMizanone Get_TrialBalance(int _year, long _compID);
        public ReportMizanone Get_TrialBalanceMizan(int _year, long _compID);
        public ReportMizanone Get_TotalAssets(int _year, long _compID);
        public ReportMizanone Get_TotalAssetsMizan(int _year, long _compID);
        public ReportMizanone Get_TotalLiability(int _year, long _compID);
        public ReportMizanone Get_TotalLiabilityMizan(int _year, long _compID);
        public ReportMizanone Get_TotalEquity(int _year, long _compID);
        public ReportMizanone Get_TotalEquityMizan(int _year, long _compID);
        public ReportMizanone Get_ProfitOrLoss(int _year, long _compID);
        public ReportMizanone Get_ProfitOrLossMizan(int _year, long _compID);
        public long Get_P590(int _year, long _compID);
        public int Get_P591(int _year, long _compID);
        public int Get_NetKarZarar(int _year, long _compID);
        public ReportMizan GetComapanyCumulative(int _year, long _compID);
        public ReportMizan GetComapanyCumulativeMizan(int _year, long _compID);
        public ReportMizan GetComapanyCumulativeBeyan(int _year, long _compID);
    }

    public class ReportMizanCheckManager(FinanceCheckUpDbContext _dbContext, IDashOzetMaliMizanManager dashOzetMaliMizanManager) : GenericDapperRepositoryBase(_dbContext), IReportMizanCheckManager
    {
        public ReportMizanone Get_TrialBalance(int _year, long _compID)
        {
            ReportMizanone result = StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2,3,4,5,6)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            int check = StaticQuery<int>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            result.Amount = result.Amount + check;
            return result;
        }
        public ReportMizanone Get_TrialBalanceMizan(int _year, long _compID)
        {
            ReportMizanone result = StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where  CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2,3,4,5,6)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();

            int check = StaticQuery<int>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
            result.Amount = result.Amount + check;
            return result;
        }
        public ReportMizanone Get_TotalAssets(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_TotalAssetsMizan(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(Cast(SUM([AmountBakiye]) as bigint),0) as Amount FROM [dbo].[TBLXMLSourceOne] where CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(1,2)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_TotalLiability(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(3,4)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_TotalLiabilityMizan(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(3,4)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_TotalEquity(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount  FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and Year=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID=5) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_TotalEquityMizan(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount  FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and Year=@nyear and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID=5) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_ProfitOrLoss(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceMain] where CsvID in (Select ID from TBLXml where CompanyID=@companyID and [Year]=@nyear) and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(6,7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizanone Get_ProfitOrLossMizan(int _year, long _compID)
        {
            return StaticQuery<ReportMizanone>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID in (Select Code FROM [dbo].[MCodeZen] Where SubTypeID in(6,7)) ", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public long Get_P590(int _year, long _compID)
        {
            return StaticQuery<int>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear  and AccountMainID ='590'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public int Get_P591(int _year, long _compID)
        {
            return StaticQuery<int>("SELECT  ISNULL(ABS(Cast(SUM([AmountBakiye]) as bigint)),0) as Amount FROM [dbo].[TBLXMLSourceOne] where   CompanyID=@companyID and [Year]=@nyear    and AccountMainID ='591'", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        //  
        public int Get_NetKarZarar(int _year, long _compID)
        {
            return StaticQuery<int>("Select ([January] +[February]+[March]+[April]+[May]+[June]+[July]+[August]+[September]+[October]+[November]+[December] ) from  TBLWcapDonemKarZararNet where CompanyID=@companyID and [Year]=@nyear", new { nyear = _year, companyID = _compID }).FirstOrDefault();
        }
        public ReportMizan GetComapanyCumulative(int _year, long _compID)
        {
            ReportMizan rn = new ReportMizan();
            int netkarz = Get_NetKarZarar(_year, _compID);
            rn.ProfitOrLoss = netkarz;
            rn.TotalAssets = Get_TotalAssets(_year, _compID).Amount;
            rn.TotalEquity = Get_TotalEquity(_year, _compID).Amount;
            rn.TotalLiability = Get_TotalLiability(_year, _compID).Amount;
            rn.TrialBalance = Math.Abs(rn.TotalAssets) - (Math.Abs(rn.TotalEquity) + Math.Abs(rn.TotalLiability));

            if (rn.TrialBalance < 2 && rn.TrialBalance > -2)
            {
                rn.ProfitOrLoss = 0;
                rn.TrialBalance = 0;
                return rn;
            }


            long get590 = Get_P590(_year, _compID);
            if (get590 > netkarz)
            {
                if (get590 - netkarz < 1)
                {

                }
                else
                {
                    rn.ProfitOrLoss = 0;
                    rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(get590);
                }
            }
            else
            {
                if (netkarz - get590 < 1)
                {

                }
                else
                {
                    rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(netkarz);
                }
            }

            if (rn.TrialBalance < 2 && rn.TrialBalance > -2)
            {
                rn.TrialBalance = 0;

            }

            return rn;
        }
        public ReportMizan GetComapanyCumulativeMizan(int _year, long _compID)
        {
            ReportMizan rn = new ReportMizan();
            rn.ProfitOrLoss = Get_ProfitOrLossMizan(_year, _compID) != null ? Get_ProfitOrLossMizan(_year, _compID).Amount : 0;
            rn.TotalAssets = Get_TotalAssetsMizan(_year, _compID) != null ? Get_TotalAssetsMizan(_year, _compID).Amount : 0;
            rn.TotalEquity = Get_TotalEquityMizan(_year, _compID) != null ? Get_TotalEquityMizan(_year, _compID).Amount : 0;
            rn.TotalLiability = Get_TotalLiabilityMizan(_year, _compID) != null ? Get_TotalLiabilityMizan(_year, _compID).Amount : 0;

            long totalPasive = dashOzetMaliMizanManager.getPasifMizan(_year, _compID);
            long totalKArzarare = dashOzetMaliMizanManager.getKArzarar(_year, _compID);
            long totalOzkaynak = dashOzetMaliMizanManager.getOzkaynak(_year, _compID);
            rn.TrialBalance = Math.Abs(rn.TotalAssets) - (Math.Abs(rn.TotalEquity) + Math.Abs(rn.TotalLiability));
            long get590 = Get_P590(_year, _compID);
            bool chkKarZarar = false;
            if (get590 == 0)
            {
                chkKarZarar = true;
                get590 = totalKArzarare;
            }

            if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
            {
                rn.TotalEquity = totalOzkaynak;
                rn.ProfitOrLoss = 0;
                if (chkKarZarar)
                {
                    rn.ProfitOrLoss = get590;
                }

                rn.TrialBalance = 0;
                return rn;
            }
            rn.TrialBalance = Math.Abs(rn.TotalAssets) - Math.Abs(totalPasive);

            if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
            {
                rn.TotalEquity = totalOzkaynak;
                rn.ProfitOrLoss = 0;
                if (chkKarZarar)
                {
                    rn.ProfitOrLoss = get590;
                }
                rn.TrialBalance = 0;
                return rn;
            }



            if (get590 > rn.ProfitOrLoss)
            {
                if (get590 - rn.ProfitOrLoss < 1)
                {

                }
                else
                {
                    rn.ProfitOrLoss = 0;
                    if (chkKarZarar)
                    {
                        rn.ProfitOrLoss = get590;
                    }
                    rn.TrialBalance = Math.Abs(rn.TrialBalance) - Math.Abs(totalKArzarare);
                }
            }
            else
            {
                if (rn.ProfitOrLoss - get590 < 1)
                {
                    rn.ProfitOrLoss = get590;
                    rn.TrialBalance = 0;
                }
                else
                {
                    if (rn.TrialBalance == 0)
                    {
                        rn.TrialBalance = Math.Abs(rn.TrialBalance - rn.ProfitOrLoss);
                    }
                    else
                    {

                        rn.TrialBalance = Math.Abs(rn.TrialBalance - rn.ProfitOrLoss);
                        rn.ProfitOrLoss = 0;
                        if (chkKarZarar)
                        {
                            rn.ProfitOrLoss = get590;
                        }
                    }
                }
            }


            rn.ProfitOrLoss = 0;
            if (chkKarZarar)
            {
                rn.ProfitOrLoss = get590;
            }
            rn.TotalEquity = totalOzkaynak;
            rn.TrialBalance = Math.Abs(rn.TotalAssets) - (rn.TotalEquity + rn.TotalLiability + rn.ProfitOrLoss);
            if (rn.TrialBalance < 5 && rn.TrialBalance > -5)
            {
                rn.TrialBalance = 0;

            }
            return rn;
        }
        public ReportMizan GetComapanyCumulativeBeyan(int _year, long _compID)
        {
            ReportMizan rn = new ReportMizan
            {
                ProfitOrLoss = Get_ProfitOrLossMizan(_year, _compID) != null ? Get_ProfitOrLossMizan(_year, _compID).Amount : 0,
                TotalAssets = Get_TotalAssetsMizan(_year, _compID) != null ? Get_TotalAssetsMizan(_year, _compID).Amount : 0,
                TotalEquity = Get_TotalEquityMizan(_year, _compID) != null ? Get_TotalEquityMizan(_year, _compID).Amount : 0,
                TotalLiability = Get_TotalLiabilityMizan(_year, _compID) != null ? Get_TotalLiabilityMizan(_year, _compID).Amount : 0,
                TrialBalance = Get_TrialBalanceMizan(_year, _compID) != null ? Get_TrialBalanceMizan(_year, _compID).Amount : 0
            };
            return rn;
        }
    }
}
