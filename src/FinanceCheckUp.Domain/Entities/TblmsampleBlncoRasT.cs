using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMSampleBlncoRasT")]
public partial class TblmsampleBlncoRasT : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }


    [Column("AccountMainID")]
    [StringLength(50)]
    public string AccountMainId { get; set; }

    [StringLength(350)]
    public string AccountMainDescription { get; set; }

    [StringLength(15)]
    public string DebitCreditCode { get; set; }

    public double? Acilis { get; set; }

    public double? January { get; set; }

    public double? February { get; set; }

    public double? March { get; set; }

    public double? April { get; set; }

    public double? May { get; set; }

    public double? June { get; set; }

    public double? July { get; set; }

    public double? August { get; set; }

    public double? September { get; set; }

    public double? October { get; set; }

    public double? November { get; set; }

    public double? December { get; set; }

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

    public object? this[string propertyName]
    {
        get => this.GetType().GetProperty(propertyName)?.GetValue(this, null);
        set => this.GetType().GetProperty(propertyName)?.SetValue(this, value, null);
    }
}
