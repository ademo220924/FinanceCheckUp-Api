using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSourceOne")]
public partial class TblxmlsourceOne
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("TypeID")]
    public byte? TypeId { get; set; }

    [Column("AccountMainID")]
    [StringLength(25)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    [StringLength(250)]
    public string AccountMainEng { get; set; }

    public double? Amount { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    public double? AmountBakiye { get; set; }

    public int? Year { get; set; }

    [Column("SubTypeID")]
    public byte? SubTypeId { get; set; }

    [Column("MainTypeID")]
    public byte? MainTypeId { get; set; }

    public bool? IsNegative { get; set; }

    public bool IsErrored { get; set; }

    public double? MainAmountTotal { get; set; }

    public double? Debit { get; set; }

    public double? Credit { get; set; }
}
