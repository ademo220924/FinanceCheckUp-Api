namespace FinanceCheckUp.Application.Models
{
    public class LoginInputModel
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string grantType { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public LoginInputModel(string clientId_, string clientSecret_, string grantType_, string username_, string password_)
        {

            clientId = clientId_;
            clientSecret = clientSecret_;
            grantType = grantType_;
            username = username_;
            password = password_;


        }
    }
}
