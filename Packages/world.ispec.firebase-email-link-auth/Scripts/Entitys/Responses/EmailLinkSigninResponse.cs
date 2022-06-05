namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IEmailLinkSigninResponse
    {
        public string Kind { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string LocalId { get; set; }
        public bool IsNewUser { get; set; }
    }

    internal class EmailLinkSigninResponse : IEmailLinkSigninResponse
    {
        public string Kind { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public string ExpiresIn { get; set; }
        public string LocalId { get; set; }
        public bool IsNewUser { get; set; }

        public EmailLinkSigninResponse(
            string kind,
            string idToken,
            string email,
            string refreshToken,
            string expiresIn,
            string localId,
            bool isNewUser
        )
        {
            Kind = kind;
            IdToken = idToken;
            Email = email;
            RefreshToken = refreshToken;
            ExpiresIn = expiresIn;
            LocalId = localId;
            IsNewUser = isNewUser;
        }
    }
}
