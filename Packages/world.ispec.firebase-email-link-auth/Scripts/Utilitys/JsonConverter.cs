using UnityEngine;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class JsonConverter
    {
        public static T FromJson<T>(string jsonData)
        {
            return JsonUtility.FromJson<T>(jsonData);
        }

        public static string ToJson(object objectData)
        {
            return JsonUtility.ToJson(objectData);
        }
    }
}
