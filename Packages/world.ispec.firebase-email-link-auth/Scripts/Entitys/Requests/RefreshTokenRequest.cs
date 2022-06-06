namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IRefreshTokenRequest
    {
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }
    }

    internal class RefreshTokenRequest : IRefreshTokenRequest
    {
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }

        public RefreshTokenRequest(
            string grantType,
            string refreshToken
        )
        {
            GrantType = grantType;
            RefreshToken = refreshToken;
        }
    }
}
