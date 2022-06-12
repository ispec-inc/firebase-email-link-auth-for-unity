using System;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class MailAddressChecker
    {
        public static bool IsEmailAddress(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            try
            {
                var _ = new System.Net.Mail.MailAddress(email);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }
    }
}
