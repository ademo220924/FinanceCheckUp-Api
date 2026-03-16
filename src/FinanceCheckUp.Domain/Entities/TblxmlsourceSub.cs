using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSourceSub")]
public partial class TblxmlsourceSub
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(250)]
    public string EndDate { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }

    [Column("AccountSubID")]
    [StringLength(250)]
    public string AccountSubId { get; set; }

    [StringLength(250)]
    public string AccountSubDescription { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    public double? Amount { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    public double? Borc { get; set; }

    public double? Alacak { get; set; }

    public double? Amountz { get; set; }

    public double? AmountBakiye { get; set; }
}
