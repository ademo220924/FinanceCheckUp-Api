using FinanceCheckUp.Client.QnbClient.Models.Request;

namespace FinanceCheckUp.Client.QnbClient.Models.Response;

public class GetPosResponse : ClientResponseModel
{
    public List<PosData> Data { get; init; } = [];
}

