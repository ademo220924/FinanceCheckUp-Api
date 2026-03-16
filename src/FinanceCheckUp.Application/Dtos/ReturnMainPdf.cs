namespace FinanceCheckUp.Application.Dtos;

public class ReturnMainPdf
{
    public bool success { get; set; }
    public string message { get; set; }
    public object payload { get; set; }
}