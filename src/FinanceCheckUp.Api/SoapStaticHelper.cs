using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Xml;

namespace FinanceCheckUp.Api;

// tüm metotlar için generic hale getirilecek



public class CustomHeaderBehavior : IEndpointBehavior
{
    private readonly string username;
    private readonly string password;

    public CustomHeaderBehavior(string username, string password)
    {
        this.username = username;
        this.password = password;
    }

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
        clientRuntime.ClientMessageInspectors.Add(new CustomMessageInspector(username, password));
    }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
    }

    public void Validate(ServiceEndpoint endpoint)
    {
    }
}

public class CustomMessageInspector(string username, string password) : IClientMessageInspector
{
    private readonly string username = username;
    private readonly string password = password;

    public void AfterReceiveReply(ref Message reply, object correlationState)
    {
    }

    public object BeforeSendRequest(ref Message request, IClientChannel channel)
    {
        var doc = new XmlDocument();
        var security = doc.CreateElement("wsse", "Security",
            "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
        var usernameToken = doc.CreateElement("wsse", "UsernameToken", security.NamespaceURI);

        var usernameElement = doc.CreateElement("wsse", "Username", security.NamespaceURI);
        usernameElement.InnerText = username;
        usernameToken.AppendChild(usernameElement);

        var passwordElement = doc.CreateElement("wsse", "Password", security.NamespaceURI);
        passwordElement.InnerText = password;
        usernameToken.AppendChild(passwordElement);

        security.AppendChild(usernameToken);
        var securityHeader = new XmlDocument().CreateNode(XmlNodeType.Element, "Security", security.NamespaceURI);
        securityHeader.InnerXml = security.InnerXml;
        request.Headers.Add(MessageHeader.CreateHeader("Security", security.NamespaceURI, securityHeader));

        return null;
    }
}