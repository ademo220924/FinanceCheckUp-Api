using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Common;
using FinanceCheckUp.Application.Models.Requests.Upload;
using FinanceCheckUp.Application.Models.Responses.Upload;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FinanceCheckUp.Application.Features.BaseApp.Upload.Query.UploadOnGetSalerMainNote;
public class UploadOnGetSalerMainNoteQueryHandler(ITBLXmlFolderFileManager tBLXmlFolderFileManager, IHhvnUsersManager hhvnUsersManager, ICompanyManager companyManager) : IRequestHandler<UploadOnGetSalerMainNoteQuery, GenericResult<UploadOnGetSalerMainNoteResponse>>
{

    public async Task<GenericResult<UploadOnGetSalerMainNoteResponse>> Handle(UploadOnGetSalerMainNoteQuery request, CancellationToken cancellationToken)
    {
        var UserID = Convert.ToInt32(request.UserId);
        var responseModel = new UploadRequest
        {
            mrequestDataViewer = new DataViewerMain(),
            UserID = UserID,
            CurrentUser = hhvnUsersManager.GetRow_User(UserID),
            curcomID = companyManager.Getby_User(UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id
        };

        List<TblxmlFolderFile> nlist = tBLXmlFolderFileManager.GetList(responseModel.curcomID);

        if (nlist.Count < 1)
        {
            return GenericResult<UploadOnGetSalerMainNoteResponse>.Success(new UploadOnGetSalerMainNoteResponse { InitialModel = responseModel, Result = new JsonResult("nok") });
        }


        string listret = "";
        switch (nlist.Count)
        {
            case -1: listret = "Entegratörden Verilerin İletilmesi Bekleniyor"; break;
            case 0: listret = "Entegratörden Verilerin İletilmesi Bekleniyor"; break;
            case 1: listret = nlist[0].MainYear.ToString() + " Yılı " + nlist[0].MainMonth.ToString() + ". Ayı Entegratörden İndirildi İşleniyor"; break;
            case 2: listret = nlist[1].MainYear.ToString() + " Yılı " + nlist[1].MainMonth.ToString() + ". Ayı Entegratörden İndirildi İşleniyor"; break;
            case 3: listret = nlist[2].MainYear.ToString() + " Yılı " + nlist[2].MainMonth.ToString() + ". Ayı Entegratörden İndirildi İşleniyor"; break;
            case 4: listret = nlist[3].MainYear.ToString() + " Yılı " + nlist[3].MainMonth.ToString() + ". Ayı Entegratörden İndirildi İşleniyor"; break;
            case 5: listret = nlist[4].MainYear.ToString() + " Yılı " + nlist[4].MainMonth.ToString() + ". Ayı Entegratörden İndirildi İşleniyor"; break;
            default:
                List<ViewSortlist> nlistsort = tBLXmlFolderFileManager.GetListSort(responseModel.curcomID); listret = getresult(nlistsort);
                break;
        }
        return GenericResult<UploadOnGetSalerMainNoteResponse>.Success(new UploadOnGetSalerMainNoteResponse { InitialModel = responseModel, Result = new JsonResult(listret) });


    }

    public string getresult(List<ViewSortlist> nlistsort)
    {
        string tt = " ";
        foreach (var item in nlistsort)
        {
            tt += item.MainYear.ToString() + " Yılı " + item.AllRecord.ToString() + " edefter " + item.AllSet.ToString() + " işlenen ";
        }
        return tt;
    }
}