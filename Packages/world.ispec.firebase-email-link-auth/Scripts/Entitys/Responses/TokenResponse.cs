namespace ispec.FirebaseEmailLinkAuth
{
    internal interface ITokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
    }

    internal class TokenResponse : ITokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }

        public TokenResponse(
            string accessToken,
            string expiresIn,
            string tokenType,
            string refreshToken,
            string idToken,
            string userId,
            string projectId
        )
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
            RefreshToken = refreshToken;
            IdToken = idToken;
            UserId = userId;
            ProjectId = projectId;
        }
    }
}
