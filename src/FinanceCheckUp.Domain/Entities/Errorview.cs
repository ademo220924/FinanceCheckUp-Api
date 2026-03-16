using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
public partial class Errorview
{
    public int? Pass { get; set; }

    public int? Fail { get; set; }

    public int? MonthPay { get; set; }

    public int? YearPay { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }
}
