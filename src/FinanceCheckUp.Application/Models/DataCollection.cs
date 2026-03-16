using FinanceCheckUp.Domain.Common;
using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollection : List<Dataz>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {

        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("StartDate", SqlDbType.VarChar, 150),
                   new SqlMetaData("EndDate", SqlDbType.DateTime),
                   new SqlMetaData("EnteredBy", SqlDbType.VarChar, 100),
                   new SqlMetaData("EnteredDate", SqlDbType.VarChar, 100),
                   new SqlMetaData("EntryNumber", SqlDbType.VarChar, 10),
                   new SqlMetaData("EntryComment", SqlDbType.VarChar, 450),
                   new SqlMetaData("BatchID", SqlDbType.VarChar, 100),
                   new SqlMetaData("BatchDescription", SqlDbType.VarChar, 100),
                   new SqlMetaData("TotalDebit", SqlDbType.Float),
                   new SqlMetaData("TotalCredit", SqlDbType.Float),
                   new SqlMetaData("DocumentType", SqlDbType.VarChar, 150),
                   new SqlMetaData("DocumentTypeDescription", SqlDbType.VarChar, 400),
                   new SqlMetaData("DocumentNumber", SqlDbType.VarChar, 100),
                   new SqlMetaData("DocumentDate", SqlDbType.VarChar, 110),
                   new SqlMetaData("PaymentMethod", SqlDbType.VarChar, 150),
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 100),
                   new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 400),
                   new SqlMetaData("AccountSubDescription", SqlDbType.VarChar, 440),
                   new SqlMetaData("AccountSubID", SqlDbType.VarChar, 100),
                   new SqlMetaData("Amount", SqlDbType.Float),
                   new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 150),
                   new SqlMetaData("PostingDate", SqlDbType.VarChar, 100),
                   new SqlMetaData("DetailComment", SqlDbType.VarChar, 400),
                   new SqlMetaData("CsvID", SqlDbType.Int));
        foreach (Dataz cust in this)
        {
            sqlRow.SetString(0, cust.StartDate);
            sqlRow.SetDateTime(1, cust.EndDate);
            sqlRow.SetString(2, cust.EnteredBy);
            sqlRow.SetString(3, cust.EnteredDate);
            sqlRow.SetString(4, cust.EntryNumber);
            sqlRow.SetString(5, cust.EntryComment);
            sqlRow.SetString(6, cust.BatchID);
            sqlRow.SetString(7, cust.BatchDescription);
            sqlRow.SetDouble(8, cust.TotalDebit);
            sqlRow.SetDouble(9, cust.TotalCredit);
            sqlRow.SetString(10, cust.DocumentType);
            sqlRow.SetString(11, cust.DocumentTypeDescription);
            sqlRow.SetString(12, cust.DocumentNumber);
            sqlRow.SetString(13, cust.DocumentDate);
            sqlRow.SetString(14, cust.PaymentMethod);
            sqlRow.SetString(15, cust.AccountMainID);
            sqlRow.SetString(16, cust.AccountMainDescription);
            sqlRow.SetString(17, cust.AccountSubDescription);
            sqlRow.SetString(18, cust.AccountSubID);
            sqlRow.SetDouble(19, cust.Amount);
            sqlRow.SetString(20, cust.DebitCreditCode);
            sqlRow.SetString(21, cust.PostingDate);
            sqlRow.SetString(22, cust.DetailComment);
            sqlRow.SetInt64(23, cust.CsvID);
            yield return sqlRow;
        }
    }
}
