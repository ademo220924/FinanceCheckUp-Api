using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("CompanyCheck")]
public partial class CompanyCheck
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("AccountSubID")]
    [StringLength(50)]
    public string AccountSubId { get; set; }

    [StringLength(350)]
    public string AccountSubDescription { get; set; }

    [Column("AccountSubIValue")]
    public int? AccountSubIvalue { get; set; }

    [Column("AccountSubIDII")]
    [StringLength(50)]
    public string AccountSubIdii { get; set; }

    [Column("AccountSubDescriptionII")]
    [StringLength(350)]
    public string AccountSubDescriptionIi { get; set; }

    [Column("AccountSubIIValue")]
    public int? AccountSubIivalue { get; set; }

    public int? Year { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public byte IsDeleted { get; set; }
}
