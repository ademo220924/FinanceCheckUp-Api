using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollectionBlncMzn : List<DashBilancoViewMizan>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {

        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                   new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 15),
                   new SqlMetaData("Amount", SqlDbType.Float),
                   new SqlMetaData("CompanyID", SqlDbType.BigInt),
                   new SqlMetaData("Year", SqlDbType.Int),
                   new SqlMetaData("GroupName", SqlDbType.VarChar, 350),
                   new SqlMetaData("CounterZone", SqlDbType.Int),
                   new SqlMetaData("TypeID", SqlDbType.Int),
                   new SqlMetaData("IsHidden", SqlDbType.Int)
                   );
        foreach (DashBilancoViewMizan cust in this)
        {
            sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID);
            sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription);
            sqlRow.SetString(2, string.Empty);
            sqlRow.SetDouble(3, cust.Amount);
            sqlRow.SetInt64(4, cust.CompanyID);
            sqlRow.SetInt32(5, cust.Year);
            sqlRow.SetString(6, cust.GroupName);
            sqlRow.SetInt32(7, cust.CounterZone);
            sqlRow.SetInt32(8, cust.TypeID);
            sqlRow.SetInt32(9, cust.IsHidden);
            yield return sqlRow;
        }
    }
}
