using System;

namespace ispec.FirebaseEmailLinkAuth
{
    internal class UnixTimeGetter
    {
        public static int GetCurrentUnixTime()
        {
            return (int)DateTime.UtcNow.Subtract(
                new DateTime(1970, 1, 1)
            ).TotalSeconds;
        }
    }
}
