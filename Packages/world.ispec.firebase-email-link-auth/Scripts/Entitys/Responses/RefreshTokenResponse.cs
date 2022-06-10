using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class RefreshTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        [JsonProperty("expires_in")]
        public string ExpiresIn { get; private set; }

        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

        [JsonProperty("id_token")]
        public string IdToken { get; private set; }

        [JsonProperty("user_id")]
        public string UserId { get; private set; }

        [JsonProperty("project_id")]
        public string ProjectId { get; private set; }

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
