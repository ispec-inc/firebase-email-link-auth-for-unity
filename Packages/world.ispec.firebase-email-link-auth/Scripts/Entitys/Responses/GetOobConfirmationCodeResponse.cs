namespace ispec.FirebaseEmailLinkAuth
{
    internal interface IGetOobConfirmationCodeResponse
    {
        public string Kind { get; set; }
        public string Email { get; set; }
    }

    internal class GetOobConfirmationCodeResponse : IGetOobConfirmationCodeResponse
    {
        public string Kind { get; set; }
        public string Email { get; set; }

        public GetOobConfirmationCodeResponse(
            string kind,
            string email
        )
        {
            Kind = kind;
            Email = email;
        }
    }
}
