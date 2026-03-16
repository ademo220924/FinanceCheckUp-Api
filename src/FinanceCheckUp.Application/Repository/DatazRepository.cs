using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Domain.Common;
using FinanceCheckUp.Framework.Data.MsSql.Repositories;
using FinanceCheckUp.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace FinanceCheckUp.Application.Repository;

public class DatazRepository(FinanceCheckUpDbContext dbContext) : GenericBaseRepository<Dataz, int>(dbContext), IDatazRepository
{
    public int BulkInsert(BulkUploadToSqlOptions options, CancellationToken cancellationToken)
    {
        var updatedCount = 0;
        if (options.InternalStore.Count > 0)
        {
            DataTable dt;
            int numberOfPages = (options.InternalStore.Count / options.CommitBatchSize) + (options.InternalStore.Count % options.CommitBatchSize == 0 ? 0 : 1);
            for (int pageIndex = 0; pageIndex < numberOfPages; pageIndex++)
            {
                dt = options.InternalStore.Skip(pageIndex * options.CommitBatchSize).Take(options.CommitBatchSize).ToDataTable();
                BulkInsert(dt, options.TableName);
                updatedCount = updatedCount + dt.Rows.Count;
            }
            return updatedCount;
        }

        return updatedCount;
    }

    public void BulkInsert(DataTable dt, string tableName)
    {
        using (SqlConnection connection = new SqlConnection(dbContext.Database.GetConnectionString()))
        {
            // make sure to enable triggers
            // more on triggers in next post
            SqlBulkCopy bulkCopy =
                new SqlBulkCopy
                (
                connection,
                SqlBulkCopyOptions.TableLock |
                SqlBulkCopyOptions.FireTriggers |
                SqlBulkCopyOptions.UseInternalTransaction,
                null
                );
            bulkCopy.ColumnMappings.Add("StartDate", "StartDate");
            bulkCopy.ColumnMappings.Add("EndDate", "EndDate");
            bulkCopy.ColumnMappings.Add("EnteredBy", "EnteredBy");
            bulkCopy.ColumnMappings.Add("EnteredDate", "EnteredDate");
            bulkCopy.ColumnMappings.Add("EntryNumber", "EntryNumber");
            bulkCopy.ColumnMappings.Add("EntryComment", "EntryComment");
            bulkCopy.ColumnMappings.Add("BatchID", "BatchID");
            bulkCopy.ColumnMappings.Add("BatchDescription", "BatchDescription");
            bulkCopy.ColumnMappings.Add("TotalDebit", "TotalDebit");
            bulkCopy.ColumnMappings.Add("TotalCredit", "TotalCredit");
            bulkCopy.ColumnMappings.Add("DocumentType", "DocumentType");
            bulkCopy.ColumnMappings.Add("DocumentTypeDescription", "DocumentTypeDescription");
            bulkCopy.ColumnMappings.Add("DocumentNumber", "DocumentNumber");
            bulkCopy.ColumnMappings.Add("DocumentDate", "DocumentDate");
            bulkCopy.ColumnMappings.Add("PaymentMethod", "PaymentMethod");
            bulkCopy.ColumnMappings.Add("AccountMainID", "AccountMainID");
            bulkCopy.ColumnMappings.Add("AccountMainDescription", "AccountMainDescription");
            bulkCopy.ColumnMappings.Add("AccountSubDescription", "AccountSubDescription");
            bulkCopy.ColumnMappings.Add("AccountSubID", "AccountSubID");
            bulkCopy.ColumnMappings.Add("Amount", "Amount");
            bulkCopy.ColumnMappings.Add("DebitCreditCode", "DebitCreditCode");
            bulkCopy.ColumnMappings.Add("PostingDate", "PostingDate");
            bulkCopy.ColumnMappings.Add("DetailComment", "DetailComment");
            bulkCopy.ColumnMappings.Add("CsvID", "CsvID");
            bulkCopy.ColumnMappings.Add("IsPassedEntry", "IsPassedEntry");
            // set the destination table name
            bulkCopy.DestinationTableName = tableName;
            bulkCopy.BulkCopyTimeout = 100;
            connection.Open();

            // write the data in the "dataTable"
            bulkCopy.WriteToServer(dt);
            connection.Close();
        }
        // reset
        //this.dataTable.Clear();
    }

}