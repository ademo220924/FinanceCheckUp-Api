using FinanceCheckUp.Application.Models.ViewModel.Mizan;
using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollectionBlncMznExcelPdf : List<TBLXMLSCheckpdfMizan>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {
        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 250),
                   new SqlMetaData("Amount1", SqlDbType.Float),
                   new SqlMetaData("Amount1Diff", SqlDbType.Int),
                   new SqlMetaData("Amount2", SqlDbType.Float),
                   new SqlMetaData("Amount2Diff", SqlDbType.Int),
                   new SqlMetaData("Amount3", SqlDbType.Float),
                   new SqlMetaData("Amount3Diff", SqlDbType.Int),
                   new SqlMetaData("Amount4", SqlDbType.Float),
                   new SqlMetaData("Amount4Diff", SqlDbType.Int),
                   new SqlMetaData("CompanyID", SqlDbType.BigInt),
                   new SqlMetaData("Year", SqlDbType.Int),
                   new SqlMetaData("PageID", SqlDbType.Int),
                   new SqlMetaData("MainMonth", SqlDbType.TinyInt)
                   );
        foreach (TBLXMLSCheckpdfMizan cust in this)
        {
            sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
            sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
            sqlRow.SetDouble(2, cust.Amount1);
            sqlRow.SetInt32(3, cust.Amount1Diff);
            sqlRow.SetDouble(4, cust.Amount2);
            sqlRow.SetInt32(5, cust.Amount2Diff);
            sqlRow.SetDouble(6, cust.Amount3);
            sqlRow.SetInt32(7, cust.Amount3Diff);
            sqlRow.SetDouble(8, cust.Amount4);
            sqlRow.SetInt32(9, cust.Amount4Diff);
            sqlRow.SetInt64(10, cust.CompanyID);
            sqlRow.SetInt32(11, cust.Year);
            sqlRow.SetInt32(12, cust.PageID);
            sqlRow.SetByte(13, cust.MainMonth);
            yield return sqlRow;
        }
    }
}
