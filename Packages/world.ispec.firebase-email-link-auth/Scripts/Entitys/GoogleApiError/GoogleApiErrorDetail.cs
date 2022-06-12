using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class GoogleApiErrorDetail
    {
        [JsonProperty("domain")]
        public string Domain { get; private set; }

        [JsonProperty("reason")]
        public string Reason { get; private set; }

        [JsonProperty("message")]
        public string Message { get; private set; }

        public GoogleApiErrorDetail(
            string domain,
            string reason,
            string message
        )
        {
            Domain = domain;
            Reason = reason;
            Message = message;
        }
    }
}
