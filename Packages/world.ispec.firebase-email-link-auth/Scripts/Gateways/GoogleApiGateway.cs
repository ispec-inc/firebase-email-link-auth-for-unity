using System.Threading.Tasks;

namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IGoogleApiGateway
    {
        public Task<IGetOobConfirmationCodeResponse> GetOobConfirmationCode(IGetOobConfirmationCodeRequest body);
        public Task<IEmailLinkSigninResponse> EmailLinkSignin(IEmailLinkSigninRequest body);
        public Task<IRefreshTokenResponse> RefreshToken(IRefreshTokenRequest body);
    }

    internal class GoogleApiGateway : IGoogleApiGateway
    {
        private readonly IRestApiGateway _restApiGateway;

        public GoogleApiGateway(IRestApiGateway restApiGateway)
        {
            _restApiGateway = restApiGateway;
        }

        public Task<IGetOobConfirmationCodeResponse> GetOobConfirmationCode(IGetOobConfirmationCodeRequest body)
        {
            return _restApiGateway.Post<IGetOobConfirmationCodeResponse>(
                GetIdentityToolKitUrl("getOobConfirmationCode"),
                body.ToDictionary().DictionaryKeyToTopLower()
            );
        }

        public Task<IEmailLinkSigninResponse> EmailLinkSignin(IEmailLinkSigninRequest body)
        {
            return _restApiGateway.Post<IEmailLinkSigninResponse>(
                GetIdentityToolKitUrl("emailLinkSignin"),
                body.ToDictionary().DictionaryKeyToTopLower()
            );
        }

        public Task<IRefreshTokenResponse> RefreshToken(IRefreshTokenRequest body)
        {
            return _restApiGateway.Post<IRefreshTokenResponse>(
                GetSecureTokenUrl("token"),
                body.ToDictionary().DictionaryKeyToSnakeCase()
            );
        }

        private static string GetIdentityToolKitUrl(string path)
        {
            return $"{Constants.GoogleApiUrls.IdentityToolKit}/{path}";
        }

        private static string GetSecureTokenUrl(string path)
        {
            return $"{Constants.GoogleApiUrls.SecureToken}/{path}";
        }
    }
}
