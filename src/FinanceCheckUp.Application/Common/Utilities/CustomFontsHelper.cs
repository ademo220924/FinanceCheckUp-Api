using FinanceCheckUp.Application.ExtensionHelpers;
using System.Drawing;
using System.Drawing.Text;


namespace FinanceCheckUp.Application.Common.Utilities;
public static class CustomFontsHelper
{
    static PrivateFontCollection fontCollection;
    public static FontCollection FontCollection
    {
        get
        {
            if (fontCollection == null)
            {
                var FileDic = "wwwroot\\fonts\\Mulish-Regular.ttf";
                string filePathZ = WebHelper.path;
                string FilePath = System.IO.Path.Combine(filePathZ, FileDic);
                fontCollection = new PrivateFontCollection();
                fontCollection.AddFontFile(FilePath);
            }
            return fontCollection;
        }
    }

    public static FontFamily GetFamily(string familyName)
    {
        return FontCollection.Families.FirstOrDefault(ff => ff.Name == familyName);
    }
}