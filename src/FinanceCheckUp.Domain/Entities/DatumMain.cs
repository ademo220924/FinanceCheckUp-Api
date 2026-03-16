using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("DatumMain")]
public partial class DatumMain
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    [StringLength(250)]
    public string CsvName { get; set; }

    [StringLength(250)]
    public string DocumentMonthTr { get; set; }

    [StringLength(250)]
    public string DocumentMonth { get; set; }

    public bool Saved { get; set; }
}
