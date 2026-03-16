using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("MCodeZen")]
public partial class McodeZen
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(450)]
    public string MainDescription { get; set; }

    [StringLength(450)]
    public string MainDescriptionEng { get; set; }

    [Column("ShortTypeID")]
    [StringLength(2)]
    public string ShortTypeId { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [StringLength(455)]
    public string TypeDescription { get; set; }

    [Column("SubTypeID")]
    public int? SubTypeId { get; set; }

    [StringLength(450)]
    public string SubTypeDescription { get; set; }

    [Column("MainTypeID")]
    public int? MainTypeId { get; set; }

    [StringLength(450)]
    public string MainTypeDescription { get; set; }

    public byte IsNegatif { get; set; }

    [Column("LikiditeID")]
    public int? LikiditeId { get; set; }

    [Column("LikiditeMainID")]
    public int? LikiditeMainId { get; set; }

    [Column("WCapitalID")]
    public int? WcapitalId { get; set; }

    [Column("WCapitalMainID")]
    public int? WcapitalMainId { get; set; }

    [StringLength(5)]
    public string DebitCredit { get; set; }

    [Column("QnbTypeID")]
    public int? QnbTypeId { get; set; }
}
