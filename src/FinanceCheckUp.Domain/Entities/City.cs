using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

public partial class City
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("City")]
    [StringLength(255)]
    public string CityName { get; set; }
}
