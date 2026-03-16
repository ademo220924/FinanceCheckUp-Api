using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMNKTAKIS")]
public partial class Tblmnktaki
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TypeID")]
    public double? TypeId { get; set; }

    [StringLength(255)]
    public string MainDesc { get; set; }

    [Column("CompanyID")]
    public int? CompanyId { get; set; }

    public double? Amount { get; set; }

    public int? Year { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
