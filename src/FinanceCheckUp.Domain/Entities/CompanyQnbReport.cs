using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("CompanyQnbReport")]
public partial class CompanyQnbReport
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string ReportName { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column("UserID")]
    public long? UserId { get; set; }

    public bool IsUpdated { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
