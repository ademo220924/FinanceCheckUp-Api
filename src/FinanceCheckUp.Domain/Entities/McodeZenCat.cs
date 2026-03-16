using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("MCodeZenCat")]
public partial class McodeZenCat
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [StringLength(455)]
    public string TypeDescription { get; set; }

    [StringLength(455)]
    public string TypeDescriptionEng { get; set; }

    [Column("ParentID")]
    public int? ParentId { get; set; }
}
