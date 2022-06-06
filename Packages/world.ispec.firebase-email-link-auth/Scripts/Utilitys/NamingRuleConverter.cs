using System.Collections.Generic;
using System.Linq;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class NamingRuleConverter
    {
        public static string ToTopLower(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            return char.ToLower(str[0]) + str[1..];
        }

        public static string ToSnakeCase(this string str)
        {
            var regex = new System.Text.RegularExpressions.Regex("[a-z][A-Z]");
            var replaceStr = regex.Replace(
                str,
                s => $"{s.Groups[0].Value[0]}_{char.ToLower(s.Groups[0].Value[1])}"
            );
            return char.ToLower(replaceStr[0]) + replaceStr[1..];
        }

        public static Dictionary<string, string> DictionaryKeyToTopLower(
            this Dictionary<string, string> dictionary
        )
        {
            return dictionary
                .Select(
                    pair => new KeyValuePair<string, string>(
                        pair.Key.ToTopLower(),
                        pair.Value
                    ))
                .ToDictionary();
        }

        public static Dictionary<string, string> DictionaryKeyToSnakeCase(
            this Dictionary<string, string> dictionary
        )
        {
            return dictionary
                .Select(
                    pair => new KeyValuePair<string, string>(
                        pair.Key.ToSnakeCase(),
                        pair.Value
                    )
                )
                .ToDictionary();
        }
    }
}
