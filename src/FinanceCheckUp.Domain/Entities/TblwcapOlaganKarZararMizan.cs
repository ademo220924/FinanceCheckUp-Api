using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLWcapOlaganKarZararMizan")]
public partial class TblwcapOlaganKarZararMizan
{
    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int Year { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }
}
