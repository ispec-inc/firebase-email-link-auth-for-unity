using JetBrains.Annotations;
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

        [JsonProperty("iOSAppStoreId")] [CanBeNull]
        public string IosAppStoreId { get; private set; }

        [JsonProperty("iOSBundleId")] [CanBeNull]
        public string IosBundleId { get; private set; }

        [JsonProperty("androidPackageName")] [CanBeNull]
        public string AndroidPackageName { get; private set; }

        [JsonProperty("androidMinimumVersion")] [CanBeNull]
        public string AndroidMinimumVersion { get; private set; }

        [JsonProperty("androidInstallApp")]
        public bool AndroidInstallApp { get; private set; }

        public GetOobConfirmationCodeRequest(
            string requestType,
            string email,
            string continueUrl,
            bool canHandleCodeInApp,
            [CanBeNull] string iosAppStoreId = null,
            [CanBeNull] string iosBundleId = null,
            [CanBeNull] string androidPackageName = null,
            [CanBeNull] string androidMinimumVersion = null,
            bool androidInstallApp = false
        )
        {
            RequestType = requestType;
            Email = email;
            ContinueUrl = continueUrl;
            CanHandleCodeInApp = canHandleCodeInApp;
            IosAppStoreId = iosAppStoreId;
            IosBundleId = iosBundleId;
            AndroidPackageName = androidPackageName;
            AndroidMinimumVersion = androidMinimumVersion;
            AndroidInstallApp = androidInstallApp;
        }
    }
}
