using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("XmlChkSource")]
public partial class XmlChkSource
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(30)]
    public string TotalDebit { get; set; }

    public double? TotalCredit { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    [StringLength(250)]
    public string AccountSubDescription { get; set; }

    [Column("AccountSubID")]
    [StringLength(250)]
    public string AccountSubId { get; set; }

    public double? Amount { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    public bool IsProcessed { get; set; }

    [StringLength(50)]
    public string EntryNumber { get; set; }
}
