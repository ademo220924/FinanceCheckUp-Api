using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMQnbReportRatioView")]
public partial class TblmqnbReportRatioView
{
    public double? AreaValue { get; set; }

    public double? SectorValue { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int Year { get; set; }

    [Column("TypeID")]
    public int TypeId { get; set; }

    [StringLength(250)]
    public string Description { get; set; }

    [Column("MainID")]
    public int MainId { get; set; }

    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TypeIDKunye")]
    public byte TypeIdkunye { get; set; }

    [Column("SectorValueII")]
    public double? SectorValueIi { get; set; }

    [Column("REELPUAN")]
    public double? Reelpuan { get; set; }

    [Column("USTKALEMPUAN")]
    public double? Ustkalempuan { get; set; }
}
