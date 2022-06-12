using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth.Editor
{
    internal static class Config
    {
        public static string GetDomain()
        {
            var domain = "";
            var configAssets = GetConfigAssets();

            foreach (var configAsset in configAssets)
            {
                if (!string.IsNullOrWhiteSpace(domain))
                {
                    Resources.UnloadAsset(configAsset);
                    continue;
                }
                if (!string.IsNullOrWhiteSpace(configAsset.Domain))
                {
                    domain = configAsset.Domain;
                }
                Resources.UnloadAsset(configAsset);
            }

            return string.IsNullOrWhiteSpace(domain) ? null : domain;
        }

        private static ConfigAsset[] GetConfigAssets()
        {
            var configAssets = Resources.LoadAll<ConfigAsset>(Constants.FileNames.EditorConfigFileName);
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
