using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Domain.Common;


namespace FinanceCheckUp.Application.ExtensionHelpers;
public static class DatazHelper
{
    public static Dataz FromCsv(string csvLine)
    {
        string[] values = csvLine.Split(';');
        Dataz dailyValues = new Dataz();
        dailyValues.StartDate = values[0].ToString();
        dailyValues.EndDate = Convert.ToDateTime(values[1].ToString());
        dailyValues.EnteredBy = values[2].ToString();
        dailyValues.EnteredDate = values[3].ToString();
        dailyValues.EntryNumber = values[4].ToString();
        dailyValues.EntryComment = values[5].ToString();
        dailyValues.BatchID = values[6].ToString();
        dailyValues.BatchDescription = values[7].ToString();
        dailyValues.TotalDebit = Convert.ToDouble(values[8]);
        dailyValues.TotalCredit = Convert.ToDouble(values[9]);
        dailyValues.DocumentType = values[10].ToString();
        dailyValues.DocumentTypeDescription = values[11].ToString();
        dailyValues.DocumentNumber = values[12].ToString();
        dailyValues.DocumentDate = values[13].ToString();
        dailyValues.PaymentMethod = values[14].ToString();
        dailyValues.AccountMainID = values[15].ToString();
        dailyValues.AccountMainDescription = values[16].ToString();
        dailyValues.AccountSubDescription = values[17].ToString();
        dailyValues.AccountSubID = values[18].ToString();
        dailyValues.Amount = Convert.ToDouble(values[19]);
        dailyValues.DebitCreditCode = values[20].ToString();
        dailyValues.PostingDate = values[21].ToString();
        dailyValues.DetailComment = values[22].ToString();
        return dailyValues;
    }

    public static DataCollection SetValueFromXMlIsbank(Common.Utilities.IsbankXML.defter ndefter, long csvid)
    {

        DataCollection nlist = new DataCollection();
        Dataz dt = new();
        foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
        {

            foreach (var itemz in item.entryDetail)
            {
                dt = new Dataz();
                dt.AccountMainDescription = itemz.account.accountMainDescription.Value.ToString();
                dt.AccountMainID = itemz.account.accountMainID.Value.ToString();
                dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value.ToString();
                dt.AccountSubID = itemz.account.accountSub.accountSubID.Value.ToString();
                dt.Amount = (double)itemz.amount.Value;
                dt.BatchID = itemz.documentReference.Value.ToString();
                dt.BatchDescription = string.Empty;
                dt.CsvID = csvid;
                dt.DebitCreditCode = itemz.debitCreditCode.Value.ToString();
                dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                dt.DocumentDate = item.enteredDate.Value.ToString();
                dt.DocumentNumber = item.entryNumber.Value.ToString();
                dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                dt.DocumentTypeDescription = itemz.documentTypeDescription == null ? string.Empty : itemz.documentTypeDescription.Value;
                dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                dt.EnteredBy = item.enteredBy.Value;
                dt.EnteredDate = item.enteredDate.Value.ToString();
                dt.EntryComment = item.entryComment.Value.ToString();
                dt.EntryNumber = item.entryNumber.Value.ToString();
                dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                dt.PostingDate = itemz.postingDate.Value.ToString();
                dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                dt.TotalCredit = (double)item.totalCredit.Value;
                dt.TotalDebit = (double)item.totalDebit.Value;
                dt.UpdatedDate = DateTime.Now;
                nlist.Add(dt);
            }


        }





        return nlist;



    }

