namespace ispec.FirebaseEmailLinkAuth
{
    internal class AuthData
    {
        public string EmailInConfirmation { get; set; }
        public string IdToken { get; set; }
        public string Email { get; set; }
        public string RefreshToken { get; set; }
        public int ExpirationTime { get; set; }

        public AuthData(
            string emailInConfirmation,
            string idToken,
            string email,
            string refreshToken,
            int expirationTime
        )
        {
            EmailInConfirmation = emailInConfirmation;
            IdToken = idToken;
            Email = email;
            RefreshToken = refreshToken;
            ExpirationTime = expirationTime;
        }
    }
}
