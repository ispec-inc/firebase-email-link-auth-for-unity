using System.Threading.Tasks;

namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IGoogleApiGateway
    {
        // public Task<IGetOobConfirmationCodeResponse> GetOobConfirmationCode(IGetOobConfirmationCodeRequest body);
    }

    internal class GoogleApiGateway : IGoogleApiGateway
    {
        private readonly IRestApiGateway _restApiGateway;

        public GoogleApiGateway(IRestApiGateway restApiGateway)
        {
            _restApiGateway = restApiGateway;
        }

        // public Task<IGetOobConfirmationCodeResponse> GetOobConfirmationCode(IGetOobConfirmationCodeRequest body)
        // {
        //     return _restApiGateway.Post<IGetOobConfirmationCodeResponse>();
        // }
    }
}
