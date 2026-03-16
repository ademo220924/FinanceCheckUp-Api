using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("ReverseCatch")]
public partial class ReverseCatch
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("qnbUserId")]
    [StringLength(10)]
    public string QnbUserId { get; set; }

    [Column("qnbCorporateId")]
    [StringLength(11)]
    public string QnbCorporateId { get; set; }

    [Column("transactionId")]
    [StringLength(55)]
    public string TransactionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public bool IsDeleted { get; set; }

    [Column("RequestTypeID")]
    public byte? RequestTypeId { get; set; }

    [Column("UserID")]
    public long? UserId { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }
}
