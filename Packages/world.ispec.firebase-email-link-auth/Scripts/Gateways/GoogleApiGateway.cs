using System.Threading.Tasks;

namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IGoogleApiGateway
    {
        public Task<GetOobConfirmationCodeResponse> GetOobConfirmationCode(GetOobConfirmationCodeRequest body);
        public Task<EmailLinkSigninResponse> EmailLinkSignin(EmailLinkSigninRequest body);
        public Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest body);
    }

    internal class GoogleApiGateway : IGoogleApiGateway
    {
        private readonly IRestApiGateway _restApiGateway;

        public GoogleApiGateway(IRestApiGateway restApiGateway)
        {
            _restApiGateway = restApiGateway;
        }

        public Task<GetOobConfirmationCodeResponse> GetOobConfirmationCode(GetOobConfirmationCodeRequest body)
        {
            return _restApiGateway.Post<GetOobConfirmationCodeResponse>(
                CreateIdentityToolKitUrl("getOobConfirmationCode"),
                body
            );
        }

        public Task<EmailLinkSigninResponse> EmailLinkSignin(EmailLinkSigninRequest body)
        {
            return _restApiGateway.Post<EmailLinkSigninResponse>(
                CreateIdentityToolKitUrl("emailLinkSignin"),
                body
            );
        }

        public Task<RefreshTokenResponse> RefreshToken(RefreshTokenRequest body)
        {
            return _restApiGateway.Post<RefreshTokenResponse>(
                CreateSecureTokenUrl("token"),
                body
            );
        }

        private static string CreateIdentityToolKitUrl(string path)
        {
            return $"{Constants.GoogleApiUrls.IdentityToolKit}/{path}?key={Config.GetFirebaseWebApiKey()}";
        }

        private static string CreateSecureTokenUrl(string path)
        {
            return $"{Constants.GoogleApiUrls.SecureToken}/{path}?key={Config.GetFirebaseWebApiKey()}";
        }
    }
}
