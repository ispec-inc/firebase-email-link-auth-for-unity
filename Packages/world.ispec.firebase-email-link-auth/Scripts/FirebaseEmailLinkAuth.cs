using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ispec.FirebaseEmailLinkAuth
{
    public interface IFirebaseEmailLinkAuth
    {
        public Task<bool> SendAuthLinkEmail(string email);
        public Task<(bool result, bool isNewUser)> SignIn(string oobCode);
        public Task<string> GetToken();
        [CanBeNull]
        public string GetUserEmail();
        public void SignOut();
    }

    public class FirebaseEmailLinkAuth : IFirebaseEmailLinkAuth
    {
        private readonly IGoogleApiGateway _googleApiGateway;
        private static readonly FirebaseEmailLinkAuth Instance = new FirebaseEmailLinkAuth();

        public static FirebaseEmailLinkAuth GetInstance()
        {
            return Instance;
        }

        private FirebaseEmailLinkAuth()
        {
            _googleApiGateway = new GoogleApiGateway(
                new RestApiGateway()
            );
        }

        public async Task<bool> SendAuthLinkEmail(string email)
        {
            if (!MailAddressChecker.IsEmailAddress(email))
            {
                return false;
            }

            try
            {
                var response = await _googleApiGateway.GetOobConfirmationCode(
                    new GetOobConfirmationCodeRequest(
                        "EMAIL_SIGNIN",
                        email,
                        Config.GetValue().ContinueUrl,
                        true,
                        GetNullOrValue(Config.GetValue().IosAppStoreId),
                        GetNullOrValue(Config.GetValue().IosBundleId),
                        GetNullOrValue(Config.GetValue().AndroidPackageName),
                        GetNullOrValue(Config.GetValue().AndroidMinimumVersion),
                        Config.GetValue().AndroidInstallApp
                    )
                );
                AuthDataStore.SetAuthData(
                    new AuthData(
                        response.Email,
                        null,
                        null,
                        null,
                        0
                    )
                );
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<(bool result, bool isNewUser)> SignIn(string oobCode)
        {
            var currentUnixTime = UnixTimeGetter.GetCurrentUnixTime();
            try
            {
                var response = await _googleApiGateway.EmailLinkSignin(
                    new EmailLinkSigninRequest(
                        AuthDataStore.GetAuthData().EmailInConfirmation,
                        oobCode,
                        true
                    )
                );
                AuthDataStore.SetAuthData(
                    new AuthData(
                        "",
                        response.IdToken,
                        response.Email,
                        response.RefreshToken,
                        currentUnixTime + response.ExpiresIn
                    )
                );
                return (true, response.IsNewUser);
            }
            catch
            {
                return (false, false);
            }
        }

        public async Task<string> GetToken()
        {
            try
            {
                var authData = AuthDataStore.GetAuthData();

                if (UnixTimeGetter.GetCurrentUnixTime() < authData.ExpirationTime)
                {
                    return authData.IdToken;
                }

                var currentUnixTime = UnixTimeGetter.GetCurrentUnixTime();
                var response = await _googleApiGateway.RefreshToken(
                    new RefreshTokenRequest(
                        "refresh_token",
                        authData.RefreshToken
                    )
                );
                AuthDataStore.SetAuthData(
                    new AuthData(
                        "",
                        response.IdToken,
                        authData.Email,
                        response.RefreshToken,
                        response.ExpiresIn + currentUnixTime
                    )
                );

                return response.IdToken;
            }
            catch
            {
                return null;
            }
        }

        [CanBeNull]
        public string GetUserEmail()
        {
            try
            {
                return AuthDataStore.GetAuthData().Email;
            }
            catch
            {
                return null;
            }
        }

        public void SignOut()
        {
            AuthDataStore.DeleteAuthData();
        }

        [CanBeNull]
        private string GetNullOrValue(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }
}
