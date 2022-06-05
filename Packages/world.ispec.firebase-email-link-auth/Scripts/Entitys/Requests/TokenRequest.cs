namespace ispec.FirebaseEmailLinkAuth
{
    internal interface ITokenRequest
    {
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }
    }

    internal class TokenRequest : ITokenRequest
    {
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }

        public TokenRequest(
            string grantType,
            string refreshToken
        )
        {
            GrantType = grantType;
            RefreshToken = refreshToken;
        }
    }
}
