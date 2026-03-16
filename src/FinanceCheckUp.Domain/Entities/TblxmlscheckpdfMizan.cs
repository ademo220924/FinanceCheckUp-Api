using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSCheckpdfMizan")]
public partial class TblxmlscheckpdfMizan
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountMainID")]
    [StringLength(25)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    public double? Amount1 { get; set; }

    public int? Amount1Diff { get; set; }

    public double? Amount2 { get; set; }

    public int? Amount2Diff { get; set; }

    public double? Amount3 { get; set; }

    public int? Amount3Diff { get; set; }

    public double? Amount4 { get; set; }

    public int? Amount4Diff { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [Column("PageID")]
    public int? PageId { get; set; }

    public byte? MainMonth { get; set; }
}
