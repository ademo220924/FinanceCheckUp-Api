using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXmlFile")]
public partial class TblxmlFile
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string CsvName { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("TBLXmlID")]
    public long TblxmlId { get; set; }

    public byte Issetted { get; set; }

    [Column("SortID")]
    public int SortId { get; set; }

    public byte IsFinished { get; set; }

    // ToDo: kontrol et database de var mı
    public int LastSettedCount { get; set; }
}
