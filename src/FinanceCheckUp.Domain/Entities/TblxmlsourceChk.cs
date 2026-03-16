using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSourceChk")]
public partial class TblxmlsourceChk
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    public double? Amount { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public double? AmountBakiye { get; set; }

    public int? Year { get; set; }

    [Column("SubTypeID")]
    public byte? SubTypeId { get; set; }

    [Column("MainTypeID")]
    public byte? MainTypeId { get; set; }
}
