using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLMRevenueRasTKon")]
public partial class TblmrevenueRasTkon
{
    [Column("AccountMainID")]
    [StringLength(50)]
    public string AccountMainId { get; set; }

    [StringLength(350)]
    public string AccountMainDescription { get; set; }

    [StringLength(15)]
    public string DebitCreditCode { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public int? Year { get; set; }

    [StringLength(350)]
    public string GroupName { get; set; }

    public int? CounterZone { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    public int? IsHidden { get; set; }

    public byte? LastMonth { get; set; }

    [Column("ID")]
    public long Id { get; set; }
}
