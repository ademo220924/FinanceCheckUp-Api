using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel;
using System.Data;

namespace FinanceCheckUp.Framework.Data.MsSql.Repositories;

public class GenericDapperRepositoryBase : IGenericDapperRepository
{
    public event PropertyChangedEventHandler PropertyChanged;

    private readonly string _connectionString;
    private IDbConnection Connection;
    private IDbTransaction _transaction;
    public const int CommitBatchSize = 1000;

    public GenericDapperRepositoryBase(DbContext dbContext)
    {
        SqlMapper.Settings.CommandTimeout = 0;
        _connectionString = dbContext.Database.GetConnectionString();
        Connection = new SqlConnection(_connectionString);
    }


    #region Connection ve Transaction vb. Operation tanımlamaları


    private IDbTransaction BeginTransaction() => Connection.BeginTransaction();
    private IDbConnection Get_connection() => Connection;
    private IDbTransaction BeginTransaction(IsolationLevel isolationLevel, IDbConnection _connection)
    {
        return _connection.BeginTransaction(isolationLevel);
    }

    private void CloseConnection() => Connection?.Close();
    private IDbTransaction Transaction
    {
        get => _transaction;
        set
        {
            _transaction = value;
            if (_transaction != null)
                Connection = _transaction.Connection;
        }
    }

    private void OpenConnection()
    {
        if (Connection != null && Connection.State != ConnectionState.Open)
            Connection.Open();
    }




    public virtual void Dispose()
    {
        Connection?.Dispose();
        Connection = null;
    }

    #endregion

    #region Operasyonel Metotlar

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void AllPropertyUpdate<T>(T source)
    {
        var plist = this.GetType().GetProperties();

        foreach (var p in plist)
        {
            if (p == null || !p.CanWrite)
                continue;
            var st = source.GetType().GetProperty(p.Name).GetValue(source, null);
            p.SetValue(this, st, null);
        }
    }

    public int Execute(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = 0, CommandType? commandType = null)
    {
        transaction ??= _transaction;

        OpenConnection();
        try
        {
            return SqlMapper.Execute(Connection, sql, param, transaction, 0, commandType);
        }
        finally
        {
            CloseConnection();
        }
    }

    public IEnumerable<T> Query<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {
        transaction ??= _transaction;

        OpenConnection();
        try
        {
            return SqlMapper.Query<T>(Connection, sql, param, transaction, buffered, 0, commandType);
        }
        finally
        {
            if (buffered)
                CloseConnection();
        }
    }

    public IEnumerable<T> StaticQuery<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {
        var con = Connection;
        try
        {
            if (con != null && con.State != ConnectionState.Open)
                con = new SqlConnection(_connectionString);

            return SqlMapper.Query<T>(con, sql, param, transaction, buffered, 0, commandType);
        }
        finally
        {
            if (buffered)
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }

    public IEnumerable<TReturn> StaticQuery<TFirst, TSecond, TReturn>(string sql, Func<TFirst, TSecond, TReturn> map,
        object? param = null, IDbTransaction? transaction = null, bool buffered = true, string splitOn = "TransactionId",
        int? commandTimeout = default, CommandType? commandType = default)
    {
        using var con = Connection;
        try
        {
            if (con != null && con.State != ConnectionState.Open)
                con.Open();

            return SqlMapper.Query<TFirst, TSecond, TReturn>(con, sql, map, param, transaction, buffered, splitOn,
                0, commandType);
        }
        finally
        {
            if (buffered)
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }

    public IEnumerable<dynamic> StaticQuery(string sql, object? param = null, IDbTransaction? transaction = null,
        bool buffered = true, int? commandTimeout = 0, CommandType? commandType = null)
    {
        using var con = Connection;
        try
        {
            if (con != null && con.State != ConnectionState.Open)
                con.Open();

            return SqlMapper.Query(con, sql, param, transaction, buffered, 0, commandType);
        }
        finally
        {
            if (buffered)
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }
        }
    }

    public int StaticExecute(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = 0, CommandType? commandType = null)
    {
        using var con = Connection;
        try
        {
            if (con != null && con.State != ConnectionState.Open)
                con.Open();

            return SqlMapper.Execute(con, sql, param, transaction, 0, commandType);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public SqlMapper.GridReader Multiple(CommandDefinition command)
    {
        using var con = Connection;
        try
        {
            if (con != null && con.State != ConnectionState.Open)
                con.Open();

            return con.QueryMultiple(command);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
    }

    public SqlMapper.GridReader Multiple(string sql, object? param = null, IDbTransaction? transaction = null,
        int? commandTimeout = 0, CommandType? commandType = null)
    {
        SqlMapper.GridReader? result = null;
        using var con = Connection;
        if (con != null && con.State != ConnectionState.Open)
            con.Open();

        result = con.QueryMultiple(sql, param, transaction, 0, commandType);
        return result;
    }

    public DataTable ConvertToDataTable(IEnumerable<dynamic> items)
    {
        var t = new DataTable();
        IDictionary<string, object> first = items.FirstOrDefault() as IDictionary<string, object>;

        if (first != null)
            foreach (var k in first.Keys)
            {
                var c = t.Columns.Add(k);
                var val = first[k];
                if (val != null) c.DataType = val.GetType();
            }

        foreach (var item in items)
        {
            var r = t.NewRow();
            var i = (IDictionary<string, object>)item;
            foreach (var k in i.Keys)
            {
                var val = i[k] ?? DBNull.Value;
                r[k] = val;
            }

            t.Rows.Add(r);
        }

        return t;
    }

    #endregion

    public DataTable ToDataTable<T>(IEnumerable<T> data)
    {
        var properties = TypeDescriptor.GetProperties(typeof(T));
        var table = new DataTable();

        foreach (PropertyDescriptor prop in properties)
            table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

        foreach (T item in data)
        {
            var row = table.NewRow();
            foreach (PropertyDescriptor prop in properties)
                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            table.Rows.Add(row);
        }

        return table;
    }

    private static void AutoMapColumns(SqlBulkCopy sbc, DataTable dt)
    {
        foreach (DataColumn column in dt.Columns)
        {
            sbc.ColumnMappings.Add(column.ColumnName, column.ColumnName);
        }
    }
}