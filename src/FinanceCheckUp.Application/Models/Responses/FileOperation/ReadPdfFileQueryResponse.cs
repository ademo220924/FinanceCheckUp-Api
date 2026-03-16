using FinanceCheckUp.Application.Models.ViewModel;


namespace FinanceCheckUp.Application.Models.Responses.FileOperation;
public class ReadPdfFileQueryResponse
{
    public List<ReadPdfPg> ReadPdfPgs { get; set; }
}