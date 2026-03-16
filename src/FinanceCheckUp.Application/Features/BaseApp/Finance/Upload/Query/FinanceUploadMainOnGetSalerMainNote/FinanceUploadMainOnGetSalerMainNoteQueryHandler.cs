using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.Finance.Upload;
using FinanceCheckUp.Domain.Entities;
using FinanceCheckUp.Framework.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinanceCheckUp.Application.Features.BaseApp.Finance.Upload.Query.FinanceUploadMainOnGetSalerMainNote;
public class FinanceUploadMainOnGetSalerMainNoteQueryHandler(
    ITBLXmlFolderFileManager folderFileManager,
    IHhvnUsersManager hhvnUsersManager, 
    ICompanyManager companyManager) : IRequestHandler<FinanceUploadMainOnGetSalerMainNoteQuery, GenericResult<FinanceUploadMainOnGetSalerMainNoteResponse>>
{
    

    public Task<GenericResult<FinanceUploadMainOnGetSalerMainNoteResponse>> Handle(FinanceUploadMainOnGetSalerMainNoteQuery request, CancellationToken cancellationToken)
    {
         var userId = Convert.ToInt64(request.UserId);
         request.InitialModel.UserID = userId;
          
         request.InitialModel.CurrentUser = hhvnUsersManager.GetRow_User( request.InitialModel.UserID);
         request.InitialModel.curcomID = companyManager.Getby_User( request.InitialModel.UserID).Where(x => x.IsDefault == 1).FirstOrDefault().Id;

        List<TblxmlFolderFile> nlist = folderFileManager.GetList( request.InitialModel.curcomID);

        if (nlist.Count < 1)
        { 
            return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerMainNoteResponse>.Success(new FinanceUploadMainOnGetSalerMainNoteResponse
            {
                InitialModel = request.InitialModel,
                Response = new JsonResult("nok")
            }));
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
                List<ViewSortlist> nlistsort = folderFileManager.GetListSort(request.InitialModel.curcomID); listret = getresult(nlistsort);
                break;
        }
 
        return Task.FromResult(GenericResult<FinanceUploadMainOnGetSalerMainNoteResponse>.Success(new FinanceUploadMainOnGetSalerMainNoteResponse
        {
            InitialModel = request.InitialModel,
            Response = new JsonResult(listret)
        }));
    }
    
    private static string getresult(List<ViewSortlist> nlistsort) {
        string tt = " ";
        foreach (var item in nlistsort)
        {
            tt += item.MainYear.ToString() + " Yılı " + item.AllRecord.ToString() + " edefter " + item.AllSet.ToString() + " işlenen ";
        }
        return tt;
    }
}
