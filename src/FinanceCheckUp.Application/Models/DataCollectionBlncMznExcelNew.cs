using FinanceCheckUp.Application.Models.Common;
using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollectionBlncMznExcelNew : List<XmlExcel>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {
        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                   new SqlMetaData("AmountBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("DebitBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("CreditBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("CompanyID", SqlDbType.BigInt),
                   new SqlMetaData("Year", SqlDbType.Int),
                   new SqlMetaData("Month", SqlDbType.Int),
                   new SqlMetaData("CsvID", SqlDbType.BigInt)

                   );
        foreach (XmlExcel cust in this)
        {
            sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
            sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
            sqlRow.SetDouble(2, cust.AmountBakiyeFloat);
            sqlRow.SetDouble(3, cust.DebitAmountFloat);
            sqlRow.SetDouble(4, cust.CreditAmountFloat);
            sqlRow.SetInt64(5, cust.CompanyId);
            sqlRow.SetInt32(6, cust.Year);
            sqlRow.SetInt32(7, cust.MainMonth);
            sqlRow.SetInt64(8, cust.CsvId);
            yield return sqlRow;
        }
    }
}
