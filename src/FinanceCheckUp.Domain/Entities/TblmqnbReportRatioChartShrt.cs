using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMQnbReportRatioChartShrt")]
public partial class TblmqnbReportRatioChartShrt
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(50)]
    public string AccountMainId { get; set; }

    [StringLength(350)]
    public string AccountMainDescription { get; set; }

    public double? Amount { get; set; }

    public double? Amount1 { get; set; }

    public double? Amount2 { get; set; }

    public double? Amount3 { get; set; }

    public double? Amount4 { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [Column("MainTypeID")]
    public byte? MainTypeId { get; set; }

    [Column("ColorID")]
    public byte? ColorId { get; set; }
}
