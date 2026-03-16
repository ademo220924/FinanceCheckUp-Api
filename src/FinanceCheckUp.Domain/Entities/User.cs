using FinanceCheckUp.Framework.Data.MsSql;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("User")]
public partial class User : ISqlServerEntity<long>
{
    [Key]
    [Column("ID")]
    public long Id { get; set; }

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
    public long UserTypeId { get; set; }

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


    //public string UserType => UserTypes.Get_Types(this.UserTypeID) == null ? "Customer" : UserTypes.Get_Types(this.UserTypeID).Type;


    //ToDo: jwt için eklendi   database de modele eklenecek

    public byte[]? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public bool? Status { get; set; }
}


public class HhvnUsers
{
    [Column("ID")]
    public int Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    //[Range(1, int.MaxValue, ErrorMessage = "Şehir Bilgisi Seçilmelidir ")]    validation yap
    public int CityID { get; set; }
    public long CompanyID { get; set; }
    public bool IsDeleted { get; set; }
    //[Range(1, int.MaxValue, ErrorMessage = "Kullnıcı Tipi Bilgisi Seçilmelidir ")]   validation yap
    public short UserTypeID { get; set; }
    public List<long> CompanyList { get; set; }
    public string PasswordReset { get; set; }
    public string Password { get; set; }
    private string profilePhoto;
    public string SessionGuid { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

    public string CityName => string.Empty;
    public string UserType => string.Empty;// userTypeManager.Get_Types(this.UserTypeID) == null ? "Customer" : userTypeManager.Get_Types(this.UserTypeID).Type;
    public string ProfilePhoto
    {
        get { return profilePhoto; }

        set
        {
            if (string.IsNullOrEmpty(value))
            { profilePhoto = "https://www.fincheckup.ai/cus.png"; }
            else
            {
                profilePhoto = value;

            }
        }
    }
    public string FullName => FirstName + " " + LastName;
    private int selectedYear { get; set; }
    public int SelectedYear
    {
        get { return selectedYear; }
        set
        {
            if (value < 2010) { selectedYear = DateTime.Now.Year; }
            else
            {
                selectedYear = value;
            }
        }
    }

    public string qnbUserId { get; set; }
    public string qnbCorporateId { get; set; }
    public string mainPlatform { get; set; }
    public byte isAdminUser { get; set; }
    public string AccessToken { get; set; }

    public string UserGuid { get; set; }
}