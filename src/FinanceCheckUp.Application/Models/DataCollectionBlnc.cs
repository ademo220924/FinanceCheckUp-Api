using Microsoft.Data.SqlClient.Server;
using System.Data;


namespace FinanceCheckUp.Application.Models;
public class DataCollectionBlnc : List<DashBilancoView>, IEnumerable<SqlDataRecord>
{
    IEnumerator<SqlDataRecord> IEnumerable<SqlDataRecord>.GetEnumerator()
    {

        var sqlRow = new SqlDataRecord(
                   new SqlMetaData("AccountMainID", SqlDbType.VarChar, 50),
                   new SqlMetaData("AccountMainDescription", SqlDbType.VarChar, 350),
                   new SqlMetaData("DebitCreditCode", SqlDbType.VarChar, 15),
                   new SqlMetaData("Acilis", SqlDbType.Float),
                   new SqlMetaData("January", SqlDbType.Float),
                   new SqlMetaData("February", SqlDbType.Float),
                   new SqlMetaData("March", SqlDbType.Float),
                   new SqlMetaData("April", SqlDbType.Float),
                   new SqlMetaData("May", SqlDbType.Float),
                   new SqlMetaData("June", SqlDbType.Float),
                   new SqlMetaData("July", SqlDbType.Float),
                   new SqlMetaData("August", SqlDbType.Float),
                   new SqlMetaData("September", SqlDbType.Float),
                   new SqlMetaData("October", SqlDbType.Float),
                   new SqlMetaData("November", SqlDbType.Float),
                   new SqlMetaData("December", SqlDbType.Float),
                   new SqlMetaData("CompanyID", SqlDbType.BigInt),
                   new SqlMetaData("Year", SqlDbType.Int),
                   new SqlMetaData("GroupName", SqlDbType.VarChar, 350),
                   new SqlMetaData("CounterZone", SqlDbType.Int),
                   new SqlMetaData("TypeID", SqlDbType.Int),
                   new SqlMetaData("IsHidden", SqlDbType.Int)
                   );
        foreach (DashBilancoView cust in this)
        {
            sqlRow.SetString(0, cust.AccountMainID == null ? string.Empty : cust.AccountMainID);
            sqlRow.SetString(1, cust.AccountMainDescription == null ? string.Empty : cust.AccountMainDescription);
            sqlRow.SetString(2, string.Empty);
            sqlRow.SetDouble(3, cust.Acilis);
            sqlRow.SetDouble(4, cust.January);
            sqlRow.SetDouble(5, cust.February);
            sqlRow.SetDouble(6, cust.March);
            sqlRow.SetDouble(7, cust.April);
            sqlRow.SetDouble(8, cust.May);
            sqlRow.SetDouble(9, cust.June);
            sqlRow.SetDouble(10, cust.July);
            sqlRow.SetDouble(11, cust.August);
            sqlRow.SetDouble(12, cust.September);
            sqlRow.SetDouble(13, cust.October);
            sqlRow.SetDouble(14, cust.November);
            sqlRow.SetDouble(15, cust.December);
            sqlRow.SetInt64(16, cust.CompanyID);
            sqlRow.SetInt32(17, cust.Year);
            sqlRow.SetString(18, cust.GroupName);
            sqlRow.SetInt32(19, cust.CounterZone);
            sqlRow.SetInt32(20, cust.TypeID);
            sqlRow.SetInt32(21, cust.IsHidden);
            yield return sqlRow;
        }
    }
}
