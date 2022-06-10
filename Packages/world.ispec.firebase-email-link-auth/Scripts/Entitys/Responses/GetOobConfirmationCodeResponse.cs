using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class GetOobConfirmationCodeResponse
    {
        [JsonProperty("kind")]
        public string Kind { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        public GetOobConfirmationCodeResponse(
            string kind,
            string email
        )
        {
            Kind = kind;
            Email = email;
        }
    }
}
