using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("Appointment")]
public partial class Appointment : ISqlServerEntity<int>
{

    [Key]
    [Column("AppointmentId")]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [StringLength(350)]
    public string Text { get; set; }

    [StringLength(950)]
    public string Description { get; set; }

    public bool AllDay { get; set; }

    public byte? PriorityId { get; set; }

    public byte Status { get; set; }

}
