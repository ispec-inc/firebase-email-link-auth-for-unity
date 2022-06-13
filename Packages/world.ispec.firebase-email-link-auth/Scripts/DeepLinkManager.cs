using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ispec.FirebaseEmailLinkAuth
{
    public class DeepLinkManager : MonoBehaviour
    {
        private static DeepLinkManager Instance { get; set; }

        public UnityEvent signInSuccessful;
        public UnityEvent signInFailure;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }

            Instance = this;
            Application.deepLinkActivated += OnDeepLinkActivated;
            if (!string.IsNullOrEmpty(Application.absoluteURL))
            {
                OnDeepLinkActivated(Application.absoluteURL);
            }
            DontDestroyOnLoad(gameObject);
        }

        private async void OnDeepLinkActivated(string url)
        {
            var linkParameterValues = url
                .ToUrlQueryKeyValuePears()
                .GetValues("link");
            if (linkParameterValues == null)
            {
                signInFailure.Invoke();
                return;
            }

            var oobCodes= linkParameterValues
                .First()
                .ToUrlQueryKeyValuePears()
                .GetValues("oobCode");
            if (oobCodes == null)
            {
                signInFailure.Invoke();
                return;
            }

            var response = await FirebaseEmailLinkAuth
                .GetInstance()
                .SignIn(oobCodes.First());
            if (response)
            {
                signInSuccessful.Invoke();
            }
            else
            {
                signInFailure.Invoke();
            }
        }
    }
}
