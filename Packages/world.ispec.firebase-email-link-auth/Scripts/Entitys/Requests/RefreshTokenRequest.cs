using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class RefreshTokenRequest
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; private set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; private set; }

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
