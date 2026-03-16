using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMizanErrzoneResultYSon")]
public partial class TblmizanErrzoneResultYson
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }

    public byte? ColorDesc { get; set; }

    [StringLength(750)]
    public string Description { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public double? Amount { get; set; }
}
