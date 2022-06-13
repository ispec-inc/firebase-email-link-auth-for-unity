using UnityEngine;
using UnityEngine.SceneManagement;

namespace Demo
{
    public class AuthEmailSendComplete : MonoBehaviour
    {
        public void TappedButton()
        {
            TransitionToEmailInputScreen();
        }

        private static void TransitionToEmailInputScreen()
        {
            SceneManager.LoadScene("01-EmailInput");
        }
    }
}
