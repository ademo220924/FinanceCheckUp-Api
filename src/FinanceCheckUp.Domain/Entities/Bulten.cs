using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("BULTEN")]
public partial class Bulten : ISqlServerEntity<int>
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(750)]
    public string Title { get; set; }

    [StringLength(750)]
    public string SubTitle { get; set; }

    [StringLength(1951)]
    public string Kapsam { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? YururlulukTarih { get; set; }

    [StringLength(255)]
    public string DuzenleyenKurum { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int? CreatedUser { get; set; }
}
