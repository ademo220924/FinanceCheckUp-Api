using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXmlFolderFile")]
public partial class TblxmlFolderFile
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string CsvName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("TBLXmlID")]
    public long? TblxmlId { get; set; }

    public byte Issetted { get; set; }

    [Column("SortID")]
    public int SortId { get; set; }

    public byte IsFinished { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public byte? MainMonth { get; set; }

    public int? MainYear { get; set; }

    public bool IsLedger { get; set; }

    [Column("ISErrored")]
    public bool? Iserrored { get; set; }
}
