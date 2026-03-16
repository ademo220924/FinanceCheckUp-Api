using Dapper;
using System.ComponentModel;
using System.Data;

namespace FinanceCheckUp.Framework.Data;
public interface IGenericDapperRepository : IDisposable, INotifyPropertyChanged
{
    event PropertyChangedEventHandler PropertyChanged;
    int Execute(string sql, dynamic? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    IEnumerable<T> Query<T>(string sql, dynamic? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
    IEnumerable<T> StaticQuery<T>(string sql, dynamic? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
    IEnumerable<TReturn> StaticQuery<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map, object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "Id", int? commandTimeout = default, CommandType? commandType = default);
    IEnumerable<dynamic> StaticQuery(string sql, dynamic? param = null, IDbTransaction? transaction = null, bool buffered = true, int? commandTimeout = null, CommandType? commandType = null);
    int StaticExecute(string sql, dynamic? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    SqlMapper.GridReader Multiple(CommandDefinition command);
    SqlMapper.GridReader Multiple(string sql, object? param = null, IDbTransaction? transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    DataTable ConvertToDataTable(IEnumerable<dynamic> items);
    DataTable ToDataTable<T>(IEnumerable<T> data);
}
