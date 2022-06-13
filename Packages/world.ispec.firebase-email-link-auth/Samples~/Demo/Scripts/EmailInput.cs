using System.Threading.Tasks;
using ispec.FirebaseEmailLinkAuth;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Demo
{
    public class EmailInput : MonoBehaviour
    {
        private IFirebaseEmailLinkAuth _firebaseEmailLinkAuth;
        public InputField emailInput;

        public void Awake()
        {
            _firebaseEmailLinkAuth = FirebaseEmailLinkAuth.GetInstance();
        }

        public async void Start()
        {
            if (await IsSignIn())
            {
                TransitionToSignInCompleteScreen();
            }
        }

        public void TappedButton()
        {
            SendAuthEmail();
        }

        private async Task<bool> IsSignIn()
        {
            return !string.IsNullOrWhiteSpace(
                await _firebaseEmailLinkAuth.GetToken()
            );
        }

        private async void SendAuthEmail()
        {
            var response = await _firebaseEmailLinkAuth
                .SendAuthLinkEmail(
                    emailInput.text
                );

            if (response)
            {
                TransitionToAuthEmailSendCompleteScreen();
            }
            else
            {
                TransitionToErrorScreen();
            }
        }

        public static void TransitionToAuthEmailSendCompleteScreen()
        {
            SceneManager.LoadScene("02-AuthEmailSendComplete");
        }

        public static void TransitionToSignInCompleteScreen()
        {
            SceneManager.LoadScene("03-SignInComplete");
        }

        public static void TransitionToErrorScreen()
        {
            SceneManager.LoadScene("99-Error");
        }
    }
}
