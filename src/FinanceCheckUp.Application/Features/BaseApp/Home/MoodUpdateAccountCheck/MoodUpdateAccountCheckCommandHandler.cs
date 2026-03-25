using System.Data;
using FinanceCheckUp.Application.Contexts.Concretes.Databases;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateAccountCheck;

public class MoodUpdateAccountCheckCommandHandler(
    FinanceCheckUpDbContext dbContext,
    IMainDashManager mainDashManager,
    IDashOzetMaliManager dashOzetMaliManager)
    : IRequestHandler<MoodUpdateAccountCheckCommand, GenericResult<MoodUpdateAccountCheckResponse>>
{
    public Task<GenericResult<MoodUpdateAccountCheckResponse>> Handle(MoodUpdateAccountCheckCommand request, CancellationToken cancellationToken)
    {
        var pageIndex = request.MoodUpdateAccountCheckRequest.PageIndex;
        try
        {
            int csvId = mainDashManager.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            string? dbConnStr = dbContext.Database.GetConnectionString();
            using SqlConnection cnn = new SqlConnection(dbConnStr);
            try
            {
                SqlCommand sqlCmd1 = new SqlCommand("setFirst", cnn);
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@csvvID", csvId);
                sqlCmd1.CommandTimeout = 0;
                cnn.Open();
                sqlCmd1.ExecuteScalar();
                dashOzetMaliManager.SetErrored(pageIndex.year, pageIndex.companyid, pageIndex.month);
                mainDashManager.Get_DatabyErrorV1(pageIndex.year, pageIndex.companyid, pageIndex.month);
            }
            catch (Exception)
            {
                // preserved: inner errors were swallowed in original handler
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }
            }
        }
        catch (Exception ex)
        {
            return Task.FromResult(GenericResult<MoodUpdateAccountCheckResponse>.Success(
                new MoodUpdateAccountCheckResponse { ResultText = new JsonResult("nok_" + ex.ToString()) }));
        }

        return Task.FromResult(GenericResult<MoodUpdateAccountCheckResponse>.Success(
            new MoodUpdateAccountCheckResponse { ResultText = new JsonResult("ok") }));
    }
}
