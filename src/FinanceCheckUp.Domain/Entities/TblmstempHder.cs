using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMSTempHder")]
public partial class TblmstempHder
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [StringLength(350)]
    public string GroupName { get; set; }

    public int? CounterZone { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }
}
