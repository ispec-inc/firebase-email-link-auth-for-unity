using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class EmailLinkSigninRequest
    {
        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("oobCode")]
        public string OobCode { get; private set; }

        [JsonProperty("returnSecureToken")]
        public bool ReturnSecureToken { get; private set; }

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
