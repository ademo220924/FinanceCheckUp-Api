using FinanceCheckUp.Client.Wsdl.Helpers;
using System.Text;
using System.Xml;

namespace FinanceCheckUp.Client.Wsdl;

public class FinansmanClient(HttpClient httpClient) : IFinansmanClient
{
    private readonly HttpClient _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    private string SoapResult = string.Empty;

    public async Task<string> UserValidationByQnbUserIdAsync(string userName, string password, string qnbuserId, string vlkntckn, CancellationToken cancellationToken = default)
    {
        try
        {
            string soapRequest = CreateXmlUserValidationByQnbUserIdRequest(userName, password, qnbuserId, vlkntckn);
            string soapResponse = await SendSoapRequestAsync(soapRequest, AppConsts.UserValidationByQnbUserIdRequestActionPath);
            Console.WriteLine("SOAP UserValidationByQnbUserIdAsync Response:" + soapResponse);
            return soapResponse;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> UserValidationByUserIdPasswordAsync(string userName, string password, string kulanickodu, string pass, string vlkntckn, CancellationToken cancellationToken = default)
    {
        try
        {
            string soapRequest = CreateXmlUserValidationByUserIdPasswordRequest(userName, password, kulanickodu, pass, vlkntckn);
            string soapResponse = await SendSoapRequestAsync(soapRequest, AppConsts.UserValidationByUserIdPasswordActionPath);
            Console.WriteLine("SOAP UserValidationByUserIdPasswordAsync Response:" + soapResponse);

            return soapResponse;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> DefterIzinSilAsync(string userName, string password, string vlkntckn, CancellationToken cancellationToken = default)
    {
        try
        {
            string soapRequest = CreatexmldefterIzinSilRequest(userName, password, vlkntckn);
            string soapResponse = await SendSoapRequestAsync(soapRequest, AppConsts.DefterIzinSilActionPath);
            Console.WriteLine("SOAP DefterIzinSilAsync Response:" + soapResponse);

            return soapResponse;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<string> IzinKaydetAsync(string userName, string password, string vlkntckn, string hedefkaynak, CancellationToken cancellationToken = default)
    {
        try
        {
            string soapRequest = CreatexmlIzinKaydetRequest(userName, password, vlkntckn, hedefkaynak);
            string soapResponse = await SendSoapRequestAsync(soapRequest, AppConsts.IzinKaydetActionPath);
            Console.WriteLine("SOAP IzinKaydetAsync Response:" + soapResponse);

            return soapResponse;
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }




    public string CreateXmlUserValidationByQnbUserIdRequest(string userName, string pass, string qnbuserId, string vlkntckn)
    {
        XmlDocument doc = new XmlDocument();

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        nsmgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        nsmgr.AddNamespace("ser", "http://services.teminat.finansman.uut.cs.com.tr/");

        XmlElement envelope = doc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
        doc.AppendChild(envelope);

        XmlElement header = doc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(header);

        XmlElement security = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.SetAttribute("soap:mustUnderstand", "1");
        header.AppendChild(security);

        XmlElement usernameToken = doc.CreateElement("wsse", "UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.AppendChild(usernameToken);

        XmlElement username = doc.CreateElement("wsse", "Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        username.InnerText = userName;
        usernameToken.AppendChild(username);

        XmlElement password = doc.CreateElement("wsse", "Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        password.InnerText = pass;
        usernameToken.AppendChild(password);

        XmlElement body = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(body);

        XmlElement userValidationByQnbUserId = doc.CreateElement("ser", "userValidationByQnbUserId", "http://services.teminat.finansman.uut.cs.com.tr/");
        body.AppendChild(userValidationByQnbUserId);

        XmlElement vknTcknElem = doc.CreateElement("vknTckn");
        vknTcknElem.InnerText = vlkntckn;
        userValidationByQnbUserId.AppendChild(vknTcknElem);

        XmlElement qnbUserIdElem = doc.CreateElement("qnbUserId");
        qnbUserIdElem.InnerText = qnbuserId;
        userValidationByQnbUserId.AppendChild(qnbUserIdElem);

        return doc.OuterXml;
    }

    private string CreateXmlUserValidationByUserIdPasswordRequest(string userName, string pass, string kulaniciKodu, string sifre, string vknTckn)
    {
        XmlDocument doc = new XmlDocument();

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        nsmgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        nsmgr.AddNamespace("ser", "http://services.teminat.finansman.uut.cs.com.tr/");

        XmlElement envelope = doc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
        doc.AppendChild(envelope);

        XmlElement header = doc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(header);

        XmlElement security = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.SetAttribute("soap:mustUnderstand", "1");
        header.AppendChild(security);

        XmlElement usernameToken = doc.CreateElement("wsse", "UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.AppendChild(usernameToken);

        XmlElement username = doc.CreateElement("wsse", "Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        username.InnerText = userName;
        usernameToken.AppendChild(username);

        XmlElement password = doc.CreateElement("wsse", "Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        password.InnerText = pass;
        usernameToken.AppendChild(password);

        XmlElement body = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(body);

        // userValidationByUserIdPassword elementi oluþturuluyor
        XmlElement userValidationByUserIdPassword = doc.CreateElement("ser", "userValidationByUserIdPassword", "http://services.teminat.finansman.uut.cs.com.tr/");
        body.AppendChild(userValidationByUserIdPassword);

        // vknTckn elementi oluþturuluyor
        XmlElement vknTcknElem = doc.CreateElement("vknTckn");
        vknTcknElem.InnerText = vknTckn;
        userValidationByUserIdPassword.AppendChild(vknTcknElem);

        // kulaniciKodu elementi oluþturuluyor
        XmlElement kulaniciKoduElem = doc.CreateElement("kulaniciKodu");
        kulaniciKoduElem.InnerText = kulaniciKodu;
        userValidationByUserIdPassword.AppendChild(kulaniciKoduElem);

        // sifre elementi oluþturuluyor
        XmlElement sifreElem = doc.CreateElement("sifre");
        sifreElem.InnerText = sifre;
        userValidationByUserIdPassword.AppendChild(sifreElem);

        return doc.OuterXml;
    }

    public static string CreatexmldefterIzinSilRequest(string userName, string pass, string vlkntckn)
    {

        XmlDocument doc = new XmlDocument();

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        nsmgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        nsmgr.AddNamespace("ser", "http://services.teminat.finansman.uut.cs.com.tr/");

        XmlElement envelope = doc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
        doc.AppendChild(envelope);

        XmlElement header = doc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(header);

        XmlElement security = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.SetAttribute("soap:mustUnderstand", "1");
        header.AppendChild(security);

        XmlElement usernameToken = doc.CreateElement("wsse", "UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.AppendChild(usernameToken);

        XmlElement username = doc.CreateElement("wsse", "Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        username.InnerText = userName;
        usernameToken.AppendChild(username);

        XmlElement password = doc.CreateElement("wsse", "Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        password.InnerText = pass;
        usernameToken.AppendChild(password);

        XmlElement body = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(body);

        // defterIzinSil elementi oluþturuluyor
        XmlElement defterIzinSil = doc.CreateElement("ser", "defterIzinSil", "http://services.teminat.finansman.uut.cs.com.tr/");
        body.AppendChild(defterIzinSil);

        // vknTckn elementi oluþturuluyor
        XmlElement vknTcknElem = doc.CreateElement("vknTckn");
        vknTcknElem.InnerText = vlkntckn;
        defterIzinSil.AppendChild(vknTcknElem);

        return doc.OuterXml;
    }

    public static string CreatexmlIzinKaydetRequest(string userName, string pass, string vlkntckn, string hedefkaynak)
    {
        XmlDocument doc = new XmlDocument();

        XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
        nsmgr.AddNamespace("soapenv", "http://schemas.xmlsoap.org/soap/envelope/");
        nsmgr.AddNamespace("wsse", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        nsmgr.AddNamespace("ser", "http://services.teminat.finansman.uut.cs.com.tr/");

        XmlElement envelope = doc.CreateElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
        doc.AppendChild(envelope);

        XmlElement header = doc.CreateElement("soapenv", "Header", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(header);

        XmlElement security = doc.CreateElement("wsse", "Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.SetAttribute("soap:mustUnderstand", "1");
        header.AppendChild(security);

        XmlElement usernameToken = doc.CreateElement("wsse", "UsernameToken", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        security.AppendChild(usernameToken);

        XmlElement username = doc.CreateElement("wsse", "Username", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        username.InnerText = userName;
        usernameToken.AppendChild(username);

        XmlElement password = doc.CreateElement("wsse", "Password", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        password.InnerText = pass;
        usernameToken.AppendChild(password);

        XmlElement body = doc.CreateElement("soapenv", "Body", "http://schemas.xmlsoap.org/soap/envelope/");
        envelope.AppendChild(body);

        // defterIzinKaydet elementi oluþturuluyor
        XmlElement defterIzinKaydet = doc.CreateElement("ser", "defterIzinKaydet", "http://services.teminat.finansman.uut.cs.com.tr/");
        body.AppendChild(defterIzinKaydet);

        // vknTckn elementi oluþturuluyor
        XmlElement vknTcknElem = doc.CreateElement("vknTckn");
        vknTcknElem.InnerText = vlkntckn;
        defterIzinKaydet.AppendChild(vknTcknElem);

        // hedefKaynak elementi oluþturuluyor
        XmlElement hedefKaynakElem = doc.CreateElement("hedefKaynak");
        hedefKaynakElem.InnerText = hedefkaynak;
        defterIzinKaydet.AppendChild(hedefKaynakElem);

        return doc.OuterXml;
    }






    private async Task<string> SendSoapRequestAsync(string soapRequest, string action)
    {
        var requestContent = new StringContent(soapRequest, Encoding.UTF8, "text/xml");

        httpClient.DefaultRequestHeaders.Add("SOAPAction", action);
        HttpResponseMessage response = await _httpClient.PostAsync(AppConsts.BasePath, requestContent);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }
        else
        {
            throw new HttpRequestException($"Error response from action: {action} service: {response.StatusCode}");
        }
    }
}