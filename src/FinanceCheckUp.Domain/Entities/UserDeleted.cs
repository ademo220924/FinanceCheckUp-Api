using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("UserDeleted")]
public partial class UserDeleted
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

    [Column("UserID")]
    public long UserId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; }

    [StringLength(50)]
    public string LastName { get; set; }

    [StringLength(50)]
    public string Phone { get; set; }

    [Column("CityID")]
    public int? CityId { get; set; }

    [StringLength(250)]
    public string Password { get; set; }

    [StringLength(250)]
    public string Email { get; set; }

    [StringLength(250)]
    public string ProfilePhoto { get; set; }

    [StringLength(250)]
    public string PasswordReset { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    [Column("UserTypeID")]
    public int UserTypeId { get; set; }

    [StringLength(90)]
    public string SessionGuid { get; set; }

    [Column("CompanyID")]
    public long CompanyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    public int SelectedYear { get; set; }

    [Column("qnbUserId")]
    [StringLength(10)]
    public string QnbUserId { get; set; }

    [Column("qnbCorporateId")]
    [StringLength(11)]
    public string QnbCorporateId { get; set; }

    [Column("mainPlatform")]
    [StringLength(21)]
    public string MainPlatform { get; set; }

    [Column("isAdminUser")]
    public byte IsAdminUser { get; set; }

    [StringLength(99)]
    public string AccessToken { get; set; }

    [StringLength(36)]
    public string UserGuid { get; set; }
}
