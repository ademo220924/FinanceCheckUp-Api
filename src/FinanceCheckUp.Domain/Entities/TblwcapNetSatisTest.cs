using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLWcapNetSatisTest")]
public partial class TblwcapNetSatisTest
{
    public double? January { get; set; }

    public double? February { get; set; }

    public double? March { get; set; }

    public double? April { get; set; }

    public double? May { get; set; }

    public double? June { get; set; }

    public double? July { get; set; }

    public double? August { get; set; }

    public double? September { get; set; }

    public double? October { get; set; }

    public double? November { get; set; }

    public double? December { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }

    public int Year { get; set; }
}
