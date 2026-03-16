using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("XmlCheckGroupTest")]
public partial class XmlCheckGroupTest
{
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

    [StringLength(15)]
    public string DebitCreditCode { get; set; }
}
