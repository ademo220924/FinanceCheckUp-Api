using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMizan")]
public class Tblmizan : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(450)]
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

    public int MainMonth { get; set; }
}
