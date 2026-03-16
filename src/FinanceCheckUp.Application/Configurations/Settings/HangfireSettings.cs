using System.Diagnostics.CodeAnalysis;

namespace FinanceCheckUp.Application.Configurations.Settings
{
    [ExcludeFromCodeCoverage]
    public class HangfireSettings
    {
        public string? ServerName { get; set; }
        public bool UseDashboard { get; set; }
        public string? DashboardPath { get; set; }
        public string? DatabasePrefix { get; set; }
        public string? DatabaseName { get; set; }
        public string? DashboardTitle { get; set; }
        public string? AppPathUrl { get; set; }
        public int AutomaticRetryCount { get; set; }
        public JobModel? Jobs { get; set; }

    }

    [ExcludeFromCodeCoverage]
    public class JobModel
    {
        public RecurringJobModel? Recurring { get; set; }
    }

    [ExcludeFromCodeCoverage]
    public class RecurringJobModel
    {
        public string? AccountReminderRuleJobCreatorCronExp { get; set; }
        public string? AccountReminderRuleJobCompareCronExp { get; set; }
    }
}