    public static List<Dataz> SetValueFromNominal(FinanceCheckUp.Application.Common.Utilities.NominalXML.defter ndefter, long csvid)
    {

        List<Dataz> nlist = new List<Dataz>();
        Dataz dt = new Dataz();
        foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
        {


            nlist.AddRange(item.entryDetail.Select(x => new Dataz()
            {

                AccountMainDescription = x.account.accountMainDescription.Value,
                AccountMainID = x.account.accountMainID.Value,
                AccountSubID = x.account.accountSub == null ? x.account.accountMainID.Value + ".000" : x.account.accountSub.accountSubID.Value,
                AccountSubDescription = x.account.accountSub == null ? "000" : x.account.accountSub.accountSubDescription.Value,
                Amount = (double)x.amount.Value,
                BatchID = x.documentReference == null ? string.Empty : x.documentReference.Value,
                BatchDescription = string.Empty,
                DebitCreditCode = x.debitCreditCode.Value,
                DetailComment = x.detailComment == null ? string.Empty : x.detailComment.Value,
                DocumentDate = x.documentDate == null ? string.Empty : x.documentDate.Value.ToString(),
                DocumentNumber = x.documentNumber == null ? string.Empty : x.documentNumber.Value,
                DocumentType = x.documentType == null ? string.Empty : x.documentType.Value,
                DocumentTypeDescription = x.detailComment == null ? string.Empty : x.detailComment.Value,
                EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value,
                EnteredBy = item.enteredBy == null ? string.Empty : item.enteredBy.Value,
                EnteredDate = item.enteredDate == null ? string.Empty : item.enteredDate.Value.ToString(),
                EntryComment = item.entryComment == null ? string.Empty : item.entryComment.Value,
                EntryNumber = item.entryNumber == null ? string.Empty : item.entryNumber.Value.ToString(),
                PaymentMethod = x.paymentMethod == null ? string.Empty : x.paymentMethod.Value,
                PostingDate = x.postingDate == null ? string.Empty : x.postingDate.Value.ToString(),
                StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString(),
                TotalCredit = (double)item.totalCredit.Value,
                TotalDebit = (double)item.totalDebit.Value,
                CsvID = csvid,
                UpdatedDate = DateTime.Now

            }));


        }





        return nlist;



    }

    public static List<Dataz> SetValueFromBeyanname(List<BeyannameGeciciView> ndefter, long csvid, DateTime datum)
    {

        List<Dataz> nlist = new List<Dataz>();
        Dataz dt = new Dataz();



        nlist.AddRange(ndefter.Select(x => new Dataz()
        {

            AccountMainDescription = x.AccountMainDescription,
            AccountMainID = x.AccountMainID,
            AccountSubID = x.AccountMainID,
            AccountSubDescription = x.AccountMainDescription,
            Amount = x.Amount,
            BatchID = string.Empty,
            BatchDescription = string.Empty,
            DebitCreditCode = string.Empty,
            DetailComment = string.Empty,
            DocumentDate = datum.ToShortDateString(),
            DocumentNumber = string.Empty,
            DocumentType = string.Empty,
            DocumentTypeDescription = string.Empty,
            EndDate = datum,
            EnteredBy = string.Empty,
            EnteredDate = string.Empty,
            EntryComment = string.Empty,
            EntryNumber = string.Empty,
            PaymentMethod = string.Empty,
            PostingDate = datum.ToShortDateString(),
            StartDate = datum.ToShortDateString(),
            TotalCredit = x.Amount,
            TotalDebit = x.Amount,
            CsvID = csvid,
            UpdatedDate = DateTime.Now

        }));








        return nlist;



    }

