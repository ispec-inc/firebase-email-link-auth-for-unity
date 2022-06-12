using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class Config
    {
        public static string GetFirebaseWebApiKey()
        {
            var apiKey = "";
            var configAssets = GetConfigAssets();

            foreach (var configAsset in configAssets)
            {
                if (!string.IsNullOrWhiteSpace(apiKey))
                {
                    Resources.UnloadAsset(configAsset);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(configAsset.FirebaseWebApiKey))
                {
                    apiKey = configAsset.FirebaseWebApiKey;
                }
                Resources.UnloadAsset(configAsset);
            }

            return string.IsNullOrWhiteSpace(apiKey) ? null : apiKey;
        }

        public static string GetContinueUrl()
        {
            var continueUrl = "";
            var configAssets = GetConfigAssets();

            foreach (var configAsset in configAssets)
            {
                if (!string.IsNullOrWhiteSpace(continueUrl))
                {
                    Resources.UnloadAsset(configAsset);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(configAsset.ContinueUrl))
                {
                    continueUrl = configAsset.ContinueUrl;
                }
                Resources.UnloadAsset(configAsset);
            }

            return string.IsNullOrWhiteSpace(continueUrl) ? null : continueUrl;
        }

        public static string GetIosAppStoreId()
        {
            var iosAppStoreId = "";
            var configAssets = GetConfigAssets();

            foreach (var configAsset in configAssets)
            {
                if (!string.IsNullOrWhiteSpace(iosAppStoreId))
                {
                    Resources.UnloadAsset(configAsset);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(configAsset.IosAppStoreId))
                {
                    iosAppStoreId = configAsset.IosAppStoreId;
                }
                Resources.UnloadAsset(configAsset);
            }

            return string.IsNullOrWhiteSpace(iosAppStoreId) ? null : iosAppStoreId;
        }

        public static string GetIosBundleId()
        {
            var iosBundleId = "";
            var configAssets = GetConfigAssets();

            foreach (var configAsset in configAssets)
            {
                if (!string.IsNullOrWhiteSpace(iosBundleId))
                {
                    Resources.UnloadAsset(configAsset);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(configAsset.IosBundleId))
                {
                    iosBundleId = configAsset.IosBundleId;
                }
                Resources.UnloadAsset(configAsset);
            }

            return string.IsNullOrWhiteSpace(iosBundleId) ? null : iosBundleId;
        }

        private static ConfigAsset[] GetConfigAssets()
        {
            var configAssets = Resources.LoadAll<ConfigAsset>(Constants.FileNames.ConfigFileName);
            ShowFileCountError(configAssets);
            return configAssets;
        }

        private static void ShowFileCountError(ConfigAsset[] configAssets)
        {
            if (configAssets.Length > 1)
            {
                Debug.LogError(Constants.ErrorMessages.ConfigFileExistsMultiple);
            }
            else if (configAssets.Length == 0)
            {
                Debug.LogError(Constants.ErrorMessages.ConfigFileDoseNotExist);
            }
        }
    }
}
