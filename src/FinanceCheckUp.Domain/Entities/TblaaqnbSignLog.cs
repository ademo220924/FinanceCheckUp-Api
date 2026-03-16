using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("TBLAAQnbSignLog")]
public partial class TblaaqnbSignLog
{
    public TblaaqnbSignLog()
    {

    }
    public TblaaqnbSignLog(long userID, long companyID, int companyEntegratorID, DateTime createdDate, DateTime startDate, DateTime endDate, byte isDeclined, DateTime? declinedDate, long? declinedUserID, byte isDeclinedBank, DateTime? declinedDateBank, long? declinedUserIDBank, byte isForBankToo)
    {
        UserId = userID;
        CompanyId = companyID;
        CompanyEntegratorId = companyEntegratorID;
        CreatedDate = createdDate;
        StartDate = startDate;
        EndDate = endDate;
        IsDeclined = isDeclined;
        DeclinedDate = declinedDate;
        DeclinedUserId = declinedUserID;
        IsDeclinedBank = isDeclinedBank;
        DeclinedDateBank = declinedDateBank;
        DeclinedUserIdbank = declinedUserIDBank;
        IsForBankToo = isForBankToo;
    }

    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("UserID")]
    public long? UserId { get; set; }

    [Column("CompanyEntegratorID")]
    public int? CompanyEntegratorId { get; set; }

    [Column("CompanyID")]
    public long? CompanyId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    public byte IsDeclined { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeclinedDate { get; set; }

    [Column("DeclinedUserID")]
    public long? DeclinedUserId { get; set; }

    public byte IsDeclinedBank { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeclinedDateBank { get; set; }

    [Column("DeclinedUserIDBank")]
    public long? DeclinedUserIdbank { get; set; }

    public byte IsForBankToo { get; set; }
}
