using DevExtreme.AspNet.Mvc;


namespace FinanceCheckUp.Application.Models.Requests.ChangePassword;
public class ChangePasswordOnGetSalerCompanyRequest
{
    public DataSourceLoadOptions DataSourceLoadOptions { get; set; }
    public ChangePasswordRequest InitialModel { get; set; }
}