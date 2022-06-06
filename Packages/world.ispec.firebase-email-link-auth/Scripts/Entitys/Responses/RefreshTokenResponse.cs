namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IRefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }
    }

    internal class RefreshTokenResponse : IRefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string IdToken { get; set; }
        public string UserId { get; set; }
        public string ProjectId { get; set; }

        public RefreshTokenResponse(
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
