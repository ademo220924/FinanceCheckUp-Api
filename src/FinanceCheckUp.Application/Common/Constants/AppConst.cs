using FinanceCheckUp.Application.Models;
using System.Collections.Immutable;

namespace FinanceCheckUp.Application.Common.Constants;

public static class AppConst
{
    public const string SystemTimeZone = "Turkey Standard Time";
    public const string DateFormat = "yyyy.MM.dd";
    public const string DateTimeFormat = "yyyy.MM.dd HH:mm:ss";
    public const int DefaultPageLimit = 50;
    public const int DefaultPageSkip = 0;
    public static readonly string EnvironmentValue = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "test";
    public const string FileUploadPath = "UploadFiles";
    public const int DocumentMinYear = 2010;
    public const int DocumentMaxYear = 2050;
    public const long DocumentMaxFileSize = 200 * 2048 * 2048;
    public const int CommitBatchSize = 1000;
    public const long MultipartBodyLengthLimit = 209715200;
    public const long RequestSizeLimit = 500000000; // 209715200

    public static readonly ImmutableDictionary<int, List<int>> Quarters = new Dictionary<int, List<int>>
    {
        {1, [1, 2, 3] },
        {2, [4, 5, 6] },
        {3, [7, 8, 9] },
        {4, [10, 11, 12] },
    }.ToImmutableDictionary();

    public static readonly ImmutableDictionary<int, string> Months = new Dictionary<int, string>
    {
        {1, "January"},
        {2, "February"},
        {3, "March"},
        {4, "April"},
        {5, "May"},
        {6, "June"},
        {7, "July"},
        {8, "August"},
        {9, "September"},
        {10, "October"},
        {11, "November"},
        {12, "December"},
    }.ToImmutableDictionary();

    public static readonly ImmutableDictionary<int, string> MonthsForTurkish = new Dictionary<int, string>
    {
        {1, "Ocak"},
        {2, "Şubat"},
        {3, "Mart"},
        {4, "Nisan"},
        {5, "Mayıs"},
        {6, "Haziran"},
        {7, "Temmuz"},
        {8, "Ağustor"},
        {9, "Eylül"},
        {10, "Ekim"},
        {11, "Kasım"},
        {12, "Aralık"},
    }.ToImmutableDictionary();

    public static readonly IEnumerable<PriorityResource> PriorityResources = [
            new PriorityResource {
                Id = 1,
                Text = "Yüksek",
                Color = "#cc5c53"
            },
            new PriorityResource {
                Id = 2,
                Text = "Normal",
                Color = "#ff9747"
            }
        ];
}