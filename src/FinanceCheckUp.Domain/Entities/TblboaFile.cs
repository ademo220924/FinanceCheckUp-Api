using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLBoaFile")]
public partial class TblboaFile
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string UuId { get; set; }

    [StringLength(250)]
    public string FileName { get; set; }

    [Column("FileTypeID")]
    public byte FileTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int DocumentPeriodYear { get; set; }

    public byte DocumentPeriodMonth { get; set; }

    [Column("CompanyID")]
    public long CompanyId { get; set; }

    public byte IsFinished { get; set; }
}
