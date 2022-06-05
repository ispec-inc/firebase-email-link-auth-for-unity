namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IEmailLinkSigninRequest
    {
        public string Email { get; set; }
        public string OobCode { get; set; }
        public bool ReturnSecureToken { get; set; }
    }

    internal class EmailLinkSigninRequest : IEmailLinkSigninRequest
    {
        public string Email { get; set; }
        public string OobCode { get; set; }
        public bool ReturnSecureToken { get; set; }

        public EmailLinkSigninRequest(
            string email,
            string oobCode,
            bool returnSecureToken
        )
        {
            Email = email;
            OobCode = oobCode;
            ReturnSecureToken = returnSecureToken;
        }
    }
}
