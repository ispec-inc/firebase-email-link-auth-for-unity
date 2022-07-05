using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth.Editor
{
    internal class Config
    {
        private static readonly Config Instance = new Config();

        private ConfigAsset _configAsset;

        public static ConfigAsset GetValue()
        {
            return Instance._configAsset;
        }

        private Config()
        {
            var configAssets = LoadConfigAssets();
            ShowFileCountError(configAssets);
            SetConfig(configAssets);
            configAssets = null;
            Resources.UnloadUnusedAssets();
        }

        private void SetConfig(IReadOnlyCollection<ConfigAsset> configAssets)
        {
            _configAsset = configAssets.FirstOrDefault();
        }

        private static ConfigAsset[] LoadConfigAssets()
        {
            var configAssets = Resources.LoadAll<ConfigAsset>(
                Constants.FileNames.EditorConfigFileName
            );
            return configAssets;
        }

        private static void ShowFileCountError(
            IReadOnlyCollection<ConfigAsset> configAssets
        )
        {
            switch (configAssets.Count)
            {
                case 0:
                    Debug.LogError(
                        Constants.ErrorMessages.ConfigFileDoseNotExist
                    );
                    break;
                case > 1:
                    Debug.LogError(
                        Constants.ErrorMessages.ConfigFileExistsMultiple
                    );
                    break;
            }
        }
    }
}
