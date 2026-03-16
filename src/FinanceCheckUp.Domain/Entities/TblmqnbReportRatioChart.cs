using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMQnbReportRatioChart")]
public partial class TblmqnbReportRatioChart
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(50)]
    public string AccountMainId { get; set; }

    [StringLength(350)]
    public string AccountMainDescription { get; set; }

    [StringLength(15)]
    public string DebitCreditCode { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [Column("MainTypeID")]
    public byte? MainTypeId { get; set; }

    [Column("ColorID")]
    public byte? ColorId { get; set; }
}
