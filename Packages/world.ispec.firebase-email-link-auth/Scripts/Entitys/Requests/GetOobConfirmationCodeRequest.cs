using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class GetOobConfirmationCodeRequest
    {
        [JsonProperty("requestType")]
        public string RequestType { get; private set; }

        [JsonProperty("email")]
        public string Email { get; private set; }

        [JsonProperty("continueUrl")]
        public string ContinueUrl { get; private set; }

        [JsonProperty("canHandleCodeInApp")]
        public bool CanHandleCodeInApp { get; private set; }

        public GetOobConfirmationCodeRequest(
            string requestType,
            string email,
            string continueUrl,
            bool canHandleCodeInApp
        )
        {
            RequestType = requestType;
            Email = email;
            ContinueUrl = continueUrl;
            CanHandleCodeInApp = canHandleCodeInApp;
        }
    }
}
