using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Keyless]
[Table("TBLWzoneYD")]
public partial class TblwzoneYd
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("MainDescriptionID")]
    public int? MainDescriptionId { get; set; }

    [StringLength(250)]
    public string MainDescription { get; set; }
}
