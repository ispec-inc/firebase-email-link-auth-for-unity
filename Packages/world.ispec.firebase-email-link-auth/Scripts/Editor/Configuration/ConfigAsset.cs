using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth.Editor
{
    [CreateAssetMenu(
        fileName = "FirebaseEmailLinkAuthEditorConfig",
        menuName = "Firebase Email Link Auth/Editor Config File",
        order = 1
    )]
    internal class ConfigAsset : ScriptableObject
    {
        [SerializeField]
        private string domain = "";

        public string Domain => domain;
    }
}
