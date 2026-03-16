using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSourceBynChk")]
public partial class TblxmlsourceBynChk
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(25)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    public double? AmountBefore { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    public byte? IsRevenue { get; set; }

    [Column("SubID")]
    [StringLength(50)]
    public string SubId { get; set; }

    [Column("MainID")]
    [StringLength(50)]
    public string MainId { get; set; }
}
