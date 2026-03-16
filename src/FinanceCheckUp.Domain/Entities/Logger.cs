using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("LOGGER")]
public partial class Logger
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("ERLOG")]
    public string Erlog { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
