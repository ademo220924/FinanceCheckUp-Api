using FinanceCheckUp.Application.Models.Common;
using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollectionBlncMznExcelSub : List<XmlExcel>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {
        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountSubID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountSubDescription", SqlDbType.VarChar, 350),
                   new SqlMetaData("AmountBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("DebitBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("CreditBakiyeFloat", SqlDbType.Float),
                   new SqlMetaData("CompanyID", SqlDbType.BigInt),
                   new SqlMetaData("Year", SqlDbType.Int)
                   );
        foreach (XmlExcel cust in this)
        {
            sqlRow.SetString(0, cust.AccountMainIDMain == null ? string.Empty : cust.AccountMainIDMain.Trim());
            sqlRow.SetString(1, cust.AccountMainID == null ? string.Empty : cust.AccountMainID.Trim());
            sqlRow.SetString(2, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription.Trim());
            sqlRow.SetDouble(3, cust.AmountBakiyeFloat);
            sqlRow.SetDouble(4, cust.DebitAmountFloat);
            sqlRow.SetDouble(5, cust.CreditAmountFloat);
            sqlRow.SetInt64(6, cust.CompanyId);
            sqlRow.SetInt32(7, cust.Year);
            yield return sqlRow;
        }
    }
}
