using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLXMLSourceMain")]
public partial class TblxmlsourceMain
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }
    public string AccountMainID { get; set; }
    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    public double? Amount { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    public double? AmountBakiye { get; set; }
    public string AccountSubID { get; set; }
    public string AccountSubDescription { get; set; }
}
