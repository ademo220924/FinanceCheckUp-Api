using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLMNKzoneDetail")]
public partial class TblmnkzoneDetail
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("MainCodeID")]
    public int? MainCodeId { get; set; }

    public int? MainCode { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
