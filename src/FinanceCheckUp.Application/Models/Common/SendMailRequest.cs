using System.Text;

namespace FinanceCheckUp.Application.Models.Common;

public class SendMailRequest
{
    public string mailto { get; set; }
    public string name { get; set; }
    public string education { get; set; }
    public string phone { get; set; }
    public string title { get; set; }
    public string content { get; set; }

    public string emailsechome()
    {

        StringBuilder sbr = new StringBuilder();

        sbr.AppendLine();
        sbr.AppendFormat("<br />Web Site Üzerinden Bir Mail Geldi ,<br /><br /><hr />");
        sbr.AppendLine();
        sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
        sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
        sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
        sbr.AppendFormat("Mesaj İçeriği = {0} , <br /> <br /> <hr />", this.content);
        sbr.AppendLine();
        sbr.AppendFormat("Güzel bir gün olsun <br />");

        return sbr.ToString();
    }
    public string emailsechomeinfo()
    {

        StringBuilder sbr = new StringBuilder();

        sbr.AppendLine();
        sbr.AppendFormat("<br />Web Site Üzerinden Bir  Teklif Talebi Mail Geldi ,<br /><br /><hr />");
        sbr.AppendLine();
        sbr.AppendFormat("İsim = {0} , <br /> ", this.name);
        sbr.AppendFormat("Şirket İsim = {0} , <br /> ", this.education);
        sbr.AppendFormat("Telefon = {0} , <br /> ", this.phone);
        sbr.AppendFormat("E-posta = {0} , <br /> ", this.mailto);
        sbr.AppendFormat("Mesaj İçeriği = {0} , <br /> <br /> <hr />", this.content);
        sbr.AppendLine();
        sbr.AppendFormat("Güzel bir gün olsun <br />");

        return sbr.ToString();
    }
}