using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetresult;
public class FinanceUploadMainOnGetresultQueryHandler : IRequestHandler<FinanceUploadMainOnGetresultQuery, GenericResult<FinanceUploadMainOnGetresultResponse>>
{
    public Task<GenericResult<FinanceUploadMainOnGetresultResponse>> Handle(FinanceUploadMainOnGetresultQuery request, CancellationToken cancellationToken)
    {
        var tt = " ";
        foreach (var item in request.Request.nlistsort)
        {
            tt += item.MainYear.ToString() + " Yılı " + item.AllRecord.ToString() + " edefter " + item.AllSet.ToString() + " işlenen ";
        }
        return Task.FromResult(GenericResult<FinanceUploadMainOnGetresultResponse>.Success(new FinanceUploadMainOnGetresultResponse
        {
            Response =tt
        }));
    }
}
