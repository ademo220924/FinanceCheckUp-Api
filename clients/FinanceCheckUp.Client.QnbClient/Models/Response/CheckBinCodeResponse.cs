namespace FinanceCheckUp.Client.QnbClient.Models.Response;

public class CheckBinCodeResponse : ClientResponseModel
{
    public string is_3d { get; set; }
    public GetPosResponse PosResponse { get; set; }
}