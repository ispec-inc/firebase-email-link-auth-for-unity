using System.Threading.Tasks;

namespace ispec.FirebaseEmailLinkAuth
{
    public interface IFirebaseEmailLinkAuth
    {
        public Task<bool> SendAuthLinkEmail(string email, string continueUrl);
        public Task<bool> SignIn(string oobCode);
        public Task<string> GetToken();
        public void SignOut();
    }

    public class FirebaseEmailLinkAuth : IFirebaseEmailLinkAuth
    {
        private readonly IGoogleApiGateway _googleApiGateway;

        public FirebaseEmailLinkAuth()
        {
            _googleApiGateway = new GoogleApiGateway(
                new RestApiGateway()
            );
        }

        public async Task<bool> SendAuthLinkEmail(string email, string continueUrl)
        {
            if (MailAddressChecker.IsEmailAddress(email))
            {
                return false;
            }

            try
            {
                var response = await _googleApiGateway.GetOobConfirmationCode(
                    new GetOobConfirmationCodeRequest(
                        "EMAIL_SIGNIN",
                        email,
                        continueUrl,
                        true,
                        Config.GetIosAppStoreId(),
                        Config.GetIosBundleId()
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

        public async Task<bool> SignIn(string oobCode)
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
            }
            catch
            {
                return false;
            }
            return true;
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

        public void SignOut()
        {
            AuthDataStore.DeleteAuthData();
        }
    }
}
