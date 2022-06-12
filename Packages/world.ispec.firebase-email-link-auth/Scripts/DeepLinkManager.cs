using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    public class DeepLinkManager : MonoBehaviour
    {
        private static DeepLinkManager Instance { get; set; }
        public string deeplinkURL;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;                
                Application.deepLinkActivated += OnDeepLinkActivated;
                if (!string.IsNullOrEmpty(Application.absoluteURL))
                {
                    OnDeepLinkActivated(Application.absoluteURL);
                }
                else deeplinkURL = "[none]";
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnDeepLinkActivated(string url)
        {
        }
    }
}
