using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("XmlCheckGroup")]
public partial class XmlCheckGroup
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string EntryNumber { get; set; }

    public double? TotalCredit { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    [Column("AccountMainIDList")]
    public string AccountMainIdlist { get; set; }

    public bool IsFailed { get; set; }
}
