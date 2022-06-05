namespace ispec.FirebaseEmailLinkAuth
{
    internal static class Constants
    {
        public static class GoogleApiUrls
        {
            public static readonly string IdentityToolKit =
                "https://www.googleapis.com/identitytoolkit/v3/relyingparty";

            public static readonly string SecureToken =
                "https://securetoken.googleapis.com/v1";
        }

        public static class FileNames
        {
            public static readonly string ConfigFileName =
                "FirebaseEmailLinkAuthConfig";
        }

        public static class ErrorMessages
        {
            public static readonly string ConfigFileExistsMultiple =
                $"There are multiple {FileNames.ConfigFileName} files. The first valid Key is loaded.";

            public static readonly string ConfigFileDoseNotExist =
                $"{FileNames.ConfigFileName} file does not exist.";
        }
    }
}
