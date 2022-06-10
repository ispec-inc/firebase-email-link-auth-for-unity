namespace ispec.FirebaseEmailLinkAuth
{
    internal static class AuthDataStore
    {
        public static void DeleteAuthData()
        {
            PlayerPrefsDataStore.DeleteKey(
                Constants.DataStoreKeys.AuthDataStoreKey
            );
        }

        public static bool HasAuthData()
        {
            return PlayerPrefsDataStore.HasKey(
                Constants.DataStoreKeys.AuthDataStoreKey
            );
        }

        public static void SetAuthData(AuthData data)
        {
            PlayerPrefsDataStore.SetObject(
                Constants.DataStoreKeys.AuthDataStoreKey,
                data
            );
        }

        public static AuthData GetAuthData()
        {
            return PlayerPrefsDataStore.GetObject<AuthData>(
                Constants.DataStoreKeys.AuthDataStoreKey
            );
        }
    }
}
