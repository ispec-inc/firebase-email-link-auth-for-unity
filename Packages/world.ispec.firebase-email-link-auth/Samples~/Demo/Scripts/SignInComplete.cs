using ispec.FirebaseEmailLinkAuth;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo
{
    public class SignInComplete : MonoBehaviour
    {
        private IFirebaseEmailLinkAuth _firebaseEmailLinkAuth;

        public void Awake()
        {
            _firebaseEmailLinkAuth = FirebaseEmailLinkAuth.GetInstance();
        }

        public void TappedButton()
        {
            SignOut();
            TransitionToEmailInputScreen();
        }

        private void SignOut()
        {
            _firebaseEmailLinkAuth.SignOut();
        }

        private static void TransitionToEmailInputScreen()
        {
            SceneManager.LoadScene("01-EmailInput");
        }
    }
}
