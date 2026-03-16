using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLOneCheck")]
public partial class TbloneCheck
{
    [Column("ID")]
    [StringLength(150)]
    public string Id { get; set; }
}
