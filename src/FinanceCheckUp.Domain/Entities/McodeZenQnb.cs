using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("MCodeZenQnb")]
public partial class McodeZenQnb
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("QnbTypeID")]
    public int? QnbTypeId { get; set; }

    [StringLength(45)]
    public string QnbCode { get; set; }

    [StringLength(450)]
    public string MainDescription { get; set; }
}
