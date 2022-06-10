using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class PlayerPrefsDataStore
    {
        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public static string GetString(string key)
        {
            return HasKey(key) ? PlayerPrefs.GetString(key) : null;
        }

        public static void DeleteKey(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public static bool HasKey(string key)
        {
            return PlayerPrefs.HasKey(key);
        }

        public static void SetObject<T>(string key, T obj)
        {
            SetString(key, obj.ToJson());
        }

        public static T GetObject<T>(string key)
        {
            return GetString(key).FromJson<T>();
        }
    }
}
