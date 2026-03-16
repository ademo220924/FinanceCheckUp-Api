
namespace FinanceCheckUp.Client.Wsdl;

public interface IFinansmanClient
{
    public Task<string> UserValidationByQnbUserIdAsync(string userName, string password, string qnbuserId, string vlkntckn, CancellationToken cancellationToken = default);
    public Task<string> UserValidationByUserIdPasswordAsync(string userName, string password, string kulanickodu, string pass, string vlkntckn, CancellationToken cancellationToken = default);
    public Task<string> DefterIzinSilAsync(string userName, string password, string vlkntckn, CancellationToken cancellationToken = default);
    public Task<string> IzinKaydetAsync(string userName, string password, string vlkntckn, string hedefkaynak, CancellationToken cancellationToken = default);
}