using System.Xml;
using System.Xml.Serialization;

namespace FinanceCheckUp.Application.Common.Utilities;


public class SerializeExtension<T> where T : class
{
    public static string Serialize(T obj)
    {
        var xsSubmit = new XmlSerializer(typeof(T));
        using var stringWriter = new StringWriter();
        using var writer = new XmlTextWriter(stringWriter);
        writer.Formatting = Formatting.Indented;
        xsSubmit.Serialize(writer, obj);
        return stringWriter.ToString();
    }
}