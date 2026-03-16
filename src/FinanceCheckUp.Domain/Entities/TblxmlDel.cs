using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXmlDel")]
public partial class TblxmlDel
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(250)]
    public string CsvName { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DocumentDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime UploadDate { get; set; }

    public int Year { get; set; }

    public byte IsDeleted { get; set; }

    [StringLength(250)]
    public string XmlDocName { get; set; }

    [Column("CsvID")]
    public long? CsvId { get; set; }
}
