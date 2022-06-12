using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class GoogleApiErrorResponse
    {
        [JsonProperty("error")]
        public GoogleApiError Error { get; private set; }

        public GoogleApiErrorResponse(
            GoogleApiError error
        )
        {
            Error = error;
        }
    }
}
