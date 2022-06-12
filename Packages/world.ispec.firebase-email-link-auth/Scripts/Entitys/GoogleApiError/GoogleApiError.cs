using System.Collections.Generic;
using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class GoogleApiError
    {
        [JsonProperty("errors")]
        public List<GoogleApiErrorDetail> Errors { get; private set; }

        [JsonProperty("code")]
        public int Code { get; private set; }

        [JsonProperty("message")]
        public string Message { get; private set; }

        public GoogleApiError(
            List<GoogleApiErrorDetail> errors,
            int code,
            string message
        )
        {
            Errors = errors;
            Code = code;
            Message = message;
        }
    }
}
