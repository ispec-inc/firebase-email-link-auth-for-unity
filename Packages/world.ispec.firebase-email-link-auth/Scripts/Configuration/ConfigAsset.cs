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

        public string FirebaseWebApiKey => firebaseWebApiKey;
    }
}
