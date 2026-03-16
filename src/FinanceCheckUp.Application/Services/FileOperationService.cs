using DevExpress.Pdf;
using FinanceCheckUp.Application.Common.Constants;
using FinanceCheckUp.Application.Common.Utilities;
using FinanceCheckUp.Application.ExtensionHelpers;
using FinanceCheckUp.Application.Managers.SqlQueryManager;
using FinanceCheckUp.Application.Models;
using FinanceCheckUp.Application.Models.Responses.FileOperation;
using FinanceCheckUp.Application.Models.ViewModel;
using FinanceCheckUp.Application.Models.ViewModel.Mizan;
using FinanceCheckUp.Application.Services.Interfaces;
using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Framework.Core.Exceptions;
using FinanceCheckUp.Framework.Core.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace FinanceCheckUp.Application.Services;

public class FileOperationService(
    IMizanSqlOperationManager mizanSqlOperationManager,
    IDataManager dataManager) : IFileOperationService
{
    public async Task<GenericResult<FileOperationResponse>> UploadAsync(IFormFile imageFile, CancellationToken cancellationToken)
    {
        var extension = Path.GetExtension(imageFile.FileName);
        var fileType = FileExtensionHelper.GetFileType(extension);

        if (fileType is FileType.Audio or FileType.Video)
        {
            if (imageFile.GetFileBytes().Length > AppConst.RequestSizeLimit)
                throw new RequestSizeLimitException(AppConst.RequestSizeLimit.ToString());
        }

        var imageName = Guid.NewGuid() + Path.GetExtension(imageFile.Name);
        var savePath = Path.Combine($"{Directory.GetCurrentDirectory()}/UploadFiles/{fileType.ToString()}", imageName);

        await using var stream = new FileStream(savePath, FileMode.Create);
        await imageFile.CopyToAsync(stream, cancellationToken);

        try
        {
            var image = await System.IO.File.ReadAllBytesAsync(savePath, cancellationToken);
            return GenericResult<FileOperationResponse>.Success(new FileOperationResponse { File = image });
        }
        catch (Exception e)
        {
            return GenericResult<FileOperationResponse>.Fail($"{fileType.ToString()} upload sırasınd abir hata oluştu. Hata:" + e.Message);
        }
    }

    public async Task<GenericResult<FileOperationResponse>> DownloadAsync(string imageUrl, CancellationToken cancellationToken)
    {
        var file = new FileInfo(imageUrl);
        var extension = Path.GetExtension(file.Name);
        var fileType = FileExtensionHelper.GetFileType(extension);
        var path = Path.Combine($"{Directory.GetCurrentDirectory()}/UploadFiles/{fileType.ToString()}", file.Name);

        try
        {
            var image = await System.IO.File.ReadAllBytesAsync(path, cancellationToken);
            return GenericResult<FileOperationResponse>.Success(new FileOperationResponse { File = image });
        }
        catch (Exception e)
        {
            return GenericResult<FileOperationResponse>.Fail($"{fileType.ToString()} donwload sırasınd abir hata oluştu. Hata:" + e.Message);
        }
    }

    public async Task<GenericResult<List<ReadPdfPg>>> ReadPdfFileAsync(string fileName, CancellationToken cancellationToken)
    {

        List<ReadPdfPg> nlist = new List<ReadPdfPg>();
        ReadPdfPg chkPdf = new ReadPdfPg();
        PdfDocumentProcessor pdfDocumentProcessor = new PdfDocumentProcessor();
        pdfDocumentProcessor.LoadDocument(fileName);
        string[] words;
        string line;
        int countPg = pdfDocumentProcessor.Document.Pages.Count;
        string firstPageText = string.Empty;
        int countre = 0;
        for (int i = 1; i <= countPg; i++)
        {

            firstPageText = pdfDocumentProcessor.GetPageText(i, new PdfTextExtractionOptions { ClipToCropBox = false });

            words = firstPageText.Split('\n');
            for (int j = 0, len = words.Length; j < len; j++)
            {
                chkPdf = new ReadPdfPg();
                countre++;
                line = Encoding.UTF8.GetString(Encoding.UTF8.GetBytes(words[j]));
                chkPdf.LineContent = line.Replace("\r", string.Empty);
                chkPdf.CounterNo = countre;
                nlist.Add(chkPdf);
            }

        }

        return GenericResult<List<ReadPdfPg>>.Success(nlist);
    }

    public async Task<GenericResult<List<ReadPdfMizan>>> ReadPdfFileAsync(string fileName, long compid, int nyear, byte nmonth, CancellationToken cancellationToken)
    {


        List<ReadPdfMizan> nlist = new List<ReadPdfMizan>();
        ReadPdfMizan chkPdf = new ReadPdfMizan();
        PdfDocumentProcessor pdfDocumentProcessor = new PdfDocumentProcessor();
        pdfDocumentProcessor.LoadDocument(fileName);
        string[] words; string[] wordschk;
        string line;
        int chrCtountere = 0;
        int countPg = pdfDocumentProcessor.Document.Pages.Count;
        string firstPageText = string.Empty;
        int countre = 0;
        bool nvrnmnd = false;
        List<Checkpdf> nlisttttt = new();
        List<List<Checkpdf>> nlistttttM = new List<List<Checkpdf>>();
        Checkpdf cp = new Checkpdf();
        bool omklyop = false;
        using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
        {
            processor.LoadDocument(fileName);

            string ttxta = "";
            for (int i = 0; i < countPg; i++)
            {
                nlisttttt = new List<Checkpdf>();
                using (PdfDocumentProcessor target = new PdfDocumentProcessor())
                {
                    if (System.IO.File.Exists(@"ExtractedFirstPage.pdf"))
                    {
                        System.IO.File.Delete(@"ExtractedFirstPage.pdf");
                    }

                    target.CreateEmptyDocument("ExtractedFirstPage.pdf");
                    target.Document.Pages.Add(processor.Document.Pages[i]);

                    PdfWord currentWord = target.NextWord();
                    while (currentWord != null)
                    {
                        cp = new Checkpdf();


                        if (currentWord != null)
                        {
                            cp.txtWord = currentWord.Text.ToString();
                            cp.txtLeft = currentWord.Rectangles[0].Left;
                            cp.txtTop = currentWord.Rectangles[0].Top;
                            nlisttttt.Add(cp);
                        }
                        currentWord = target.NextWord();

                    }
                }
                nlistttttM.Add(nlisttttt);
            }
        }
        double chkVal = nlistttttM[0][0].txtTop;
        double dif1 = 0;
        double dif2 = 0;
        double dif3 = 0;
        double dif4 = 0;
        nlisttttt = new List<Checkpdf>();
        List<string> toDoList = new List<string>();
        List<string> toDoList1 = new List<string>();
        TBLXMLSCheckpdfMizan nMizan = new TBLXMLSCheckpdfMizan();

        float[] limitCoordinates = null;



        List<string> nteytey = new List<string>();
        string currentText1 = "";
        List<TBLXMLSCheckpdfMizancHK> zztlista = new List<TBLXMLSCheckpdfMizancHK>();
        List<TBLXMLSCheckpdfMizancHK> zztlistb = new List<TBLXMLSCheckpdfMizancHK>();
        for (int page = 1; page <= countPg; page++)
        {
            var lineText = LineUsingCoordinates.getLineText(fileName, page, limitCoordinates);

            if (lineText.Where(x => x.Contains("100")).Count() > 0)
            {
                var chkfdsegw = lineText;
            }

            foreach (var row in lineText)
            {
                if (row.Count > 1)
                {
                    for (var col = 0; col < row.Count; col++)
                    {
                        string trimmedValue = row[col].Trim();
                        if (trimmedValue != "")
                        {
                            currentText1 += "ß" + trimmedValue + "ß";
                        }
                    }
                    nteytey.Add(currentText1);
                    currentText1 = "";
                }
            }
            zztlista.AddRange(MizanHelper.getSplistedt(nteytey));
            zztlista.Select(c => { c.pageID = page; return c; }).ToList();
            zztlistb.AddRange(zztlista);
            nteytey = new List<string>();
            zztlista = new List<TBLXMLSCheckpdfMizancHK>();
        }



        List<TBLXMLSCheckpdfMizan> zonelastlist = new List<TBLXMLSCheckpdfMizan>();
        List<TBLXMLSCheckpdfMizan> zztlist = MizanHelper.getlimited(zztlistb);
        zztlist.Select(c => { c.CompanyID = compid; return c; }).ToList();
        zztlist.Select(c => { c.MainMonth = nmonth; return c; }).ToList();
        zztlist.Select(c => { c.Year = nyear; return c; }).ToList();
        mizanSqlOperationManager.DeleteByCompanyIDn(compid, nyear, nmonth);

        string amount1 = "";
        string amount2 = "";
        string amount3 = "";
        string amount4 = "";
        string mainide = "";
        string txtFinitto = "";
        string chkzone = "";
        for (int a = 0; a < nlistttttM.Count; a++)
        {
            var itemz = nlistttttM[a];
            var pagelist = zztlist.Where(x => x.PageID == a + 1).ToList();

            var groupedchksList = itemz
.GroupBy(u => u.txtTop)
.Select(grp => grp.ToList())
.ToList();

            for (int t = 1; t < groupedchksList.Count; t++)
            {

                nlisttttt = groupedchksList[t];
                for (int i = 0; i < nlisttttt.Count; i++)
                {
                    if (nlisttttt[i].txtTop == chkVal)
                    {
                        List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();
                        string chkmn = string.Join("-", wordstt);

                        txtFinitto += nlisttttt[i].txtWord;


                        if (pagelist.Where(x => x.AccountMainZet == txtFinitto.Trim()).Count() > 0)
                        {
                            mainide = txtFinitto.Trim();
                            txtFinitto = "";
                            var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                            amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                            amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                            amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                            amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");

                        }

                        if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                        {
                            chkzone = MizanHelper.RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                            if (amount1 == chkzone)
                            {
                                dif1 = nlisttttt[i].txtLeft;
                                txtFinitto = "";
                                pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                amount1 = "";
                            }
                            else if (amount1 == "" && amount2 == chkzone)
                            {
                                dif2 = nlisttttt[i].txtLeft;
                                txtFinitto = "";
                                pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                amount2 = "";
                            }
                            else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                            {
                                dif3 = nlisttttt[i].txtLeft;
                                txtFinitto = "";
                                pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                amount3 = "";
                            }
                            else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                            {
                                dif4 = nlisttttt[i].txtLeft;
                                txtFinitto = "";
                                pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                amount4 = "";
                            }
                        }


                    }
                    else
                    {
                        mainide = "";
                        txtFinitto = nlisttttt[i].txtWord;
                        chkVal = nlisttttt[i].txtTop;
                        amount1 = "";
                        amount2 = "";
                        amount3 = "";
                        amount4 = "";
                    }
                }



            }

            zonelastlist.AddRange(pagelist);
        }

        var chkyyyu = dataManager.SetBilancoFromListMizanExcelPdf(zonelastlist);
        dataManager.InsertDataMizanPdf(chkyyyu);

        List<TBLXMLSCheckpdfMizan> zonelastlistCheck = mizanSqlOperationManager.Get_TBLXMLSCheckpdfMizanLast(compid, nyear);
        zonelastlist = new List<TBLXMLSCheckpdfMizan>();
        for (int a = 0; a < nlistttttM.Count; a++)
        {
            var itemz = nlistttttM[a];
            //nlisttttt = itemz;
            //var chkslist = nlisttttt.GroupBy(x => x.txtTop);
            var pagelist = zonelastlistCheck.Where(x => x.PageID == a + 1).ToList();

            var groupedchksList = itemz
.GroupBy(u => u.txtTop)
.Select(grp => grp.ToList())
.ToList();
            if (pagelist.Count > 0)
            {
                for (int t = 1; t < groupedchksList.Count; t++)
                {

                    nlisttttt = groupedchksList[t];
                    List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();
                    string chkmn = string.Join("-", wordstt);
                    for (int i = 0; i < nlisttttt.Count; i++)
                    {
                        if (nlisttttt[i].txtTop == chkVal)
                        {

                            //dif1 = nlisttttt[i].txtLeft - nlisttttt[i - 1].txtLeft;

                            txtFinitto += nlisttttt[i].txtWord;

                            //if (txtFinitto.Contains("FAİZ"))
                            //{
                            //    var jhcjhc = mainide;
                            //}

                            var longestLenght = pagelist.Min(r => r.AccountMainZet.Length);

                            if (txtFinitto.Length > longestLenght)
                            {
                                foreach (var item in pagelist)
                                {

                                    if (StringExtension.CompareStrings(item.AccountMainZet, txtFinitto.Trim()) > 93)
                                    {
                                        if (txtFinitto.Length > item.AccountMainZet.Length)
                                        {
                                            string ntry = "";
                                            //double cfsa = RemoveNonNumeric2(nlisttttt[i + 1].txtWord);
                                            //if (RemoveNonNumeric2(nlisttttt[i+1].txtWord)==0)
                                            //{
                                            //    ntry = nlisttttt[i + 1].txtWord;
                                            //}
                                            List<int> nchutn = new List<int>();
                                            //List<Checkpdf> nlistsaa =new List<Checkpdf>();
                                            for (int y = i + 1; y < nlisttttt.Count; y++)
                                            {
                                                //nlistsaa.Add(nlisttttt[y]);
                                                if (item.AccountMainDescription.Replace(" ", "").Contains(nlisttttt[y].txtWord))
                                                {
                                                    nchutn.Add(y);
                                                    ntry += nlisttttt[y].txtWord;
                                                }
                                            }


                                            //var nlistsaa= nlisttttt.Where()

                                            //for (int u = 0; u < nlistsaa.Count(); u++)
                                            //{

                                            //}


                                            string sttr = StringExtension.RemoveStringDiff(txtFinitto.Trim() + ntry, item.AccountMainZet);

                                            mainide = item.AccountMainZet;

                                            var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                            amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                            amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                            amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                            amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");
                                            txtFinitto = sttr;
                                        }

                                    }

                                }
                            }


                            if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                            {
                                chkzone = MizanHelper.RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                                if (amount1 == chkzone)
                                {
                                    dif1 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                    amount1 = "";
                                }
                                else if (amount1 == "" && amount2 == chkzone)
                                {
                                    dif2 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                    amount2 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                                {
                                    dif3 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                    amount3 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                                {
                                    dif4 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                    amount4 = "";
                                }
                            }


                        }
                        else
                        {


                            mainide = "";
                            txtFinitto = nlisttttt[i].txtWord;
                            chkVal = nlisttttt[i].txtTop;
                            amount1 = "";
                            amount2 = "";
                            amount3 = "";
                            amount4 = "";
                        }
                    }



                }

                zonelastlist.AddRange(pagelist);
            }

        }
        var chk = zonelastlist;
        foreach (var item in zonelastlist)
        {
            mizanSqlOperationManager.Update_TBLXMLSCheckpdfMizan(item);
            Thread.Sleep(100);
        }



        zonelastlistCheck = mizanSqlOperationManager.Get_TBLXMLSCheckpdfMizanLast(compid, nyear);
        zonelastlist = new List<TBLXMLSCheckpdfMizan>();
        for (int a = 0; a < nlistttttM.Count; a++)
        {
            var itemz = nlistttttM[a];
            var pagelist = zonelastlistCheck.Where(x => x.PageID == a + 1).ToList();

            var groupedchksList = itemz
.GroupBy(u => u.txtTop)
.Select(grp => grp.ToList())
.ToList();
            if (pagelist.Count > 0)
            {
                for (int t = 1; t < groupedchksList.Count; t++)
                {

                    nlisttttt = groupedchksList[t];
                    List<string> wordstt = nlisttttt.Select(x => x.txtWord).ToList();


                    string chkmn = string.Join("-", wordstt);
                    //if (chkmn.Contains("PETROL")) {
                    //    string kmkm = "";
                    //}
                    for (int i = 0; i < nlisttttt.Count; i++)
                    {
                        if (nlisttttt[i].txtTop == chkVal)
                        {



                            txtFinitto += nlisttttt[i].txtWord;


                            var longestLenght = pagelist.Min(r => r.AccountMainZet.Length);

                            if (txtFinitto.Length > longestLenght)
                            {
                                foreach (var item in pagelist)
                                {

                                    if (StringExtension.CompareStrings(item.AccountMainZet, txtFinitto.Trim()) > 80)
                                    {
                                        if (txtFinitto.Length > item.AccountMainZet.Length)
                                        {
                                            string ntry = "";

                                            List<int> nchutn = new List<int>();
                                            for (int y = i + 1; y < nlisttttt.Count; y++)
                                            {
                                                //nlistsaa.Add(nlisttttt[y]);
                                                if (item.AccountMainDescription.Replace(" ", "").Contains(nlisttttt[y].txtWord))
                                                {
                                                    nchutn.Add(y);
                                                    ntry += nlisttttt[y].txtWord;
                                                }
                                            }
                                            int zetnt = i;
                                            if (nchutn.Count > 0)
                                            {
                                                zetnt = nchutn.Max();
                                            }

                                            string chku = "";
                                            string chkuchk = "";
                                            string fullapp = "";
                                            for (int r = 0; r <= zetnt; r++)
                                            {
                                                chku = nlisttttt[r].txtWord;
                                                if (item.AccountMainZet.Contains(chkuchk + chku))
                                                {
                                                    chkuchk += chku;
                                                }
                                                else
                                                {
                                                    fullapp += chku;
                                                }

                                            }
                                            i = zetnt;

                                            //string sttr = RemoveStringDiff(txtFinitto.Trim() + ntry, item.AccountMainZet);

                                            mainide = item.AccountMainZet;

                                            var resultItem = pagelist.Where(x => x.AccountMainZet == mainide).FirstOrDefault();
                                            amount1 = resultItem.Amount1.ToString().Replace(",", "").Replace(".", "");
                                            amount2 = resultItem.Amount2.ToString().Replace(",", "").Replace(".", "");
                                            amount3 = resultItem.Amount3.ToString().Replace(",", "").Replace(".", "");
                                            amount4 = resultItem.Amount4.ToString().Replace(",", "").Replace(".", "");
                                            txtFinitto = fullapp;
                                        }

                                    }

                                }
                            }




                            if (txtFinitto != "" && (amount1 != "" || amount2 != "" || amount3 != "" || amount4 != ""))
                            {
                                chkzone = MizanHelper.RemoveNonNumeric2(txtFinitto).ToString().Replace(",", "").Replace(".", "");

                                if (amount1 == chkzone)
                                {
                                    dif1 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount1Diff = Convert.ToInt32(dif1); return c; }).ToList();

                                    amount1 = "";
                                }
                                else if (amount1 == "" && amount2 == chkzone)
                                {
                                    dif2 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount2Diff = Convert.ToInt32(dif2); return c; }).ToList();
                                    amount2 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == chkzone)
                                {
                                    dif3 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount3Diff = Convert.ToInt32(dif3); return c; }).ToList();
                                    amount3 = "";
                                }
                                else if (amount1 == "" && amount2 == "" && amount3 == "" && amount4 == chkzone)
                                {
                                    dif4 = nlisttttt[i].txtLeft;
                                    txtFinitto = "";
                                    pagelist.Where(x => x.AccountMainZet == mainide).Select(c => { c.Amount4Diff = Convert.ToInt32(dif4); return c; }).ToList();
                                    amount4 = "";
                                }
                            }


                        }
                        else
                        {


                            mainide = "";
                            txtFinitto = nlisttttt[i].txtWord;
                            chkVal = nlisttttt[i].txtTop;
                            amount1 = "";
                            amount2 = "";
                            amount3 = "";
                            amount4 = "";
                        }
                    }



                }

                zonelastlist.AddRange(pagelist);
            }

        }
        var chkvn = zonelastlist;
        foreach (var item in zonelastlist)
        {
            mizanSqlOperationManager.Update_TBLXMLSCheckpdfMizan(item);
            Thread.Sleep(100);
        }
        mizanSqlOperationManager.LastRepByCompanyIDn(nyear, compid, nmonth, 1);
        return GenericResult<List<ReadPdfMizan>>.Success([]);
    }

}