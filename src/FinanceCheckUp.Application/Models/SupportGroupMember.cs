namespace FinanceCheckUp.Application.Models
{
    public class SupportGroupMember
    {
        public Int32 SupportGroupMemberID { get; set; }
        public Int32 SupportGroupID { get; set; }
        public Int32 UserID { get; set; }
        public DateTime ModifiedDate { get; set; }

        public SupportGroupMember()
        {

        }
    }
}
