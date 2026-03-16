using System.ComponentModel.DataAnnotations;

namespace FinanceCheckUp.Application.Models
{
    public class SupportGroup
    {

        public int SupportGroupID { get; set; }
        [Required(ErrorMessage = "Bu alan gerekli")]
        public string SupportGroupName { get; set; }
        public string SupportGroupDescription { get; set; }
        public int ImpactID { get; set; }
        public int UserID { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string TechnicanFullName { get; set; }
        public string ImpactName { get; set; }
    }
}
