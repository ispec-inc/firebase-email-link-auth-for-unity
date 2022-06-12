namespace ispec.FirebaseEmailLinkAuth.Editor
{
    internal static class Constants
    {
        public static class FileNames
        {
            public static readonly string EditorConfigFileName =
                "FirebaseEmailLinkAuthEditorConfig";
        }

        public static class ErrorMessages
        {
            public static readonly string ConfigFileExistsMultiple =
                $"There are multiple {FileNames.EditorConfigFileName} files. The first valid Key is loaded.";

            public static readonly string ConfigFileDoseNotExist =
                $"{FileNames.EditorConfigFileName} file does not exist.";
        }
    }
}
