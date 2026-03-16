using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Data;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;
using System.IO.Compression;
using System.Xml.Serialization;

namespace FinanceCheckUp.Application.Managers.StaticManagers;

public interface IXmlCheckerManager : IGenericDapperRepository
{
    string XmlCheck(bool xmltypeid, int isupdate, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalName, bool IsLastMOnth);
    string NominalCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth);
    string UpdateChek(int CsvID, List<Dataz> ttest, int monthid, long compid);
    string NominalCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth);
    string SapEntegratorSet(bool isZip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname);
    string SapEntegratorSetUpon(long compid, string filemonth, string fileyear, int sortide_);
    string SapEntegratorSetUpdate(bool iszzip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname);
    string SapEntegratorCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth);
    string SapEntegratorCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth);

}
public class XmlCheckerManager(
    FinanceCheckUpDbContext _dbContext,
    ITBLXmlManager tBLXmlManager,
    IDataManager dataManager,
    ITBLXmlFileManager tBLXmlFileManager,
    IDatazManager datazManager,
IMainDashManager mainDashManager,
    IDatazRepository datazRepository,
    IERRLOGManager eRRLOGManager) : GenericDapperRepositoryBase(_dbContext), IXmlCheckerManager
{


    public string XmlCheck(bool xmltypeid, int isupdate, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalName, bool IsLastMOnth)
    {

        switch (xmltypeid)
        {
            case false:
                if (isupdate == 0)
                {
                    return NominalCheck(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                    // return IsbankCheck(compid, pathfile, filemonth, fileyear);
                }
                else
                {
                    return NominalCheckUpdate(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                    //  return IsbankCheckUpdate(compid, pathfile, filemonth, fileyear);

                };
            case true:
                if (isupdate == 0)
                {
                    return SapEntegratorCheck(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                    //return UyumsoftCheck(compid, pathfile, filemonth, fileyear);
                }
                else
                {
                    return SapEntegratorCheckUpdate(compid, pathfile, filemonth, fileyear, fzip, orjinalName, IsLastMOnth);
                    // return UyumsoftCheckUpdate(compid, pathfile, filemonth, fileyear);

                };
        }
    }
    public string NominalCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
    {
        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));

        try
        {
            for (int i = 0; i < fzip.Count; i++)
            {
                using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                {
                    result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);
                }
                resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
            }
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = 9999;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);
            var chk = ex;
            return "nok";
        }
        var chkkky1 = resultt;

        result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

        string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        long csidemain = 0;
        if (mMonth == filemonth && myear == fileyear)
        {
            try
            {
                string filename = Path.GetFileName(fzip[0]);
                Tblxml ncs = new Tblxml();
                ncs.CompanyId = compid;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = DateTime.Now;
                ncs.CsvName = filename;
                ncs.XmlDocName = filenameorjinal;
                tBLXmlManager.Save_TBLXml(ncs);
                csidemain = ncs.Id;
                var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);

                ncs.Year = ttest[0].EndDate.Year;
                ncs.DocumentDate = ttest[0].EndDate;
                tBLXmlManager.Update_TBLXml(ncs);

                Data dat = new Data();

                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                }, CancellationToken.None);

                dataManager.SetOpener(ncs.Id, mMonth, IsLastMOnth);

                Data dtx = new Data();

                dataManager.SetHataLast(ncs.Id);

                dataManager.SetHataLastz(ncs.Id);


                dataManager.SetHataLastza(Convert.ToInt32(ncs.CompanyId), ttest[0].EndDate.Year);



                DataViewerErroredCountCsv SetCounteR = mainDashManager.Get_DatabyErrorbyCsv(ncs.Id);

                return ncs.Id.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = csidemain;
                lg.ERLOG = ex.ToString();
                eRRLOGManager.Save_AppLogs(lg);
                var chk = ex;
                tBLXmlManager.RESET_TBLXml(csidemain);
                return "nok";
            }

        }
        else
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = 5555;
            lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
            eRRLOGManager.Save_AppLogs(lg);
            return "nok";
        }

    }
    public string UpdateChek(int CsvID, List<Dataz> ttest, int monthid, long compid)
    {
        try
        {

            tBLXmlManager.RESET_TBLXmlUpdate(CsvID);


            Data dat = new Data();
            datazRepository.BulkInsert(new BulkUploadToSqlOptions
            {
                InternalStore = ttest,
                TableName = "[TBLXMLSource]",
                CommitBatchSize = 50000,
            }, CancellationToken.None);

            Data dtx = new Data();
            dataManager.SetHataLast(CsvID);
            dataManager.SetHataLastz(CsvID);
            dataManager.SetHataLastza(Convert.ToInt32(compid), ttest[0].EndDate.Year);



            DataViewerErroredCountCsv SetCounteR = mainDashManager.Get_DatabyErrorbyCsv(CsvID);

            return CsvID.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = CsvID;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);
            var chk = ex;

            return "nok";
        }



    }
    public string NominalCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
    {
        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        try
        {
            for (int i = 0; i < fzip.Count; i++)
            {
                using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                {
                    result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);
                }
                resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
            }
        }
        catch (Exception ex)
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = 9999;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);

            return "nok";
        }


        var chkkky1 = resultt;

        result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();
        string mMonth = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Month.ToString();
        string myear = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value.Year.ToString();
        long csidemain = 0;
        if (mMonth == filemonth && myear == fileyear)
        {
            try
            {
                string filename = Path.GetFileName(fzip[0]);
                Tblxml ncs = new Tblxml();
                ncs.CompanyId = compid;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = DateTime.Now;
                ncs.CsvName = filename;
                ncs.XmlDocName = filenameorjinal;
                tBLXmlManager.Save_TBLXml(ncs);
                csidemain = ncs.Id;
                var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);

                ncs.Year = ttest[0].EndDate.Year;
                ncs.DocumentDate = ttest[0].EndDate;
                tBLXmlManager.Update_TBLXml(ncs);
                //var nlistMon = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == Convert.ToInt32(fileyear) && x.DocumentDate.Month == Convert.ToInt32(filemonth) && x.ID != ncs.ID) ;
                //foreach (var item in nlistMon)
                //{
                //    TBLXml.RESET_TBLXml(item.ID);
                //}
                tBLXmlManager.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.Id);

                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                Data dat = new Data();
                // dat.InsertTB(ttest);
                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                }, CancellationToken.None);

                dataManager.SetOpener(ncs.Id, mMonth, IsLastMOnth);







                Data dtx = new Data();
                dataManager.SetHataLast(ncs.Id);
                dataManager.SetHataLastz(ncs.Id);
                dataManager.SetHataLastza(Convert.ToInt32(ncs.CompanyId), ttest[0].EndDate.Year);



                DataViewerErroredCountCsv SetCounteR = mainDashManager.Get_DatabyErrorbyCsv(ncs.Id);

                return ncs.Id.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
            }
            catch (Exception ex)
            {
                ERRLOG lg = new ERRLOG();
                lg.CompanyID = compid;
                lg.CsvID = csidemain;
                lg.ERLOG = ex.ToString();
                tBLXmlManager.RESET_TBLXml(csidemain);
                eRRLOGManager.Save_AppLogs(lg);
                return "nok";
            }

        }
        else
        {
            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = 5555;
            lg.ERLOG = filemonth + "  " + fileyear + " tarihli";
            eRRLOGManager.Save_AppLogs(lg);
            return "nok";
        }

    }

    public string SapEntegratorSet(bool isZip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname)
    {

        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
        string uploadsurl = pathfile;
        TblxmlFile nfile = new TblxmlFile();
        //  System.Diagnostics.Process.Start(filenameToStart,username,password,domain);
        int countre = 0;
        long csidemain = 0;
        string mMonth = string.Empty;
        string myear = string.Empty;
        try
        {

            if (isZip)
            {
                for (int i = 0; i < fzip.Count(); i++)
                {
                    using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                            entry.ExtractToFile(filepathz);
                            countre++;
                            if (countre == 1)
                            {


                                using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                                {
                                    result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                                }

                                DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                                mMonth = selectedDate.Month.ToString();
                                myear = selectedDate.Year.ToString();
                                tBLXmlManager.DeleteComapnyIDByMonth(compid, selectedDate.Year, selectedDate.Month);
                                Tblxml ncs = new Tblxml();
                                ncs.CompanyId = compid;
                                ncs.CreatedDate = DateTime.Now;
                                ncs.DocumentDate = selectedDate;
                                ncs.Year = selectedDate.Year;
                                ncs.CsvName = filepathz;
                                ncs.XmlDocName = orjinalname;
                                ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                                csidemain = ncs.Id;

                                var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);


                                Data dat = new Data();
                                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                                // dat.InsertTB(ttest);
                                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                                {
                                    InternalStore = ttest,
                                    TableName = "[TBLXMLSource]",
                                    CommitBatchSize = 50000,
                                }, CancellationToken.None);

                                mainDashManager.Get_DatabyErrorV1(selectedDate.Year, compid, selectedDate.Month);
                            }
                            nfile = new TblxmlFile();
                            nfile.SortId = countre;
                            nfile.CsvName = filepathz;
                            nfile.TblxmlId = csidemain;
                            nfile.Id = tBLXmlFileManager.Save_TBLXmlFile(nfile);
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < fzip.Count(); i++)
                {
                    countre++;
                    if (countre == 1)
                    {
                        using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                        {
                            result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                        }

                        DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                        mMonth = selectedDate.Month.ToString();
                        myear = selectedDate.Year.ToString();
                        tBLXmlManager.DeleteComapnyIDByMonth(compid, selectedDate.Year, selectedDate.Month);
                        Tblxml ncs = new Tblxml();
                        ncs.CompanyId = compid;
                        ncs.CreatedDate = DateTime.Now;
                        ncs.DocumentDate = selectedDate;
                        ncs.Year = selectedDate.Year;
                        ncs.CsvName = fzip[i];
                        ncs.XmlDocName = orjinalname;
                        ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                        csidemain = ncs.Id;

                        var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);


                        Data dat = new Data();
                        //foreach (var item in ttest)
                        //{

                        //dat.InsertTB(ttest);
                        //}
                        ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                        datazRepository.BulkInsert(new BulkUploadToSqlOptions
                        {
                            InternalStore = ttest,
                            TableName = "[TBLXMLSource]",
                            CommitBatchSize = 50000,
                        }, CancellationToken.None);


                    }
                    nfile = new TblxmlFile();
                    nfile.SortId = countre;
                    nfile.CsvName = fzip[i];
                    nfile.TblxmlId = csidemain;
                    nfile.Id = tBLXmlFileManager.Save_TBLXmlFile(nfile);
                }
            }



        }
        catch (Exception ex)
        {

            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = csidemain;
            lg.ERLOG = ex.ToString();
            eRRLOGManager.Save_AppLogs(lg);
            return "nok";
        }

        TblxmlFile uploadsTBLXmlFile = tBLXmlFileManager.Get_TBLXmlFile(csidemain, 1);
        tBLXmlFileManager.Update_TBLXmlFile(uploadsTBLXmlFile);
        tBLXmlFileManager.Finish_TBLXmlFile(uploadsTBLXmlFile);
        return "2_" + uploadsTBLXmlFile.LastSettedCount.ToString();
    }

    public string SapEntegratorSetUpon(long compid, string filemonth, string fileyear, int sortide_)
    {
        int txmlid = tBLXmlManager.GetComapnyIDByMonth(compid, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear));

        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
        TblxmlFile uploadsTBLXmlFile = tBLXmlFileManager.Get_TBLXmlFile(txmlid, sortide_);
        TblxmlFile nfile = new TblxmlFile();



        string mMonth = string.Empty;
        string myear = string.Empty;
        try
        {



            string filepathz = uploadsTBLXmlFile.CsvName;


            using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
            {
                result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

            }

            DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
            mMonth = selectedDate.Month.ToString();
            myear = selectedDate.Year.ToString();
            if (mMonth != filemonth || myear != fileyear)
            {
                return "nok";
            }
            else
            {

                var ttest = DatazHelper.SetValueFromNominal(result, txmlid);


                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                }, CancellationToken.None);

            }

            tBLXmlFileManager.Update_TBLXmlFile(uploadsTBLXmlFile);
            tBLXmlFileManager.Finish_TBLXmlFile(uploadsTBLXmlFile);
        }
        catch (Exception ex)
        {

            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = txmlid;
            lg.ERLOG = ex.ToString();
            return "nok";
        }


        return (sortide_ + 1).ToString() + "_" + uploadsTBLXmlFile.LastSettedCount.ToString();

    }
    public string SapEntegratorSetUpdate(bool iszzip, long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string orjinalname)
    {
        long txmlid = tBLXmlManager.GetComapnyIDByMonth(compid, Convert.ToInt32(filemonth), Convert.ToInt32(fileyear));

        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
        string uploadsurl = pathfile;
        TblxmlFile nfile = new TblxmlFile();


        int countre = 0;
        string mMonth = string.Empty;
        string myear = string.Empty;
        try
        {
            if (iszzip)
            {

                for (int i = 0; i < fzip.Count(); i++)
                {
                    using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                    {
                        foreach (ZipArchiveEntry entry in archive.Entries)
                        {
                            string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                            entry.ExtractToFile(filepathz);
                            countre++;
                            if (countre == 1)
                            {
                                using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                                {
                                    result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                                }

                                DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                                mMonth = selectedDate.Month.ToString();
                                myear = selectedDate.Year.ToString();
                                if (mMonth != filemonth || myear != fileyear)
                                {
                                    return "nok";
                                }
                                else
                                {
                                    tBLXmlFileManager.Delete_TBLXmlIDlist(txmlid);
                                    Tblxml ncs = new Tblxml();
                                    ncs.CompanyId = compid;
                                    ncs.CreatedDate = DateTime.Now;
                                    ncs.DocumentDate = selectedDate;
                                    ncs.Year = selectedDate.Year;
                                    ncs.CsvName = filepathz;
                                    ncs.XmlDocName = orjinalname;
                                    ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                                    txmlid = ncs.Id;

                                    //var ttest = Dataz.SetValueFromNominal(result, txmlid);
                                    tBLXmlManager.RESETALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.Id);
                                    var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);


                                    Data dat = new Data();

                                    ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                                    datazRepository.BulkInsert(new BulkUploadToSqlOptions
                                    {
                                        InternalStore = ttest,
                                        TableName = "[TBLXMLSource]",
                                        CommitBatchSize = 50000,
                                    }, CancellationToken.None);
                                }
                            }

                            //  resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                            nfile = new TblxmlFile();
                            nfile.CsvName = filepathz;
                            nfile.SortId = countre;
                            nfile.TblxmlId = txmlid;
                            nfile.Id = tBLXmlFileManager.Save_TBLXmlFile(nfile);
                        }

                    }
                }

            }
            else
            {
                for (int i = 0; i < fzip.Count(); i++)
                {



                    countre++;
                    if (countre == 1)
                    {
                        using (FileStream fileStream = new FileStream(fzip[i], FileMode.Open))
                        {
                            result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                        }

                        DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                        mMonth = selectedDate.Month.ToString();
                        myear = selectedDate.Year.ToString();
                        if (mMonth != filemonth || myear != fileyear)
                        {
                            return "nok";
                        }
                        else
                        {
                            tBLXmlFileManager.Delete_TBLXmlIDlist(txmlid);
                            Tblxml ncs = new Tblxml();
                            ncs.CompanyId = compid;
                            ncs.CreatedDate = DateTime.Now;
                            ncs.DocumentDate = selectedDate;
                            ncs.Year = selectedDate.Year;
                            ncs.CsvName = fzip[i];
                            ncs.XmlDocName = orjinalname;
                            ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                            txmlid = ncs.Id;

                            //var ttest = Dataz.SetValueFromNominal(result, txmlid);
                            tBLXmlManager.RESETALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.Id);
                            int chkeson = 3;


                            while (chkeson > 1)
                            {
                                chkeson = tBLXmlManager.GetCountALL_byCompanyIDMulti(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.Id);
                                Thread.Sleep(500);
                            }


                            var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);


                            Data dat = new Data();

                            ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();


                            datazRepository.BulkInsert(new BulkUploadToSqlOptions
                            {
                                InternalStore = ttest,
                                TableName = "[TBLXMLSource]",
                                CommitBatchSize = 50000,
                            }, CancellationToken.None);

                        }
                    }

                    //  resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                    nfile = new TblxmlFile();
                    nfile.CsvName = fzip[i];
                    nfile.SortId = countre;
                    nfile.TblxmlId = txmlid;
                    nfile.Id = tBLXmlFileManager.Save_TBLXmlFile(nfile);

                }
            }
            //TBLXmlFile._SetFirstSetted(txmlid);
            TblxmlFile uploadsTBLXmlFile = tBLXmlFileManager.Get_TBLXmlFile(txmlid, 1);
            tBLXmlFileManager.Update_TBLXmlFile(uploadsTBLXmlFile);

            tBLXmlFileManager.Finish_TBLXmlFile(uploadsTBLXmlFile);
            return "2_" + uploadsTBLXmlFile.LastSettedCount.ToString();

        }
        catch (Exception ex)
        {

            ERRLOG lg = new ERRLOG();
            lg.CompanyID = compid;
            lg.CsvID = txmlid;
            lg.ERLOG = ex.ToString();
            return "nok";
        }



    }

    public string SapEntegratorCheck(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
    {
        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
        string uploadsurl = pathfile;

        try
        {
            for (int i = 0; i < fzip.Count(); i++)
            {
                using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                        entry.ExtractToFile(filepathz);
                        using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                        {
                            result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                        }
                        resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                    }

                }
            }

        }
        catch (Exception ex)
        {

            var chk = ex;
            return "nok";
        }
        var chkkky1 = resultt;

        result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

        DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
        string mMonth = selectedDate.Month.ToString();
        string myear = selectedDate.Year.ToString();
        long csidemain = 0;

        //return "nok";
        if (mMonth == filemonth && myear == fileyear)
        {
            try
            {
                string filename = Path.GetFileName(fzip[0]);
                Tblxml ncs = new Tblxml();
                ncs.CompanyId = compid;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = DateTime.Now; ncs.CsvName = filename;
                ncs.XmlDocName = filenameorjinal;
                ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                csidemain = ncs.Id;
                var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);

                ncs.Year = selectedDate.Year;
                ncs.DocumentDate = selectedDate;
                tBLXmlManager.Update_TBLXml(ncs);
                //Data dat = new Data();

                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                }, CancellationToken.None);

                dataManager.SetOpener(ncs.Id, mMonth, IsLastMOnth);






                Data dtx = new Data();

                dataManager.SetHataLast(ncs.Id);

                dataManager.SetHataLastz(ncs.Id);


                dataManager.SetHataLastza(Convert.ToInt32(ncs.CompanyId), Convert.ToInt32(fileyear));



                DataViewerErroredCountCsv SetCounteR = mainDashManager.Get_DatabyErrorbyCsv(ncs.Id);

                return ncs.Id.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
            }
            catch (Exception ex)
            {
                var chh = ex;
                tBLXmlManager.RESET_TBLXml(csidemain);
                return "nok";
            }

        }
        else
        {
            return "nok";
        }

    }

    public string SapEntegratorCheckUpdate(long compid, string pathfile, string filemonth, string fileyear, List<string> fzip, string filenameorjinal, bool IsLastMOnth)
    {
        List<Common.Utilities.NominalXML.accountingEntriesEntryHeader> resultt = new List<Common.Utilities.NominalXML.accountingEntriesEntryHeader>();
        Common.Utilities.NominalXML.defter result = new Common.Utilities.NominalXML.defter();
        XmlSerializer serializerz = new XmlSerializer(typeof(Common.Utilities.NominalXML.defter));
        List<ZipArchiveEntry> nlistZip = new List<ZipArchiveEntry>();
        string uploadsurl = pathfile;

        try
        {


            for (int i = 0; i < fzip.Count(); i++)
            {
                using (ZipArchive archive = ZipFile.OpenRead(fzip[i]))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        string filepathz = Path.Combine(uploadsurl, fzip[i].Substring(0, fzip[i].Length - 3) + "xml");
                        entry.ExtractToFile(filepathz);
                        using (FileStream fileStream = new FileStream(filepathz, FileMode.Open))
                        {
                            result = (Common.Utilities.NominalXML.defter)serializerz.Deserialize(fileStream);

                        }
                        resultt.AddRange(result.xbrl.accountingEntries.entryHeader);
                    }

                }
            }



        }
        catch (Exception ex)
        {

            var chk = ex;
            return "nok";
        }
        var chkkky1 = resultt;

        result.xbrl.accountingEntries.entryHeader = chkkky1.ToArray();

        DateTime selectedDate = result.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
        string mMonth = selectedDate.Month.ToString();
        string myear = selectedDate.Year.ToString();
        long csidemain = 0;
        if (mMonth == filemonth && myear == fileyear)
        {
            try
            {
                string filename = Path.GetFileName(fzip[0]);
                Tblxml ncs = new Tblxml();
                ncs.CompanyId = compid;
                ncs.CreatedDate = DateTime.Now;
                ncs.DocumentDate = DateTime.Now; ncs.CsvName = filename;
                ncs.XmlDocName = filenameorjinal;
                ncs.Id = tBLXmlManager.Save_TBLXml(ncs);
                csidemain = ncs.Id;
                var ttest = DatazHelper.SetValueFromNominal(result, ncs.Id);

                ncs.Year = selectedDate.Year;
                ncs.DocumentDate = selectedDate;
                tBLXmlManager.Update_TBLXml(ncs);
                //TBLXml ncs1 = TBLXml.Get_TBLXmlCompany(ncs.CompanyID.ToString()).Where(x => x.DocumentDate.Year == ttest[0][0].EndDate.Year && x.DocumentDate.Month == ttest[0][0].EndDate.Month && x.ID != ncs.ID).FirstOrDefault();

                //TBLXml.RESET_TBLXml(ncs1.ID);
                tBLXmlManager.RESETALL_byCompanyID(Convert.ToInt32(fileyear), compid, Convert.ToInt32(mMonth), ncs.Id);


                ttest = ttest.Select(c => { c.IsPassedEntry = 0; return c; }).ToList();

                // dat.InsertTB(ttest);
                datazRepository.BulkInsert(new BulkUploadToSqlOptions
                {
                    InternalStore = ttest,
                    TableName = "[TBLXMLSource]",
                    CommitBatchSize = 50000,
                }, CancellationToken.None);
                //Data dat = new Data();
                //foreach (var item in ttest)
                //{
                //    dat.InsertTB(item);

                //}


                dataManager.SetOpener(ncs.Id, mMonth, IsLastMOnth);







                Data dtx = new Data();

                dataManager.SetHataLast(ncs.Id);

                dataManager.SetHataLastz(ncs.Id);


                dataManager.SetHataLastza(Convert.ToInt32(ncs.CompanyId), selectedDate.Year);


                DataViewerErroredCountCsv SetCounteR = mainDashManager.Get_DatabyErrorbyCsv(ncs.Id);

                return ncs.Id.ToString() + "_" + SetCounteR.TotalRow.ToString() + "_" + SetCounteR.EntryErrorCount.ToString();
            }
            catch
            {
                tBLXmlManager.RESET_TBLXml(csidemain);
                return "nok";
            }

        }
        else
        {
            return "nok";
        }


    }


}
