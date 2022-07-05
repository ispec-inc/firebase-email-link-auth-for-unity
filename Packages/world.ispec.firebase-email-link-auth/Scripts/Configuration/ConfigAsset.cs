using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    [CreateAssetMenu(
        fileName = "FirebaseEmailLinkAuthConfig",
        menuName = "Firebase Email Link Auth/Config File",
        order = 1
    )]
    internal class ConfigAsset : ScriptableObject
    {
        [SerializeField]
        private string firebaseWebApiKey = "";

        [SerializeField]
        private string continueUrl = "";

        [SerializeField]
        private string iosAppStoreId = "";

        [SerializeField]
        private string iosBundleId = "";

        [SerializeField]
        private string androidPackageName = "";

        [SerializeField]
        private string androidMinimumVersion = "";

        [SerializeField]
        private bool androidInstallApp;

        public string FirebaseWebApiKey => firebaseWebApiKey;
        public string ContinueUrl => continueUrl;
        public string IosAppStoreId => iosAppStoreId;
        public string IosBundleId => iosBundleId;
        public string AndroidPackageName => androidPackageName;
        public string AndroidMinimumVersion => androidMinimumVersion;
        public bool AndroidInstallApp => androidInstallApp;
    }
}
