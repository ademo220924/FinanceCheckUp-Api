using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMQnbReportShrt")]
public partial class TblmqnbReportShrt
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

    public double? Amount1 { get; set; }

    public double? Amount2 { get; set; }

    public double? Amount3 { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [Column("MainTypeID")]
    public byte? MainTypeId { get; set; }

    [Column("percentageChk")]
    public double? PercentageChk { get; set; }

    [Column("percentageChka")]
    public double? PercentageChka { get; set; }

    [Column("percentageChkb")]
    public double? PercentageChkb { get; set; }

    [Column("percentageChkc")]
    public double? PercentageChkc { get; set; }
}
