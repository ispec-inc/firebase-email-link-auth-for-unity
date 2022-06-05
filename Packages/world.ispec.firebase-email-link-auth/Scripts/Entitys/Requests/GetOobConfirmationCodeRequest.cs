namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IGetOobConfirmationCodeRequest
    {
        public string RequestType { get; set; }
        public string Email { get; set; }
        public string ContinueUrl { get; set; }
        public bool CanHandleCodeInApp { get; set; }
    }

    internal class GetOobConfirmationCodeRequest : IGetOobConfirmationCodeRequest
    {
        public string RequestType { get; set; }
        public string Email { get; set; }
        public string ContinueUrl { get; set; }
        public bool CanHandleCodeInApp { get; set; }

        public GetOobConfirmationCodeRequest(
            string requestType,
            string email,
            string continueUrl,
            bool canHandleCodeInApp
        )
        {
            RequestType = requestType;
            Email = email;
            ContinueUrl = continueUrl;
            CanHandleCodeInApp = canHandleCodeInApp;
        }
    }
}
