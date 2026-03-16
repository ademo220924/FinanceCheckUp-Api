using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceCheckUp.Domain.Entities;

[Table("C_ACCOUNTERROR")]
public partial class CAccounterror
{
    [Key]
    [Column("MainID")]
    public long MainId { get; set; }

    [Column("ID")]
    public long? Id { get; set; }

    [StringLength(250)]
    public string StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EndDate { get; set; }

    [StringLength(250)]
    public string EnteredBy { get; set; }

    [StringLength(250)]
    public string EnteredDate { get; set; }

    [StringLength(250)]
    public string EntryNumber { get; set; }

    [Column("BatchID")]
    [StringLength(250)]
    public string BatchId { get; set; }

    [StringLength(450)]
    public string BatchDescription { get; set; }

    public double? TotalDebit { get; set; }

    public double? TotalCredit { get; set; }

    [StringLength(250)]
    public string DocumentType { get; set; }

    [StringLength(450)]
    public string DocumentTypeDescription { get; set; }

    [StringLength(250)]
    public string DocumentNumber { get; set; }

    [StringLength(250)]
    public string DocumentDate { get; set; }

    [StringLength(250)]
    public string PaymentMethod { get; set; }

    [Column("AccountMainID")]
    [StringLength(250)]
    public string AccountMainId { get; set; }

    [StringLength(250)]
    public string AccountMainDescription { get; set; }

    [StringLength(250)]
    public string AccountSubDescription { get; set; }

    [Column("AccountSubID")]
    [StringLength(250)]
    public string AccountSubId { get; set; }

    public double? Amount { get; set; }

    [StringLength(250)]
    public string DebitCreditCode { get; set; }

    [StringLength(250)]
    public string PostingDate { get; set; }

    [StringLength(450)]
    public string DetailComment { get; set; }

    [Column("CsvID")]
    public int? CsvId { get; set; }

    public bool Processed { get; set; }

    public bool Processed1 { get; set; }

    public bool Processed21 { get; set; }

    public bool ProcessedM { get; set; }

    public bool ProcessedL { get; set; }

    public bool IsFailed { get; set; }

    [Column("ISChanged")]
    public bool Ischanged { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [StringLength(50)]
    public string Status { get; set; }

    public int IsOpener { get; set; }

    public byte IsPassedEntry { get; set; }

    public byte? IsClosed { get; set; }

    [StringLength(450)]
    public string EntryComment { get; set; }

    [StringLength(750)]
    public string Description { get; set; }

    public byte ColorDesc { get; set; }

    public byte ColorDescTax { get; set; }

    [StringLength(750)]
    public string DescriptionTax { get; set; }

    public byte ColorDescInside { get; set; }

    [StringLength(750)]
    public string DescriptionInside { get; set; }
}
