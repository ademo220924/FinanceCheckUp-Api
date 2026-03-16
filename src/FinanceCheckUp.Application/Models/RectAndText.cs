namespace FinanceCheckUp.Application.Models
{
    public class RectAndText
    {
        public iTextSharp.text.Rectangle Rect;
        public string Text;
        public RectAndText(iTextSharp.text.Rectangle rect, string text)
        {
            Rect = rect;
            Text = text;
        }

    }
}