    public static DataCollection SetValueFromXMluyumsoft(FinanceCheckUp.Application.Common.Utilities.UyumsoftXML.defter ndefter, long csvid)
    {

        DataCollection nlist = new DataCollection();
        Dataz dt = new Dataz();
        foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
        {

            foreach (var itemz in item.entryDetail)
            {
                dt = new Dataz();
                dt.AccountMainDescription = itemz.account.accountMainDescription.Value.ToString();
                dt.AccountMainID = itemz.account.accountMainID.Value.ToString();
                dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value.ToString();
                dt.AccountSubID = itemz.account.accountSub.accountSubID.Value.ToString();
                dt.Amount = (double)itemz.amount.Value;
                dt.BatchID = itemz.documentReference.Value.ToString();
                dt.BatchDescription = string.Empty;
                dt.CsvID = csvid;
                dt.DebitCreditCode = itemz.debitCreditCode.Value.ToString();
                dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                dt.DocumentDate = item.enteredDate.Value.ToString();
                dt.DocumentNumber = item.entryNumber.Value.ToString();
                dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                dt.DocumentTypeDescription = itemz.documentTypeDescription == null ? string.Empty : itemz.documentTypeDescription.Value;
                dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                dt.EnteredBy = item.enteredBy.Value;
                dt.EnteredDate = item.enteredDate.Value.ToString();
                dt.EntryComment = item.entryNumber == null ? string.Empty : item.entryNumber.Value.ToString();
                dt.EntryNumber = item.entryNumber.Value.ToString();
                dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                dt.PostingDate = itemz.postingDate.Value.ToString();
                dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                dt.TotalCredit = (double)item.totalCredit.Value;
                dt.TotalDebit = (double)item.totalDebit.Value;
                dt.UpdatedDate = DateTime.Now;
                nlist.Add(dt);
            }


        }





        return nlist;



    }

    public static List<DataCollection> SetValueFromXMlSapEntegrator(FinanceCheckUp.Application.Common.Utilities.NominalXML.defter ndefter, long csvid)
    {
        List<DataCollection> zlist = new List<DataCollection>();
        DataCollection nlist = new DataCollection();
        Dataz dt = new Dataz();
        int counter = 0;
        foreach (var item in ndefter.xbrl.accountingEntries.entryHeader)
        {

            foreach (var itemz in item.entryDetail)
            {
                counter++;
                dt = new Dataz();
                dt.AccountMainDescription = itemz.account.accountMainDescription.Value;
                dt.AccountMainID = itemz.account.accountMainID.Value;
                dt.AccountSubID = itemz.account.accountSub.accountSubID.Value;
                dt.AccountSubDescription = itemz.account.accountSub.accountSubDescription.Value;
                dt.Amount = (double)itemz.amount.Value;
                dt.BatchID = itemz.documentReference == null ? string.Empty : itemz.documentReference.Value;
                dt.BatchDescription = string.Empty;
                dt.DebitCreditCode = itemz.debitCreditCode.Value;
                dt.DetailComment = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                dt.DocumentDate = itemz.documentDate == null ? string.Empty : itemz.documentDate.Value.ToString();
                dt.DocumentNumber = itemz.documentNumber == null ? string.Empty : itemz.documentNumber.Value;
                dt.DocumentType = itemz.documentType == null ? string.Empty : itemz.documentType.Value;
                dt.DocumentTypeDescription = itemz.detailComment == null ? string.Empty : itemz.detailComment.Value;
                dt.EndDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredEnd.Value;
                dt.EnteredBy = item.enteredBy == null ? string.Empty : item.enteredBy.Value;
                dt.EnteredDate = item.enteredDate == null ? string.Empty : item.enteredDate.Value.ToString();
                dt.EntryComment = item.entryComment == null ? string.Empty : item.entryComment.Value;
                dt.EntryNumber = item.entryNumber.Value.ToString();
                dt.PaymentMethod = itemz.paymentMethod == null ? string.Empty : itemz.paymentMethod.Value;
                dt.PostingDate = itemz.postingDate == null ? string.Empty : itemz.postingDate.Value.ToString();
                dt.StartDate = ndefter.xbrl.accountingEntries.documentInfo.periodCoveredStart.Value.ToString();
                dt.TotalCredit = (double)item.totalCredit.Value;
                dt.TotalDebit = (double)item.totalDebit.Value;
                dt.CsvID = csvid;
                dt.UpdatedDate = DateTime.Now;
                nlist.Add(dt);
                if (counter > 100000)
                {
                    counter = 0;
                    zlist.Add(nlist);
                    nlist = new DataCollection();
                }
            }


        }

        if (nlist.Count > 0)
        {
            zlist.Add(nlist);
        }



        return zlist;



    }

}