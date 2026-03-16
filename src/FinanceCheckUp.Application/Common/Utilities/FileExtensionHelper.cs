using FinanceCheckUp.Domain.Common.Enums;
using FinanceCheckUp.Framework.Core.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace FinanceCheckUp.Application.Common.Utilities;

public class FileExtensionItem
{
    public required string[] Extensions { get; set; }
    public required FileType FileType { get; set; }
}



public static class FileExtensionHelper
{

    public static FileType GetFileType(string extension) => ExtensionList.FirstOrDefault(p => p.Extensions.Contains(extension))!.FileType;


    public static byte[] ExportToCsv<T>(List<T> model) where T : class, new()
    {
        var sb = new StringBuilder();
        var classProps = typeof(T).GetProperties();
        var templateColumns = classProps.Select(s => s.Name).ToList();
        sb.AppendLine(string.Join(",", templateColumns));

        foreach (var item in model)
        {
            var rowValue = string.Empty;
            foreach (var t in classProps)
            {
                var val = t.GetValue(item);

                if (val != null && val.GetType().IsGenericType)
                {
                    if (t.GetValue(item, null) is List<string> itemListObject) rowValue += string.Join(",", itemListObject.ToArray<string>()) + ",";
                }

                rowValue += val + ",";
            }

            sb.AppendLine(rowValue.TrimEnd(','));
        }

        var byteArray = Encoding.ASCII.GetBytes(sb.ToString());
        return byteArray;
    }

    public static byte[] GetFileBytes(this IFormFile imageFile)
    {
        using var ms = new MemoryStream();
        imageFile.CopyTo(ms);
        var fileBytes = ms.ToArray();
        return fileBytes;
    }

    public static FileExtensionItem? GetFileExtensionList(this FileType fileType)
    {
        return ExtensionList.FirstOrDefault(p => p.FileType == fileType);
    }

    public static string[] FileExtensionList
    {
        get
        {
            List<string> list = [];
            ExtensionList.ForEach(item => list.AddRange(item.Extensions));
            return list.ToArray();
        }
    }

    private static List<FileExtensionItem> ExtensionList =>
    [
        new FileExtensionItem
        {
            FileType = FileType.Image,
            Extensions = [".jpg", ".jpeg", ".png", ".webp", ".gif", ".ico", ".bmp"]
        },

        new FileExtensionItem
        {
            FileType = FileType.Video,
            Extensions = [".mpg", ".mpeg", ".mp2", ".mpe", ".flv", ".mov", ".webm", ".gif", ".gifv", ".avi", ".mp4"]
        },

        new FileExtensionItem
        {
            FileType = FileType.Audio,
            Extensions = [".mp3"]
        },

        new FileExtensionItem
        {
            FileType = FileType.Document,
            Extensions = [".xml", ".pdf", ".zip", ".xls", ".xlsx"]
        }
    ];

    public static Task IsCorrectFileExtension(FileType[] fileTypes, string extension)
    {
        var expectedFileExtensions = fileTypes.Length != 0
            ? ExtensionList
                .Where(c => fileTypes.Contains(c.FileType))
                .SelectMany(c => c.Extensions).ToArray()
            : ExtensionList.SelectMany(c => c.Extensions).ToArray();

        if (!expectedFileExtensions.Contains(extension.ToLower()))
            return Task.FromException<DocumentTypeException>(new DocumentTypeException(nameof(FileType), string.Join(',', expectedFileExtensions.Distinct())));
        return Task.FromResult(true);
    }
}