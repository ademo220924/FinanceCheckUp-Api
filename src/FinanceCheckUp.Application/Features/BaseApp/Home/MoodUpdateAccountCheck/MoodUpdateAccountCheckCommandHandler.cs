using FinanceCheckUp.Application.Models.Responses.Home;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Home.MoodUpdateAccountCheck;

public class MoodUpdateAccountCheckCommandHandler: IRequestHandler<MoodUpdateAccountCheckCommand, GenericResult<MoodUpdateAccountCheckResponse>>
{
    public Task<GenericResult<MoodUpdateAccountCheckResponse>> Handle(MoodUpdateAccountCheckCommand request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {

            return Json("nok");
        }

        try
        {
            // ReportSetMain.Set_ReportSet(pageIndex.year, pageIndex.companyid);
            int csvId = MainDash.GetTblxml(pageIndex.year, pageIndex.companyid, pageIndex.month);

            String dbConnStr = BaseModel.ConnectionString;
            SqlConnection cnn = new SqlConnection(dbConnStr);

            try
            {


                //  MainStrPro1zA

                SqlCommand sqlCmd1 = new SqlCommand("setFirst", cnn);
                sqlCmd1.CommandType = CommandType.StoredProcedure;
                sqlCmd1.Parameters.AddWithValue("@csvvID", csvId);
                sqlCmd1.CommandTimeout = 0;
                //sqlCmd1.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
                cnn.Open();
                object obb = sqlCmd1.ExecuteScalar();
                DashOzetMali.SetErrored(pageIndex.year, pageIndex.companyid, pageIndex.month);
                MainDash.Get_DatabyErrorV1(pageIndex.year, pageIndex.companyid, pageIndex.month);
            }
            catch (Exception ex)
            {

                var chk = ex;
            }
            finally
            {
                cnn.Close();
            }


        }
        catch (Exception ex)
        {

            return Json("nok_" + ex.ToString());
        }



        return Json("ok");

    }
}
