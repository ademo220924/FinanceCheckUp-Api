using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXmJournalFile")]
public partial class TblxmJournalFile
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column("AccountMainID")]
    [StringLength(25)]
    public string AccountMainId { get; set; }

    public double? Amount { get; set; }

    public int? Year { get; set; }

    [StringLength(5)]
    public string DebitCredit { get; set; }

    public bool IsNegatif { get; set; }
}
