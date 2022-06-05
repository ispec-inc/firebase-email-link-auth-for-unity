using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class Config
    {
        public static string GetFirebaseWebApiKey()
        {
            var apiKey = "";
            var configAssets =
                Resources.LoadAll<ConfigAsset>(Constants.FileNames.ConfigFileName);

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

            if (configAssets.Length > 1)
            {
                Debug.LogError(Constants.ErrorMessages.ConfigFileExistsMultiple);
            }
            else if (configAssets.Length == 0)
            {
                Debug.LogError(Constants.ErrorMessages.ConfigFileDoseNotExist);
            }

            return string.IsNullOrWhiteSpace(apiKey) ? null : apiKey;
        }
    }
}
