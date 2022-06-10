using Newtonsoft.Json;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class JsonConverter
    {
        public static T FromJson<T>(this string jsonData)
        {
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static string ToJson(this object objectData)
        {
            return JsonConvert.SerializeObject(objectData);
        }
    }
}
