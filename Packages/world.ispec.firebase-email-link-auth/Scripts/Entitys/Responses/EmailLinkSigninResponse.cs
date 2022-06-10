using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class EmailLinkSigninResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; private set; }

        [JsonProperty("idToken")]
        public string IdToken { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("refreshToken")]
        public string RefreshToken { get; private set; }

        [JsonProperty("expiresIn")]
        public string ExpiresIn { get; private set; }

        [JsonProperty("localId")]
        public string LocalId { get; private set; }

        [JsonProperty("isNewUser")]
        public bool IsNewUser { get; private set; }

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
