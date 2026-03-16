using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLBeyanname")]
public partial class Tblbeyanname
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("MainID")]
    [StringLength(50)]
    public string MainId { get; set; }

    [Column("SubID")]
    [StringLength(50)]
    public string SubId { get; set; }

    [StringLength(1)]
    public string FirstChar { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }

    [Column("CodeNCode")]
    [StringLength(50)]
    public string CodeNcode { get; set; }

    public byte IsRevenue { get; set; }
}
