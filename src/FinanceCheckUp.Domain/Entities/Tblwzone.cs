using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLWzone")]
public partial class Tblwzone : ISqlServerEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MainDescriptionID")]
    public int? MainDescriptionId { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }
}
